using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    public class VsSystemCardConfiguration : EntityTypeConfiguration<VsSystemCard>
    {
        public VsSystemCardConfiguration()
        {
            ToTable("Cards", schemaName: "VsSystem");
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
            this.Property(t => t.CardIdentifier).HasColumnName("CardIdentifier");
            this.Property(t => t.IsReprint).HasColumnName("IsReprint");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Attack).HasColumnName("Attack");
            this.Property(t => t.Defense).HasColumnName("Defense");
            this.Property(t => t.HasFlight).HasColumnName("HasFlight");
            this.Property(t => t.HasRange).HasColumnName("HasRange");
            this.Property(t => t.IsOngoing).HasColumnName("IsOngoing");
            this.Property(t => t.RarityId).HasColumnName("RarityId");

            this.HasRequired(t => t.CardType)
                .WithMany(t => t.Cards)
                .HasForeignKey(d => d.CardTypeId);


            // Relationships
            this.HasMany(t => t.TeamAffiliations)
                .WithMany(t => t.Cards)
                .Map(m =>
                {
                    m.ToTable("CardToAffiliationsMapping", schemaName: "VsSystem");
                    m.MapLeftKey("CardId");
                    m.MapRightKey("TeamAffiliationId");
                });

            this.HasRequired(t => t.CardRarity)
                .WithMany(t => t.Cards)
                .HasForeignKey(d => d.RarityId);


        }
    }

}
