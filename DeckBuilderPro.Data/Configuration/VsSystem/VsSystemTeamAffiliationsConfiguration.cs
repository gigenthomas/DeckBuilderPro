using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    public class VsSystemTeamAffiliationsConfiguration : EntityTypeConfiguration<VsSystemTeamAffiliation>
    {
        public VsSystemTeamAffiliationsConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TeamAffiliations", schemaName: "VsSystem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
