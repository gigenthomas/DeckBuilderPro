using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    class DeckConfiguration : EntityTypeConfiguration<Deck>
    {
        public DeckConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("Decks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CardCount).HasColumnName("CardCount");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.FormatId).HasColumnName("FormatId");

            // Relationships
            this.HasOptional(t => t.Format)
                .WithMany(t => t.Decks)
                .HasForeignKey(d => d.FormatId);
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Decks)
                .HasForeignKey(d => d.GameId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Decks)
                .HasForeignKey(d => d.UserId);
        }
    }
}
