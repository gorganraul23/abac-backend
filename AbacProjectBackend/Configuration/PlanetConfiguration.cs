using AbacProjectBackend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AbacProjectBackend.Configuration
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.ToTable("Planet");
            builder.Property(s => s.Description)
                .HasDefaultValue("");
            builder.Property(s => s.Status)
                .HasDefaultValue(PlanetStatus.TODO);
            builder.HasData
            (
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Aka 47",
                    ImagePath = "planet1.png"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Zetta 4",
                    ImagePath = "planet3.jfif"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Sigma 17",
                    ImagePath = "planet4.jfif"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Xem 5",
                    ImagePath = "planet6.jfif"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Kes 2",
                    ImagePath = "planet1.png"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Zoro 1",
                    ImagePath = "planet3.jfif"
                },
                new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = "Tau 23",
                    ImagePath = "planet4.jfif"
                }
            );
        }
    }
}
