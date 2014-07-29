using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    class VsSystemDeckConfiguration : EntityTypeConfiguration<VsSystemDeck>
    {
        public VsSystemDeckConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("Decks", schemaName: "VsSystem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CardCount).HasColumnName("CardCount");
            this.Property(t => t.FormatId).HasColumnName("FormatId");

            // Relationships
            this.HasOptional(t => t.Format)
                .WithMany(t => t.Decks)
                .HasForeignKey(d => d.FormatId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.VsSystemDecks)
                .HasForeignKey(d => d.UserId);
        }
    }
}
