﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;

namespace mrs.Infrastructure.Data.Mapping
{
    public class ProjectionMap : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            //Primary Key
            builder.HasKey(p => p.Id);
            //Properties
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("ProjectionId").IsRequired();
            builder.Property(p => p.ProjectionName).HasColumnName("ProjectionName").IsUnicode().IsRequired();
            builder.Property(p => p.ActorId).HasColumnName("ActorId").IsRequired();
            builder.Property(p => p.GenreId).HasColumnName("GenreId").IsRequired();
            builder.Property(p => p.ProducerName).HasColumnName("ProducerName").IsRequired();
            //Relations
            builder.HasOne(p => p.Actor)
               .WithMany(a => a.Projections)
               .HasForeignKey(p => p.ActorId);

            builder.HasOne(p => p.Genre)
                .WithMany(g => g.Projections)
                .HasForeignKey(p => p.GenreId);

            //Table
            builder.ToTable("Projections");
        }
    }
}
