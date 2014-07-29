using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    public class VsSystemCardTextsConfiguration : EntityTypeConfiguration<VsSystemCardText>
    {
        public VsSystemCardTextsConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.RulesText, t.FlavourText });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RulesText)
                .IsRequired();

            this.Property(t => t.FlavourText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CardTexts", schemaName: "VsSystem");
            this.Property(t => t.Id).HasColumnName("CardId");
            this.Property(t => t.RulesText).HasColumnName("RulesText");
            this.Property(t => t.FlavourText).HasColumnName("FlavourText");

            // Relationships
            this.HasRequired(t => t.Card)
                .WithMany(t => t.CardText)
                .HasForeignKey(d => d.Id);
        }
    }
}
