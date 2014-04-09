using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Data.Configuration
{
    public class VsSystem_TeamAffiliationConfiguration : EntityTypeConfiguration<VsSystem_TeamAffiliation>
    {
        public VsSystem_TeamAffiliationConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VsSystem_TeamAffiliation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
