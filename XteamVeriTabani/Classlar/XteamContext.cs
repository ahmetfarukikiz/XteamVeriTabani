using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XteamVeriTabani.Models;

public partial class XteamContext : DbContext
{
    public XteamContext()
    {
    }

    public XteamContext(DbContextOptions<XteamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arkadaslik> Arkadasliks { get; set; }

    public virtual DbSet<ArkadaslikDurum> ArkadaslikDurums { get; set; }

    public virtual DbSet<Dil> Dils { get; set; }

    public virtual DbSet<Gelistirici> Gelistiricis { get; set; }

    public virtual DbSet<Hesap> Hesaps { get; set; }

    public virtual DbSet<Kampanya> Kampanyas { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Oyun> Oyuns { get; set; }

    public virtual DbSet<OyunDil> OyunDils { get; set; }

    public virtual DbSet<OyunDurumu> OyunDurumus { get; set; }

    public virtual DbSet<OyunKullanici> OyunKullanicis { get; set; }

    public virtual DbSet<Oyuncu> Oyuncus { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<Sipari> Siparis { get; set; }

    public virtual DbSet<SiparisDetay> SiparisDetays { get; set; }

    public virtual DbSet<Yorum> Yorums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Xteam;Username=postgres;Password=Sabisilteris68254-");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arkadaslik>(entity =>
        {
            entity.HasKey(e => new { e.IstekGonderenId, e.IstekAlanId }).HasName("arkadaslik_pkey");

            entity.ToTable("arkadaslik");

            entity.Property(e => e.IstekGonderenId).HasColumnName("istek_gonderen_id");
            entity.Property(e => e.IstekAlanId).HasColumnName("istek_alan_id");
            entity.Property(e => e.ArkadaslikTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("arkadaslik_tarihi");
            entity.Property(e => e.DurumId).HasColumnName("durum_id");

            entity.HasOne(d => d.Durum).WithMany(p => p.Arkadasliks)
                .HasForeignKey(d => d.DurumId)
                .HasConstraintName("arkadaslik_durum_id_fkey");

            entity.HasOne(d => d.IstekAlan).WithMany(p => p.ArkadaslikIstekAlans)
                .HasForeignKey(d => d.IstekAlanId)
                .HasConstraintName("arkadaslik_istek_alan_id_fkey");

            entity.HasOne(d => d.IstekGonderen).WithMany(p => p.ArkadaslikIstekGonderens)
                .HasForeignKey(d => d.IstekGonderenId)
                .HasConstraintName("arkadaslik_istek_gonderen_id_fkey");
        });

        modelBuilder.Entity<ArkadaslikDurum>(entity =>
        {
            entity.HasKey(e => e.DurumId).HasName("arkadaslik_durum_pkey");

            entity.ToTable("arkadaslik_durum");

            entity.Property(e => e.DurumId)
                .ValueGeneratedNever()
                .HasColumnName("durum_id");
            entity.Property(e => e.DurumAdi)
                .HasMaxLength(20)
                .HasColumnName("durum_adi");
        });

        modelBuilder.Entity<Dil>(entity =>
        {
            entity.HasKey(e => e.DilId).HasName("dil_pkey");

            entity.ToTable("dil");

            entity.Property(e => e.DilId).HasColumnName("dil_id");
            entity.Property(e => e.DilAdi)
                .HasMaxLength(30)
                .HasColumnName("dil_adi");
        });

        modelBuilder.Entity<Gelistirici>(entity =>
        {
            entity.HasKey(e => e.GelistiriciId).HasName("gelistirici_pkey");

            entity.ToTable("gelistirici");

            entity.Property(e => e.GelistiriciId)
                .ValueGeneratedNever()
                .HasColumnName("gelistirici_id");
            entity.Property(e => e.VergiNo)
                .HasMaxLength(20)
                .HasColumnName("vergi_no");
            entity.Property(e => e.WebSitesi)
                .HasMaxLength(100)
                .HasColumnName("web_sitesi");

            entity.HasOne(d => d.GelistiriciNavigation).WithOne(p => p.Gelistirici)
                .HasForeignKey<Gelistirici>(d => d.GelistiriciId)
                .HasConstraintName("gelistirici_gelistirici_id_fkey");
        });

        modelBuilder.Entity<Hesap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hesap_pkey");

            entity.ToTable("hesap");

            entity.HasIndex(e => e.Eposta, "hesap_eposta_key").IsUnique();

            entity.HasIndex(e => e.KullaniciAdi, "hesap_kullanici_adi_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eposta)
                .HasMaxLength(50)
                .HasColumnName("eposta");
            entity.Property(e => e.HesapAdi)
                .HasMaxLength(50)
                .HasColumnName("hesap_adi");
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("kayit_tarihi");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(50)
                .HasColumnName("kullanici_adi");
            entity.Property(e => e.Sifre)
                .HasMaxLength(255)
                .HasColumnName("sifre");
            entity.Property(e => e.SonGiris)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("son_giris");
        });

        modelBuilder.Entity<Kampanya>(entity =>
        {
            entity.HasKey(e => e.KampanyaId).HasName("kampanya_pkey");

            entity.ToTable("kampanya");

            entity.Property(e => e.KampanyaId).HasColumnName("kampanya_id");
            entity.Property(e => e.AktifMi)
                .HasDefaultValue(true)
                .HasColumnName("aktif_mi");
            entity.Property(e => e.BaslangicTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("baslangic_tarihi");
            entity.Property(e => e.Baslik)
                .HasMaxLength(100)
                .HasColumnName("baslik");
            entity.Property(e => e.BitisTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bitis_tarihi");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("kategori_pkey");

            entity.ToTable("kategori");

            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.TurAdi)
                .HasMaxLength(50)
                .HasColumnName("tur_adi");
        });

        modelBuilder.Entity<Oyun>(entity =>
        {
            entity.HasKey(e => e.OyunId).HasName("oyun_pkey");

            entity.ToTable("oyun");

            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Baslik)
                .HasMaxLength(100)
                .HasColumnName("baslik");
            entity.Property(e => e.CikisTarihi).HasColumnName("cikis_tarihi");
            entity.Property(e => e.Fiyat)
                .HasPrecision(10, 2)
                .HasColumnName("fiyat");
            entity.Property(e => e.GelistiriciId).HasColumnName("gelistirici_id");
            entity.Property(e => e.IndirilmeSayisi)
                .HasDefaultValue(0)
                .HasColumnName("indirilme_sayisi");
            entity.Property(e => e.KampanyaId).HasColumnName("kampanya_id");
            entity.Property(e => e.YuklemeBoyutu).HasColumnName("yukleme_boyutu");

            entity.HasOne(d => d.Gelistirici).WithMany(p => p.Oyuns)
                .HasForeignKey(d => d.GelistiriciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("oyun_gelistirici_id_fkey");

            entity.HasOne(d => d.Kampanya).WithMany(p => p.Oyuns)
                .HasForeignKey(d => d.KampanyaId)
                .HasConstraintName("oyun_kampanya_id_fkey");

            entity.HasMany(d => d.Kategoris).WithMany(p => p.Oyuns)
                .UsingEntity<Dictionary<string, object>>(
                    "OyunKategori",
                    r => r.HasOne<Kategori>().WithMany()
                        .HasForeignKey("KategoriId")
                        .HasConstraintName("oyun_kategori_kategori_id_fkey"),
                    l => l.HasOne<Oyun>().WithMany()
                        .HasForeignKey("OyunId")
                        .HasConstraintName("oyun_kategori_oyun_id_fkey"),
                    j =>
                    {
                        j.HasKey("OyunId", "KategoriId").HasName("oyun_kategori_pkey");
                        j.ToTable("oyun_kategori");
                        j.IndexerProperty<int>("OyunId").HasColumnName("oyun_id");
                        j.IndexerProperty<int>("KategoriId").HasColumnName("kategori_id");
                    });
        });

        modelBuilder.Entity<OyunDil>(entity =>
        {
            entity.HasKey(e => new { e.OyunId, e.DilId }).HasName("oyun_dil_pkey");

            entity.ToTable("oyun_dil");

            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.DilId).HasColumnName("dil_id");
            entity.Property(e => e.AltyaziVarMi)
                .HasDefaultValue(false)
                .HasColumnName("altyazi_var_mi");
            entity.Property(e => e.SeslendirmeVarMi)
                .HasDefaultValue(false)
                .HasColumnName("seslendirme_var_mi");

            entity.HasOne(d => d.Dil).WithMany(p => p.OyunDils)
                .HasForeignKey(d => d.DilId)
                .HasConstraintName("oyun_dil_dil_id_fkey");

            entity.HasOne(d => d.Oyun).WithMany(p => p.OyunDils)
                .HasForeignKey(d => d.OyunId)
                .HasConstraintName("oyun_dil_oyun_id_fkey");
        });

        modelBuilder.Entity<OyunDurumu>(entity =>
        {
            entity.HasKey(e => e.DurumId).HasName("oyun_durumu_pkey");

            entity.ToTable("oyun_durumu");

            entity.Property(e => e.DurumId)
                .ValueGeneratedNever()
                .HasColumnName("durum_id");
            entity.Property(e => e.DurumAdi)
                .HasMaxLength(20)
                .HasColumnName("durum_adi");
        });

        modelBuilder.Entity<OyunKullanici>(entity =>
        {
            entity.HasKey(e => new { e.OyuncuId, e.OyunId }).HasName("oyun_kullanici_pkey");

            entity.ToTable("oyun_kullanici");

            entity.Property(e => e.OyuncuId).HasColumnName("oyuncu_id");
            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.AlinmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("alinma_tarihi");
            entity.Property(e => e.DurumId).HasColumnName("durum_id");
            entity.Property(e => e.OynamaSuresi)
                .HasDefaultValue(0)
                .HasColumnName("oynama_suresi");

            entity.HasOne(d => d.Durum).WithMany(p => p.OyunKullanicis)
                .HasForeignKey(d => d.DurumId)
                .HasConstraintName("oyun_kullanici_durum_id_fkey");

            entity.HasOne(d => d.Oyun).WithMany(p => p.OyunKullanicis)
                .HasForeignKey(d => d.OyunId)
                .HasConstraintName("oyun_kullanici_oyun_id_fkey");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.OyunKullanicis)
                .HasForeignKey(d => d.OyuncuId)
                .HasConstraintName("oyun_kullanici_oyuncu_id_fkey");
        });

        modelBuilder.Entity<Oyuncu>(entity =>
        {
            entity.HasKey(e => e.OyuncuId).HasName("oyuncu_pkey");

            entity.ToTable("oyuncu");

            entity.Property(e => e.OyuncuId)
                .ValueGeneratedNever()
                .HasColumnName("oyuncu_id");
            entity.Property(e => e.CuzdanBakiyesi)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("cuzdan_bakiyesi");
            entity.Property(e => e.Seviye)
                .HasDefaultValue(1)
                .HasColumnName("seviye");

            entity.HasOne(d => d.OyuncuNavigation).WithOne(p => p.Oyuncu)
                .HasForeignKey<Oyuncu>(d => d.OyuncuId)
                .HasConstraintName("oyuncu_oyuncu_id_fkey");
        });

        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.HasKey(e => e.SepetId).HasName("sepet_pkey");

            entity.ToTable("sepet");

            entity.HasIndex(e => new { e.OyuncuId, e.OyunId }, "sepet_oyuncu_id_oyun_id_key").IsUnique();

            entity.Property(e => e.SepetId).HasColumnName("sepet_id");
            entity.Property(e => e.EklenmeTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("eklenme_tarihi");
            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.OyuncuId).HasColumnName("oyuncu_id");

            entity.HasOne(d => d.Oyun).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.OyunId)
                .HasConstraintName("sepet_oyun_id_fkey");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.OyuncuId)
                .HasConstraintName("sepet_oyuncu_id_fkey");
        });

        modelBuilder.Entity<Sipari>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("siparis_pkey");

            entity.ToTable("siparis");

            entity.Property(e => e.SiparisId).HasColumnName("siparis_id");
            entity.Property(e => e.OyuncuId).HasColumnName("oyuncu_id");
            entity.Property(e => e.SiparisTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("siparis_tarihi");
            entity.Property(e => e.ToplamTutar)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("toplam_tutar");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.OyuncuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("siparis_oyuncu_id_fkey");
        });

        modelBuilder.Entity<SiparisDetay>(entity =>
        {
            entity.HasKey(e => e.DetayId).HasName("siparis_detay_pkey");

            entity.ToTable("siparis_detay");

            entity.Property(e => e.DetayId).HasColumnName("detay_id");
            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.SatisFiyati)
                .HasPrecision(10, 2)
                .HasColumnName("satis_fiyati");
            entity.Property(e => e.SiparisId).HasColumnName("siparis_id");

            entity.HasOne(d => d.Oyun).WithMany(p => p.SiparisDetays)
                .HasForeignKey(d => d.OyunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("siparis_detay_oyun_id_fkey");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetays)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("siparis_detay_siparis_id_fkey");
        });

        modelBuilder.Entity<Yorum>(entity =>
        {
            entity.HasKey(e => e.YorumId).HasName("yorum_pkey");

            entity.ToTable("yorum");

            entity.Property(e => e.YorumId).HasColumnName("yorum_id");
            entity.Property(e => e.OyunId).HasColumnName("oyun_id");
            entity.Property(e => e.OyuncuId).HasColumnName("oyuncu_id");
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tarih");
            entity.Property(e => e.YorumMetni).HasColumnName("yorum_metni");

            entity.HasOne(d => d.Oyun).WithMany(p => p.Yorums)
                .HasForeignKey(d => d.OyunId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("yorum_oyun_id_fkey");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.Yorums)
                .HasForeignKey(d => d.OyuncuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("yorum_oyuncu_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
