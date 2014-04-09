using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    class CardRarityConfiguration : EntityTypeConfiguration<CardRarity>
    {
        public CardRarityConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CardRarities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.CardRarities)
                .HasForeignKey(d => d.GameId);

        }
    }
}
