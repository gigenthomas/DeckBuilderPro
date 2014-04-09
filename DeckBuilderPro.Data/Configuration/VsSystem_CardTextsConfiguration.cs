using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckBuilderPro.Data.Configuration
{
    public class VsSystem_CardTextsConfiguration : EntityTypeConfiguration<VsSystem_CardText>
    {
        public VsSystem_CardTextsConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.CardId, t.RulesText, t.FlavourText });

            // Properties
            this.Property(t => t.CardId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RulesText)
                .IsRequired();

            this.Property(t => t.FlavourText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("VsSystem_CardTexts");
            this.Property(t => t.CardId).HasColumnName("CardId");
            this.Property(t => t.RulesText).HasColumnName("RulesText");
            this.Property(t => t.FlavourText).HasColumnName("FlavourText");

            // Relationships
            this.HasRequired(t => t.VsSystem_Card)
                .WithMany(t => t.VsSystem_CardText)
                .HasForeignKey(d => d.CardId);
        }
    }
}
