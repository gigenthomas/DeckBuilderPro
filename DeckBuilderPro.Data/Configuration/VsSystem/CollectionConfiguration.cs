using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Data.Configuration.VsSystem
{
    public class CollectionConfiguration : EntityTypeConfiguration<Collection>
    {
        public CollectionConfiguration()
        {

            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("Collections", schemaName: "VsSystem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.VsSystemCollections)
                .HasForeignKey(d => d.UserId);


        }
    }
}
