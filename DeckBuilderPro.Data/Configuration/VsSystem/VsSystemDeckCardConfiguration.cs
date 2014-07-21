using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    class VsSystemDeckCardConfiguration : EntityTypeConfiguration<VsSystemDeckCard>
    {
        public VsSystemDeckCardConfiguration()
        {

            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CardsToDeck", schemaName: "VsSystem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CardId).HasColumnName("CardId");
            this.Property(t => t.DeckId).HasColumnName("DeckId");
            this.Property(t => t.CardCount).HasColumnName("CardCount");
            this.Property(t => t.CardsFromCollection).HasColumnName("FromCollection");

            // Relationships
            this.HasRequired(t => t.Card)
                .WithMany(t => t.CardsInDeck)
                .HasForeignKey(d => d.CardId);
            this.HasRequired(t => t.Deck)
            .WithMany(t => t.CardsInDeck)
            .HasForeignKey(d => d.DeckId);


        }
    }

}
