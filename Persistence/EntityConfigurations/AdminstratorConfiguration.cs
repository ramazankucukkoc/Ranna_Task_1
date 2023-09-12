using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations
{
    public class AdminstratorConfiguration : IEntityTypeConfiguration<Adminstrator>
    {
        public void Configure(EntityTypeBuilder<Adminstrator> builder)
        {
            builder.ToTable("Adminstrators").HasKey(o => o.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.HasIndex(c => c.Name, "UK_Adminstrators_Name").IsUnique();
        }
    }
}
