using Dnc.Staff.Data.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace Dnc.Staff.Data.Models.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects", "dbo");

            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity<EmployeeProject>(
                left => left.HasOne<Employee>().WithMany().HasForeignKey(e => e.EmployeeId),
                right => right.HasOne<Project>().WithMany().HasForeignKey(e => e.ProjectId));
        }
    }
}
