using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckBuilderPro.Data.Configuration
{
    //public class VsSystem_CardAttributesMap : EntityTypeConfiguration<VsSystem_CardAttributes>
    //{
    //    public VsSystem_CardAttributesMap()
    //    {
    //        // Primary Key
    //        this.HasKey(t => new { t.CardId, t.Version, t.Cost, t.Attack, t.Defense, t.HasFlight, t.HasRange, t.IsOngoing, t.RarityId });

    //        // Properties
    //        this.Property(t => t.CardId)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

    //        this.Property(t => t.Version)
    //            .IsRequired()
    //            .HasMaxLength(255);

    //        this.Property(t => t.Cost)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

    //        this.Property(t => t.Attack)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

    //        this.Property(t => t.Defense)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

    //        this.Property(t => t.RarityId)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

    //        // Table & Column Mappings
    //        this.ToTable("VsSystem_CardAttributes");
    //        this.Property(t => t.CardId).HasColumnName("CardId");
    //        this.Property(t => t.Version).HasColumnName("Version");
    //        this.Property(t => t.Cost).HasColumnName("Cost");
    //        this.Property(t => t.Attack).HasColumnName("Attack");
    //        this.Property(t => t.Defense).HasColumnName("Defense");
    //        this.Property(t => t.HasFlight).HasColumnName("HasFlight");
    //        this.Property(t => t.HasRange).HasColumnName("HasRange");
    //        this.Property(t => t.IsOngoing).HasColumnName("IsOngoing");
    //        this.Property(t => t.RarityId).HasColumnName("RarityId");

    //        // Relationships
    //        this.HasRequired(t => t.Card)
    //            .WithMany(t => t.VsSystem_CardAttributes)
    //            .HasForeignKey(d => d.CardId);
    //        this.HasRequired(t => t.CardRarity)
    //            .WithMany(t => t.VsSystem_CardAttributes)
    //            .HasForeignKey(d => d.RarityId);

    //    }
    //}
}
