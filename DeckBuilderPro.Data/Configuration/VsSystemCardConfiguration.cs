using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    public class VsSystemCardConfiguration : EntityTypeConfiguration<VsSystem_Card>
    {
        public VsSystemCardConfiguration()
        {

            // Table & Column Mappings
            this.ToTable("VsSystem_Cards");
            this.Property(t => t.Id).HasColumnName("CardId");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Attack).HasColumnName("Attack");
            this.Property(t => t.Defense).HasColumnName("Defense");
            this.Property(t => t.HasFlight).HasColumnName("HasFlight");
            this.Property(t => t.HasRange).HasColumnName("HasRange");
            this.Property(t => t.IsOngoing).HasColumnName("IsOngoing");
            this.Property(t => t.RarityId).HasColumnName("RarityId");

            // Relationships
            this.HasMany(t => t.VsSystem_TeamAffiliations)
                .WithMany(t => t.VsSystem_Cards)
                .Map(m =>
                {
                    m.ToTable("VsSystem_CardToAffiliationsMapping");
                    m.MapLeftKey("CardId");
                    m.MapRightKey("AffiliationId");
                });

            this.HasRequired(t => t.CardRarity)
                .WithMany(t => t.VsSystem_Cards)
                .HasForeignKey(d => d.RarityId);


        }
    }
}
