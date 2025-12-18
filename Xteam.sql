CREATE DATABASE "Xteam" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'es-US';

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;
CREATE FUNCTION public.fn_giris_yap(p_kullanici_adi character varying, p_sifre character varying) RETURNS TABLE(id integer, rol character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_id INT;
    v_rol VARCHAR;
BEGIN
    SELECT h.id INTO v_id
    FROM HESAP h
    WHERE h.kullanici_adi = p_kullanici_adi AND h.sifre = p_sifre;
    IF v_id IS NOT NULL THEN
        UPDATE HESAP SET son_giris = CURRENT_TIMESTAMP WHERE HESAP.id = v_id;
        IF EXISTS (SELECT 1 FROM OYUNCU WHERE oyuncu_id = v_id) THEN
            v_rol := 'Oyuncu';
        ELSE
            v_rol := 'Gelistirici';
        END IF;
        RETURN QUERY SELECT v_id, v_rol;
    ELSE
        RETURN QUERY SELECT 0, 'Hatali'::VARCHAR;
    END IF;
END;
$$;
CREATE FUNCTION public.fn_kayit_ol(p_eposta character varying, p_hesap_adi character varying, p_kullanici_adi character varying, p_sifre character varying, p_tur character varying, p_vergi_no character varying, p_web_sitesi character varying) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_yeni_id INT;
BEGIN
    INSERT INTO HESAP (eposta, hesap_adi, kullanici_adi, sifre, kayit_tarihi)
    VALUES (p_eposta, p_hesap_adi, p_kullanici_adi, p_sifre, CURRENT_TIMESTAMP)
    RETURNING id INTO v_yeni_id;
    IF p_tur = 'Oyuncu' THEN
        INSERT INTO OYUNCU (oyuncu_id, seviye, cuzdan_bakiyesi)
        VALUES (v_yeni_id, 1, 0.00);
    ELSIF p_tur = 'Gelistirici' THEN
        INSERT INTO GELISTIRICI (gelistirici_id, vergi_no, web_sitesi)
        VALUES (v_yeni_id, p_vergi_no, p_web_sitesi);
    END IF;
    RETURN v_yeni_id;
END;
$$;
CREATE FUNCTION public.fn_oyun_ara(p_arama_metni character varying, p_kategori_id integer DEFAULT 0) RETURNS TABLE(oyun_id integer, baslik character varying, fiyat numeric, yukleme_boyutu integer, kampanya_adi character varying, indirim_orani integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT DISTINCT
        o.oyun_id,
        o.baslik,
        o.fiyat,
        o.yukleme_boyutu,
        k.baslik as kampanya_adi,
        COALESCE(k.indirim_orani, 0) as indirim_orani
    FROM OYUN o
    LEFT JOIN KAMPANYA k ON o.kampanya_id = k.kampanya_id
    LEFT JOIN OYUN_KATEGORI ok ON o.oyun_id = ok.oyun_id
    WHERE 
        (p_arama_metni IS NULL OR o.baslik ILIKE '%' || p_arama_metni || '%')
        AND 
        (p_kategori_id IS NULL OR p_kategori_id = 0 OR ok.kategori_id = p_kategori_id)
    ORDER BY o.baslik ASC;
END;
$$;
CREATE FUNCTION public.fn_satin_al(p_oyuncu_id integer) RETURNS text
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_toplam_tutar DECIMAL(10,2);
    v_bakiye DECIMAL(10,2);
    v_siparis_id INT;
BEGIN
    SELECT SUM(
       o.fiyat - (o.fiyat * COALESCE(k.indirim_orani, 0) / 100.0)
    ) INTO v_toplam_tutar    
    FROM SEPET s
    JOIN OYUN o ON s.oyun_id = o.oyun_id
    LEFT JOIN KAMPANYA k ON o.kampanya_id = k.kampanya_id 
    WHERE s.oyuncu_id = p_oyuncu_id;
    IF v_toplam_tutar IS NULL THEN RETURN 'Sepet Boş'; END IF;
    SELECT cuzdan_bakiyesi INTO v_bakiye FROM OYUNCU WHERE oyuncu_id = p_oyuncu_id;
    IF v_bakiye < v_toplam_tutar THEN RETURN 'Yetersiz Bakiye'; END IF;
    INSERT INTO SIPARIS (oyuncu_id, toplam_tutar) VALUES (p_oyuncu_id, v_toplam_tutar) 
    RETURNING siparis_id INTO v_siparis_id;
    INSERT INTO SIPARIS_DETAY (siparis_id, oyun_id, satis_fiyati)
    SELECT v_siparis_id, s.oyun_id, 
           (o.fiyat - (o.fiyat * COALESCE(k.indirim_orani, 0) / 100.0)) 
    FROM SEPET s 
    JOIN OYUN o ON s.oyun_id = o.oyun_id
    LEFT JOIN KAMPANYA k ON o.kampanya_id = k.kampanya_id 
    WHERE s.oyuncu_id = p_oyuncu_id;
    INSERT INTO OYUN_KULLANICI (oyuncu_id, oyun_id, alinma_tarihi, durum_id)
    SELECT s.oyuncu_id, s.oyun_id, CURRENT_TIMESTAMP, 1 
    FROM SEPET s WHERE s.oyuncu_id = p_oyuncu_id
    ON CONFLICT DO NOTHING; 
    UPDATE OYUNCU SET cuzdan_bakiyesi = cuzdan_bakiyesi - v_toplam_tutar WHERE oyuncu_id = p_oyuncu_id;
    DELETE FROM SEPET WHERE oyuncu_id = p_oyuncu_id;
    RETURN 'Basarili';
END;
$$;
CREATE FUNCTION public.trg_fiyat_kontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW.fiyat < 0 THEN
        RAISE EXCEPTION 'Oyun fiyatı negatif olamaz!';
    END IF;
    RETURN NEW;
END;
$$;
CREATE FUNCTION public.trg_indirilme_arttir() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW.durum_id = 2 AND (OLD.durum_id IS NULL OR OLD.durum_id != 2) THEN
        UPDATE OYUN SET indirilme_sayisi = indirilme_sayisi + 1 WHERE oyun_id = NEW.oyun_id;
    END IF;
    RETURN NEW;
END;
$$;
CREATE FUNCTION public.trg_kendine_arkadas_engelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW.istek_gonderen_id = NEW.istek_alan_id THEN
        RAISE EXCEPTION 'Kendinize arkadaşlık isteği gönderemezsiniz.';
    END IF;
    RETURN NEW;
END;
$$;
CREATE FUNCTION public.trg_tarih_kontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW.bitis_tarihi <= NEW.baslangic_tarihi THEN
        RAISE EXCEPTION 'Bitiş tarihi başlangıç tarihinden küçük olamaz!';
    END IF;
    RETURN NEW;
END;
$$;
SET default_table_access_method = heap;
CREATE TABLE public.arkadaslik (
    istek_gonderen_id integer NOT NULL,
    istek_alan_id integer NOT NULL,
    durum_id integer,
    arkadaslik_tarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT arkadaslik_check CHECK ((istek_gonderen_id <> istek_alan_id))
);
CREATE TABLE public.arkadaslik_durum (
    durum_id integer NOT NULL,
    durum_adi character varying(20) NOT NULL
);
CREATE TABLE public.dil (
    dil_id integer NOT NULL,
    dil_adi character varying(30) NOT NULL
);
CREATE SEQUENCE public.dil_dil_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.dil_dil_id_seq OWNED BY public.dil.dil_id;
CREATE TABLE public.gelistirici (
    gelistirici_id integer NOT NULL,
    vergi_no character varying(20),
    web_sitesi character varying(100)
);
CREATE TABLE public.hesap (
    id integer NOT NULL,
    eposta character varying(50) NOT NULL,
    hesap_adi character varying(50) NOT NULL,
    kullanici_adi character varying(50) NOT NULL,
    sifre character varying(255) NOT NULL,
    kayit_tarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    son_giris timestamp without time zone
);
CREATE SEQUENCE public.hesap_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.hesap_id_seq OWNED BY public.hesap.id;
CREATE TABLE public.kampanya (
    kampanya_id integer NOT NULL,
    baslik character varying(100),
    baslangic_tarihi timestamp without time zone,
    bitis_tarihi timestamp without time zone,
    aktif_mi boolean DEFAULT true,
    indirim_orani integer DEFAULT 0
);
CREATE SEQUENCE public.kampanya_kampanya_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.kampanya_kampanya_id_seq OWNED BY public.kampanya.kampanya_id;
CREATE TABLE public.kategori (
    kategori_id integer NOT NULL,
    tur_adi character varying(50) NOT NULL
);
CREATE SEQUENCE public.kategori_kategori_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.kategori_kategori_id_seq OWNED BY public.kategori.kategori_id;
CREATE TABLE public.oyun (
    oyun_id integer NOT NULL,
    gelistirici_id integer NOT NULL,
    kampanya_id integer,
    baslik character varying(100) NOT NULL,
    fiyat numeric(10,2),
    cikis_tarihi date,
    yukleme_boyutu integer,
    aciklama text,
    indirilme_sayisi integer DEFAULT 0,
    CONSTRAINT oyun_fiyat_check CHECK ((fiyat >= (0)::numeric))
);
CREATE TABLE public.oyun_dil (
    oyun_id integer NOT NULL,
    dil_id integer NOT NULL,
    altyazi_var_mi boolean DEFAULT false,
    seslendirme_var_mi boolean DEFAULT false
);
CREATE TABLE public.oyun_durumu (
    durum_id integer NOT NULL,
    durum_adi character varying(20) NOT NULL
);
CREATE TABLE public.oyun_kategori (
    oyun_id integer NOT NULL,
    kategori_id integer NOT NULL
);
CREATE TABLE public.oyun_kullanici (
    oyuncu_id integer NOT NULL,
    oyun_id integer NOT NULL,
    alinma_tarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    oynama_suresi integer DEFAULT 0,
    durum_id integer
);
CREATE SEQUENCE public.oyun_oyun_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.oyun_oyun_id_seq OWNED BY public.oyun.oyun_id;
CREATE TABLE public.oyuncu (
    oyuncu_id integer NOT NULL,
    seviye integer DEFAULT 1,
    cuzdan_bakiyesi numeric(10,2) DEFAULT 0.00
);
CREATE TABLE public.sepet (
    sepet_id integer NOT NULL,
    oyuncu_id integer NOT NULL,
    oyun_id integer NOT NULL,
    eklenme_tarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
CREATE SEQUENCE public.sepet_sepet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.sepet_sepet_id_seq OWNED BY public.sepet.sepet_id;
CREATE TABLE public.siparis (
    siparis_id integer NOT NULL,
    oyuncu_id integer NOT NULL,
    toplam_tutar numeric(10,2) DEFAULT 0,
    siparis_tarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE public.siparis_detay (
    detay_id integer NOT NULL,
    siparis_id integer NOT NULL,
    oyun_id integer NOT NULL,
    satis_fiyati numeric(10,2) NOT NULL
);
CREATE SEQUENCE public.siparis_detay_detay_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.siparis_detay_detay_id_seq OWNED BY public.siparis_detay.detay_id;
CREATE SEQUENCE public.siparis_siparis_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public.siparis_siparis_id_seq OWNED BY public.siparis.siparis_id;
ALTER TABLE ONLY public.dil ALTER COLUMN dil_id SET DEFAULT nextval('public.dil_dil_id_seq'::regclass);
ALTER TABLE ONLY public.hesap ALTER COLUMN id SET DEFAULT nextval('public.hesap_id_seq'::regclass);
ALTER TABLE ONLY public.kampanya ALTER COLUMN kampanya_id SET DEFAULT nextval('public.kampanya_kampanya_id_seq'::regclass);
ALTER TABLE ONLY public.kategori ALTER COLUMN kategori_id SET DEFAULT nextval('public.kategori_kategori_id_seq'::regclass);
ALTER TABLE ONLY public.oyun ALTER COLUMN oyun_id SET DEFAULT nextval('public.oyun_oyun_id_seq'::regclass);
ALTER TABLE ONLY public.sepet ALTER COLUMN sepet_id SET DEFAULT nextval('public.sepet_sepet_id_seq'::regclass);
ALTER TABLE ONLY public.siparis ALTER COLUMN siparis_id SET DEFAULT nextval('public.siparis_siparis_id_seq'::regclass);
ALTER TABLE ONLY public.siparis_detay ALTER COLUMN detay_id SET DEFAULT nextval('public.siparis_detay_detay_id_seq'::regclass);
INSERT INTO public.arkadaslik VALUES
	(6, 4, 1, '2025-12-12 22:27:21.888143'),
	(5, 4, 1, '2025-12-15 16:47:42.987214'),
	(6, 8, 1, '2025-12-18 14:06:03.216277'),
	(8, 5, 1, '2025-12-18 14:59:59.861359');
INSERT INTO public.arkadaslik_durum VALUES
	(1, 'Beklemede'),
	(2, 'Kabul Edildi');
INSERT INTO public.dil VALUES
	(1, 'Türkçe'),
	(2, 'İngilizce'),
	(3, 'Almanca'),
	(4, 'Japonca'),
	(5, 'İspanyolca');
INSERT INTO public.gelistirici VALUES
	(2, 'US-112233', 'www.riotgames.com'),
	(3, 'PL-555666', 'www.cdprojekt.com'),
	(1, '12345', 'www.valvesoftware.com'),
	(9, '111111', 'rockstar.com'),
	(12, '11111', 'sony.com'),
	(13, '11111', 'network.com'),
	(14, '11111', 'teamcherry.com'),
	(15, '111111', 'mojang.com');
INSERT INTO public.hesap VALUES
	(3, 'info@cdpr.com', 'cdprojektred', 'cd_admin', '12345', '2025-12-12 22:27:21.888143', NULL),
	(9, 'rockstar@mail.com', 'Rockstar Games', 'rockstar_admin', '12345', '2025-12-13 14:00:44.326088', '2025-12-18 13:30:23.879753'),
	(12, 'sony@mail.com', 'sony', 'sony_admin', '12345', '2025-12-18 13:33:56.402178', '2025-12-18 13:38:17.408682'),
	(14, 'teamcherry@mail.com', 'teamcherry', 'teamcherry_admin', '12345', '2025-12-18 13:45:36.321213', '2025-12-18 13:45:46.479796'),
	(6, 'ayse@mail.com', 'aysek', 'aysek123', '12345', '2025-12-12 22:27:21.888143', '2025-12-18 14:05:56.039006'),
	(13, 'network@mail.com', 'Network Games', 'network_admin', '12345', '2025-12-18 13:38:15.26795', '2025-12-18 14:19:53.953776'),
	(5, 'mehmet@mail.com', 'mehmetdemir', 'mehmet123', '12345', '2025-12-12 22:27:21.888143', '2025-12-18 14:22:42.191412'),
	(1, 'gabenen@valve.com', 'valve', 'valve_admin', '12345', '2025-12-12 22:27:21.888143', '2025-12-18 14:24:43.14077'),
	(4, 'ahmet@mail.com', 'ahmetyilmaz', 'ahmet123', '12345', '2025-12-12 22:27:21.888143', '2025-12-18 14:24:56.077851'),
	(15, 'mojang', 'Mojang', 'mojang_admin', '12345', '2025-12-18 15:37:09.946447', NULL),
	(8, 'ahmet2@mail.com', 'ahmetfe', 'ahmetfe123', '12345', '2025-12-13 13:44:42.149415', '2025-12-19 00:28:03.671555'),
	(17, 'ulusinansinan@gmail.com', 'mrpanda', 'sinanulu123', '12345', '2025-12-19 00:29:48.960594', '2025-12-19 00:29:58.540237'),
	(2, 'contact@riot.com', 'riotgames', 'riot_admin', '12345', '2025-12-12 22:27:21.888143', '2025-12-16 14:28:57.957439');
INSERT INTO public.kampanya VALUES
	(1, 'Yaz İndirimleri', '2025-06-01 00:00:00', '2025-12-15 18:50:00', true, 30),
	(6, '%23 indirim', '2025-12-16 14:26:21.036092', '2025-12-26 14:26:21.036', true, 23),
	(2, 'Kış İndirimleri', '2025-12-01 00:00:00', '2026-01-01 00:00:00', true, 50),
	(3, 'Bahar İndiirmleri', '2025-12-15 19:04:19.690235', '2025-12-22 19:04:19.690385', true, 25),
	(8, 'Cadılar Bayramı', '2025-12-18 02:40:40.999111', '2025-12-25 02:40:40.999221', true, 25);
INSERT INTO public.kategori VALUES
	(1, 'Aksiyon'),
	(2, 'RPG'),
	(3, 'Strateji'),
	(4, 'Spor'),
	(5, 'Korku'),
	(6, 'Simülasyon'),
	(7, 'Yarış'),
	(8, 'Macera'),
	(9, 'Dövüş'),
	(10, 'Platform'),
	(11, 'Bulmaca'),
	(12, '2D'),
	(13, '3D');
INSERT INTO public.oyun VALUES
	(3, 2, NULL, 'League of Legends', 0.00, '2009-10-27', 22, 'MOBA türünün lideri.', 50000),
	(5, 3, 1, 'Cyberpunk 2077', 899.00, '2020-12-10', 70, 'Night City''de geçen açık dünya RPG.', 25000),
	(6, 3, NULL, 'The Witcher 3: Wild Hunt', 400.00, '2015-05-19', 50, 'Canavar avcısı Geralt''ın hikayesi.', 80000),
	(4, 2, NULL, 'Valorant', 0.00, '2020-06-02', 30, 'Karakter tabanlı taktiksel nişancı oyunu.', 45001),
	(9, 9, 6, 'Gta V', 499.00, '2025-12-18', 90, '', 0),
	(10, 9, NULL, 'Red Dead Redemption 2', 2500.00, '2025-12-18', 119, 'Vahşi batıda geçen açık dünya bir kovboy oyunu.', 0),
	(11, 12, 2, 'God of War', 500.00, '2025-12-18', 80, '2018 yapımı aksiyon macera oyunu.', 0),
	(12, 13, 6, 'Anomaly Agent', 50.00, '2025-12-18', 1, 'Cyberpunk temalı aksiyon, platform oyunu.', 0),
	(13, 13, NULL, 'EA FC 26', 2000.00, '2025-12-18', 50, 'Klasik futbol', 0),
	(14, 13, NULL, 'Uncharted Bundle', 2000.00, '2025-12-18', 200, 'Tüm uncharted serilerinin olduğu bir paketi içerir.', 0),
	(15, 14, NULL, 'Hollow Knight', 200.00, '2025-12-18', 10, 'Forge your own path in Hollow Knight! An epic action adventure through a vast ruined kingdom of insects and heroes. Explore twisting caverns, battle tainted creatures and befriend bizarre bugs, all in a classic, hand-drawn 2D style.', 0),
	(16, 14, NULL, 'Hollow Knight: Silksong', 300.00, '2025-12-18', 12, 'Discover a vast, haunted kingdom in Hollow Knight: Silksong! Explore, fight and survive as you ascend to the peak of a land ruled by silk and song.
As the lethal hunter Hornet, adventure through a kingdom ruled by silk and song! Captured and taken to this unfamiliar world, prepare to battle mighty foes and solve ancient mysteries as you ascend on a deadly pilgrimage to the kingdom’s peak.
', 0),
	(8, 1, NULL, 'Minecraft', 50.00, '2025-12-15', 25, 'mc', 1),
	(1, 1, 3, 'Counter-Strike 2', 50.00, '2023-09-27', 35, 'Dünyanın en popüler taktiksel FPS oyunu.', 100006),
	(2, 1, 1, 'Half-Life 3', 1000.00, '2026-01-01', 55, 'Gordon Freeman geri dönüyor.', 5);
INSERT INTO public.oyun_dil VALUES
	(1, 1, true, false),
	(1, 2, true, true),
	(3, 1, true, true),
	(1, 3, true, true),
	(1, 4, true, false),
	(9, 2, true, true),
	(9, 3, true, true),
	(9, 4, true, false),
	(9, 5, true, false),
	(8, 1, true, true),
	(8, 2, true, true),
	(8, 3, true, false),
	(8, 5, true, false),
	(10, 2, true, true),
	(10, 3, true, false),
	(10, 5, true, false),
	(11, 1, true, false),
	(11, 2, true, true),
	(11, 3, true, false),
	(11, 4, true, false),
	(11, 5, true, false),
	(12, 1, true, true),
	(12, 2, true, true),
	(12, 3, true, true),
	(12, 4, true, true),
	(12, 5, true, true),
	(13, 2, true, true),
	(13, 3, true, true),
	(13, 4, true, true),
	(13, 5, true, true),
	(14, 1, true, true),
	(14, 2, true, true),
	(14, 3, true, true),
	(14, 4, true, true),
	(14, 5, true, true),
	(15, 2, true, true),
	(15, 3, true, true),
	(15, 4, true, true),
	(15, 5, true, true),
	(16, 2, true, true),
	(16, 3, true, true),
	(16, 4, true, true),
	(16, 5, true, true),
	(2, 1, true, true),
	(2, 2, true, true),
	(2, 3, true, true),
	(2, 4, true, true),
	(2, 5, true, true);
INSERT INTO public.oyun_durumu VALUES
	(1, 'Yüklü Değil'),
	(2, 'Yüklendi'),
	(3, 'İade Edildi');
INSERT INTO public.oyun_kategori VALUES
	(3, 2),
	(3, 3),
	(5, 1),
	(5, 2),
	(9, 1),
	(9, 2),
	(9, 7),
	(9, 13),
	(8, 6),
	(10, 1),
	(10, 2),
	(10, 13),
	(11, 1),
	(11, 2),
	(11, 8),
	(11, 13),
	(12, 1),
	(12, 10),
	(12, 13),
	(13, 3),
	(13, 4),
	(13, 6),
	(13, 13),
	(14, 1),
	(14, 6),
	(14, 8),
	(14, 11),
	(14, 13),
	(15, 6),
	(15, 10),
	(15, 11),
	(15, 12),
	(16, 6),
	(16, 10),
	(16, 11),
	(16, 12),
	(2, 1),
	(2, 11),
	(2, 13),
	(1, 1),
	(1, 3);
INSERT INTO public.oyun_kullanici VALUES
	(4, 6, '2025-12-12 22:27:21.888143', 5000, 2),
	(5, 3, '2025-12-12 22:27:21.888143', 600, 3),
	(5, 5, '2025-12-13 17:33:06.637783', 0, 1),
	(5, 6, '2025-12-13 17:45:24.777969', 0, 1),
	(5, 4, '2025-12-13 17:45:24.777969', 0, 1),
	(5, 2, '2025-12-14 00:26:41.493275', 110, 2),
	(5, 1, '2025-12-13 17:34:17.780901', 17, 2),
	(8, 6, '2025-12-16 14:21:20.653715', 0, 1),
	(8, 4, '2025-12-16 14:21:20.653715', 0, 1),
	(5, 8, '2025-12-15 21:44:18.728434', 3, 2),
	(4, 5, '2025-12-18 14:25:22.460574', 0, 1),
	(8, 2, '2025-12-16 14:21:20.653715', 0, 2),
	(8, 11, '2025-12-18 15:46:57.208683', 0, 1),
	(8, 1, '2025-12-18 15:46:57.208683', 0, 1),
	(8, 12, '2025-12-18 15:46:57.208683', 0, 1),
	(8, 14, '2025-12-18 15:46:57.208683', 0, 1),
	(8, 5, '2025-12-18 15:46:57.208683', 0, 1),
	(8, 16, '2025-12-18 15:46:57.208683', 0, 1);
INSERT INTO public.oyuncu VALUES
	(6, 1, 0.00),
	(4, 15, 2470.70),
	(8, 1, 594.70),
	(17, 1, 0.00),
	(5, 2, 3042.60);
INSERT INTO public.siparis VALUES
	(1, 5, 1719.10, '2025-12-13 17:33:06.637783'),
	(2, 5, 1719.10, '2025-12-13 17:34:17.780901'),
	(3, 5, 1119.20, '2025-12-13 17:45:24.777969'),
	(4, 8, 719.20, '2025-12-13 17:46:44.045211'),
	(5, 5, 999.90, '2025-12-14 00:26:41.493275'),
	(6, 5, 50.00, '2025-12-15 21:44:18.728434'),
	(7, 8, 750.00, '2025-12-16 14:21:20.653715'),
	(8, 4, 666.80, '2025-12-18 14:25:22.460574'),
	(9, 8, 3255.30, '2025-12-18 15:46:57.208683');
INSERT INTO public.siparis_detay VALUES
	(1, 1, 2, 999.90),
	(2, 1, 3, 0.00),
	(3, 1, 5, 719.20),
	(4, 2, 1, 0.00),
	(5, 2, 2, 999.90),
	(6, 2, 5, 719.20),
	(7, 3, 3, 0.00),
	(8, 3, 4, 0.00),
	(9, 3, 5, 719.20),
	(10, 3, 6, 400.00),
	(11, 4, 5, 719.20),
	(12, 5, 2, 999.90),
	(13, 6, 8, 50.00),
	(14, 7, 6, 400.00),
	(15, 7, 4, 0.00),
	(16, 7, 2, 350.00),
	(17, 7, 1, 0.00),
	(18, 8, 5, 629.30),
	(19, 8, 1, 37.50),
	(20, 9, 5, 629.30),
	(21, 9, 11, 250.00),
	(22, 9, 12, 38.50),
	(23, 9, 14, 2000.00),
	(24, 9, 16, 300.00),
	(25, 9, 1, 37.50);
SELECT pg_catalog.setval('public.dil_dil_id_seq', 5, true);
SELECT pg_catalog.setval('public.hesap_id_seq', 18, true);
SELECT pg_catalog.setval('public.kampanya_kampanya_id_seq', 8, true);
SELECT pg_catalog.setval('public.kategori_kategori_id_seq', 8, true);
SELECT pg_catalog.setval('public.oyun_oyun_id_seq', 16, true);
SELECT pg_catalog.setval('public.sepet_sepet_id_seq', 38, true);
SELECT pg_catalog.setval('public.siparis_detay_detay_id_seq', 25, true);
SELECT pg_catalog.setval('public.siparis_siparis_id_seq', 9, true);
ALTER TABLE ONLY public.arkadaslik_durum
    ADD CONSTRAINT arkadaslik_durum_pkey PRIMARY KEY (durum_id);
ALTER TABLE ONLY public.arkadaslik
    ADD CONSTRAINT arkadaslik_pkey PRIMARY KEY (istek_gonderen_id, istek_alan_id);
ALTER TABLE ONLY public.dil
    ADD CONSTRAINT dil_pkey PRIMARY KEY (dil_id);
ALTER TABLE ONLY public.gelistirici
    ADD CONSTRAINT gelistirici_pkey PRIMARY KEY (gelistirici_id);
ALTER TABLE ONLY public.hesap
    ADD CONSTRAINT hesap_eposta_key UNIQUE (eposta);
ALTER TABLE ONLY public.hesap
    ADD CONSTRAINT hesap_kullanici_adi_key UNIQUE (kullanici_adi);
ALTER TABLE ONLY public.hesap
    ADD CONSTRAINT hesap_pkey PRIMARY KEY (id);
ALTER TABLE ONLY public.kampanya
    ADD CONSTRAINT kampanya_pkey PRIMARY KEY (kampanya_id);
ALTER TABLE ONLY public.kategori
    ADD CONSTRAINT kategori_pkey PRIMARY KEY (kategori_id);
ALTER TABLE ONLY public.oyun_dil
    ADD CONSTRAINT oyun_dil_pkey PRIMARY KEY (oyun_id, dil_id);
ALTER TABLE ONLY public.oyun_durumu
    ADD CONSTRAINT oyun_durumu_pkey PRIMARY KEY (durum_id);
ALTER TABLE ONLY public.oyun_kategori
    ADD CONSTRAINT oyun_kategori_pkey PRIMARY KEY (oyun_id, kategori_id);
ALTER TABLE ONLY public.oyun_kullanici
    ADD CONSTRAINT oyun_kullanici_pkey PRIMARY KEY (oyuncu_id, oyun_id);
ALTER TABLE ONLY public.oyun
    ADD CONSTRAINT oyun_pkey PRIMARY KEY (oyun_id);
ALTER TABLE ONLY public.oyuncu
    ADD CONSTRAINT oyuncu_pkey PRIMARY KEY (oyuncu_id);
ALTER TABLE ONLY public.sepet
    ADD CONSTRAINT sepet_oyuncu_id_oyun_id_key UNIQUE (oyuncu_id, oyun_id);
ALTER TABLE ONLY public.sepet
    ADD CONSTRAINT sepet_pkey PRIMARY KEY (sepet_id);
ALTER TABLE ONLY public.siparis_detay
    ADD CONSTRAINT siparis_detay_pkey PRIMARY KEY (detay_id);
ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_pkey PRIMARY KEY (siparis_id);
CREATE TRIGGER trg_check_arkadas BEFORE INSERT ON public.arkadaslik FOR EACH ROW EXECUTE FUNCTION public.trg_kendine_arkadas_engelle();
CREATE TRIGGER trg_fiyat_guvenligi BEFORE INSERT OR UPDATE ON public.oyun FOR EACH ROW EXECUTE FUNCTION public.trg_fiyat_kontrol();
CREATE TRIGGER trg_kampanya_check BEFORE INSERT OR UPDATE ON public.kampanya FOR EACH ROW EXECUTE FUNCTION public.trg_tarih_kontrol();
CREATE TRIGGER trg_oyun_yuklendi AFTER UPDATE ON public.oyun_kullanici FOR EACH ROW EXECUTE FUNCTION public.trg_indirilme_arttir();
ALTER TABLE ONLY public.arkadaslik
    ADD CONSTRAINT arkadaslik_durum_id_fkey FOREIGN KEY (durum_id) REFERENCES public.arkadaslik_durum(durum_id);
ALTER TABLE ONLY public.arkadaslik
    ADD CONSTRAINT arkadaslik_istek_alan_id_fkey FOREIGN KEY (istek_alan_id) REFERENCES public.oyuncu(oyuncu_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.arkadaslik
    ADD CONSTRAINT arkadaslik_istek_gonderen_id_fkey FOREIGN KEY (istek_gonderen_id) REFERENCES public.oyuncu(oyuncu_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.gelistirici
    ADD CONSTRAINT gelistirici_gelistirici_id_fkey FOREIGN KEY (gelistirici_id) REFERENCES public.hesap(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun_dil
    ADD CONSTRAINT oyun_dil_dil_id_fkey FOREIGN KEY (dil_id) REFERENCES public.dil(dil_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun_dil
    ADD CONSTRAINT oyun_dil_oyun_id_fkey FOREIGN KEY (oyun_id) REFERENCES public.oyun(oyun_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun
    ADD CONSTRAINT oyun_gelistirici_id_fkey FOREIGN KEY (gelistirici_id) REFERENCES public.gelistirici(gelistirici_id);
ALTER TABLE ONLY public.oyun
    ADD CONSTRAINT oyun_kampanya_id_fkey FOREIGN KEY (kampanya_id) REFERENCES public.kampanya(kampanya_id);
ALTER TABLE ONLY public.oyun_kategori
    ADD CONSTRAINT oyun_kategori_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun_kategori
    ADD CONSTRAINT oyun_kategori_oyun_id_fkey FOREIGN KEY (oyun_id) REFERENCES public.oyun(oyun_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun_kullanici
    ADD CONSTRAINT oyun_kullanici_durum_id_fkey FOREIGN KEY (durum_id) REFERENCES public.oyun_durumu(durum_id);
ALTER TABLE ONLY public.oyun_kullanici
    ADD CONSTRAINT oyun_kullanici_oyun_id_fkey FOREIGN KEY (oyun_id) REFERENCES public.oyun(oyun_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyun_kullanici
    ADD CONSTRAINT oyun_kullanici_oyuncu_id_fkey FOREIGN KEY (oyuncu_id) REFERENCES public.oyuncu(oyuncu_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.oyuncu
    ADD CONSTRAINT oyuncu_oyuncu_id_fkey FOREIGN KEY (oyuncu_id) REFERENCES public.hesap(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.sepet
    ADD CONSTRAINT sepet_oyun_id_fkey FOREIGN KEY (oyun_id) REFERENCES public.oyun(oyun_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.sepet
    ADD CONSTRAINT sepet_oyuncu_id_fkey FOREIGN KEY (oyuncu_id) REFERENCES public.oyuncu(oyuncu_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.siparis_detay
    ADD CONSTRAINT siparis_detay_oyun_id_fkey FOREIGN KEY (oyun_id) REFERENCES public.oyun(oyun_id);
ALTER TABLE ONLY public.siparis_detay
    ADD CONSTRAINT siparis_detay_siparis_id_fkey FOREIGN KEY (siparis_id) REFERENCES public.siparis(siparis_id) ON DELETE CASCADE;
ALTER TABLE ONLY public.siparis
    ADD CONSTRAINT siparis_oyuncu_id_fkey FOREIGN KEY (oyuncu_id) REFERENCES public.oyuncu(oyuncu_id);
