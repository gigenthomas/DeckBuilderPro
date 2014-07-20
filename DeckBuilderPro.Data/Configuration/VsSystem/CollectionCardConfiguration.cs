using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    class CollectionCardConfiguration : EntityTypeConfiguration<CollectionCard>
    {
        public CollectionCardConfiguration()
        {
            this.ToTable("CardsToCollection");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CardId).HasColumnName("CardId");
            this.Property(t => t.CollectionId).HasColumnName("CollectionId");
            this.Property(t => t.CardCount).HasColumnName("CardCount");
            this.Property(t => t.CardsInDecks).HasColumnName("InDecks");

            this.HasRequired(t => t.Card)
                .WithMany(t => t.CardsInCollection)
                .HasForeignKey(d => d.CardId);

            this.HasRequired(t => t.Collection)
                .WithMany(t => t.CardsInCollection)
                .HasForeignKey(d => d.CollectionId);
        }

    }
}
