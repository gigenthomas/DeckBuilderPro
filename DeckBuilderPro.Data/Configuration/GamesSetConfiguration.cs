using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    class GamesSetConfiguration : EntityTypeConfiguration<GameSet>
    {
        public GamesSetConfiguration()
        {
                        // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SetIdentifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GameSets");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.NumberOfCards).HasColumnName("NumberOfCards");
            this.Property(t => t.HasSetIdentifier).HasColumnName("HasSetIdentifier");
            this.Property(t => t.SetIdentifier).HasColumnName("SetIdentifier");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.GameSets)
                .HasForeignKey(d => d.GameId);

        }
    }
}
