using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace amazing_api.Models;

public partial class HsrContext : DbContext
{
    public HsrContext()
    {
    }

    public HsrContext(DbContextOptions<HsrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExistRelic> ExistRelics { get; set; }

    public virtual DbSet<ExistRelicStatus> ExistRelicStatuses { get; set; }

    public virtual DbSet<RelicAvailabilityStat> RelicAvailabilityStats { get; set; }

    public virtual DbSet<RelicItem> RelicItems { get; set; }

    public virtual DbSet<RelicItemPhoto> RelicItemPhotos { get; set; }

    public virtual DbSet<RelicLevelExp> RelicLevelExps { get; set; }

    public virtual DbSet<RelicMainValue> RelicMainValues { get; set; }

    public virtual DbSet<RelicRarity> RelicRarities { get; set; }

    public virtual DbSet<RelicSection> RelicSections { get; set; }

    public virtual DbSet<RelicStat> RelicStats { get; set; }

    public virtual DbSet<RelicSubValue> RelicSubValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Samsibsi;Database=HSR;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExistRelic>(entity =>
        {
            entity.ToTable("exist_relic");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.RelicId).HasColumnName("relic_id");
            entity.Property(e => e.RelicItenId).HasColumnName("relic_iten_id");
            entity.Property(e => e.RelicPhotoId).HasColumnName("relic_photo_id");
            entity.Property(e => e.RelicRarityId).HasColumnName("relic_rarity_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.Usable).HasColumnName("usable");
        });

        modelBuilder.Entity<ExistRelicStatus>(entity =>
        {
            entity.ToTable("exist_relic_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("create_date");
            entity.Property(e => e.ExistRelicId).HasColumnName("exist_relic_id");
            entity.Property(e => e.RelicStatId).HasColumnName("relic_stat_id");
            entity.Property(e => e.StatType).HasColumnName("stat_type");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("update_date");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<RelicAvailabilityStat>(entity =>
        {
            entity.ToTable("relic_availability_stat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.RelicId).HasColumnName("relic_id");
            entity.Property(e => e.RelicStatId).HasColumnName("relic_stat_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.Usable).HasColumnName("usable");
        });

        modelBuilder.Entity<RelicItem>(entity =>
        {
            entity.ToTable("relic_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(5)
                .HasColumnName("item_code");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(500)
                .HasColumnName("item_description");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .HasColumnName("item_name");
            entity.Property(e => e.RelicId).HasColumnName("relic_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<RelicItemPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_unique");

            entity.ToTable("relic_item_photo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.RelicItemId).HasColumnName("relic_item_id");
            entity.Property(e => e.RelicLinkPhoto).HasColumnName("relic_link_photo");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.Usable).HasColumnName("usable");
        });

        modelBuilder.Entity<RelicLevelExp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_relic_level_exp_2");

            entity.ToTable("relic_level_exp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CurrentLevel).HasColumnName("current_level");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.RelicRarityId).HasColumnName("relic_rarity_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<RelicMainValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_3");

            entity.ToTable("relic_main_value");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Base).HasColumnName("base");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.MaxValue).HasColumnName("max_value");
            entity.Property(e => e.PerLevel).HasColumnName("per_level");
            entity.Property(e => e.RelicRarityId).HasColumnName("relic_rarity_id");
            entity.Property(e => e.RelicStatId).HasColumnName("relic_stat_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<RelicRarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_relic_rarity_2");

            entity.ToTable("relic_rarity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.MaxLevel).HasColumnName("max_level");
            entity.Property(e => e.MaxSubStat).HasColumnName("max_sub_stat");
            entity.Property(e => e.MinSubStat).HasColumnName("min_sub_stat");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Percent).HasColumnName("percent");
            entity.Property(e => e.RarityName)
                .HasMaxLength(50)
                .HasColumnName("rarity_name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<RelicSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_relic");

            entity.ToTable("relic_section");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.RelicName)
                .HasMaxLength(50)
                .HasColumnName("relic_name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.Useable).HasColumnName("useable");
        });

        modelBuilder.Entity<RelicStat>(entity =>
        {
            entity.ToTable("relic_stat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DateType)
                .HasMaxLength(50)
                .HasColumnName("date_type");
            entity.Property(e => e.StatName)
                .HasMaxLength(50)
                .HasColumnName("stat_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(5)
                .HasColumnName("unit");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.Usable).HasColumnName("usable");
        });

        modelBuilder.Entity<RelicSubValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_relic_sub_value_3");

            entity.ToTable("relic_sub_value");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("create_date");
            entity.Property(e => e.RelicRarityId).HasColumnName("relic_rarity_id");
            entity.Property(e => e.RelicStatId).HasColumnName("relic_stat_id");
            entity.Property(e => e.Step)
                .HasMaxLength(5)
                .HasColumnName("step");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("update_date");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
