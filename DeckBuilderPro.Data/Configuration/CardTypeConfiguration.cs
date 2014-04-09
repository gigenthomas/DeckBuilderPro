using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    class CardTypeConfiguration : EntityTypeConfiguration<CardType>
    {
        public CardTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CardTypes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.CardTypes)
                .HasForeignKey(d => d.GameId);

        }
    }
}
