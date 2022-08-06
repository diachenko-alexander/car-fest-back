using CarFest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarFest.DAL.Configurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure (EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("AspNetUsers");
            builder
                .HasMany(t => t.Cars)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
