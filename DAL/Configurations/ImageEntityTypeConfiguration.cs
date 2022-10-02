using CarFest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFest.DAL.Configurations
{
    class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .ToTable("Images");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.ImageTitle)
                .HasColumnName("ImageTitle");
            builder
                .Property(x => x.IsMainImage)
                .HasColumnName("IsMainImage");
            builder
                .Property(x => x.ImageDate)
                .HasColumnName("ImageData")
                .HasColumnType("varbinary(max)");

        }
    }
}
