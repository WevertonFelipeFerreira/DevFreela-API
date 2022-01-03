﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Freelancer)
                .WithMany(x => x.FreelanceProjects)
                .HasForeignKey(x => x.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(x => x.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
