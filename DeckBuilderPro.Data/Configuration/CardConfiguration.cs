using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    public class CardConfiguration : EntityTypeConfiguration<Card>
    {
        public CardConfiguration()
        {
            ToTable("Cards");
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardIdentifier)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CardTypeId).HasColumnName("CardTypeId");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.CardIdentifier).HasColumnName("CardIdentifier");
            this.Property(t => t.IsReprint).HasColumnName("IsReprint");

            // Relationships
            this.HasMany(t => t.GameSets)
                .WithMany(t => t.Cards)
                .Map(m =>
                    {
                        m.ToTable("CardsToGameSetsMapping");
                        m.MapLeftKey("CardId");
                        m.MapRightKey("GameSetId");
                    });

            this.HasRequired(t => t.CardType)
                .WithMany(t => t.Cards)
                .HasForeignKey(d => d.CardTypeId);
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Cards)
                .HasForeignKey(d => d.GameId);
        }
    }
}
