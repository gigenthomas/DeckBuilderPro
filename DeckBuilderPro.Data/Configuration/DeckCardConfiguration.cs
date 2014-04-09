using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    class DeckCardConfiguration : EntityTypeConfiguration<DeckCard>
    {
        public DeckCardConfiguration()
        {

            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CardsToDeck");
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
