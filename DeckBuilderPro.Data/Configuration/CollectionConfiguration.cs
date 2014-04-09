using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DeckBuilderPro.Data.Configuration
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
            this.ToTable("Collections");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.GameId).HasColumnName("GameId");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Collections)
                .HasForeignKey(d => d.GameId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Collections)
                .HasForeignKey(d => d.UserId);


        }
    }
}
