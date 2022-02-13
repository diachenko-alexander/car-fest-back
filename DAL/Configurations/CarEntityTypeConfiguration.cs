using CarFest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFest.DAL.Configurations
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure (EntityTypeBuilder<Car> builder)
        {
            builder
                .ToTable("Cars");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(500)
                .IsRequired();
            builder
                .Property(x => x.Model)
                .HasColumnName("Model")
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasColumnName("Price")
                .IsRequired();

        }
    }
}
