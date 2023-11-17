using AbacProjectBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbacProjectBackend.Configuration
{
    public class ExplorerConfiguration : IEntityTypeConfiguration<Explorer>
    {
        public void Configure(EntityTypeBuilder<Explorer> builder)
        {
            builder.ToTable("Explorer");
            builder.HasData
            (
                //captains
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Type = ExplorerType.Captain
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "Samuel Smith",
                    Type = ExplorerType.Captain
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "Patric Wayne",
                    Type = ExplorerType.Captain
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "Mike Perry",
                    Type = ExplorerType.Captain
                },
                //robots
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T9",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T6",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T12",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T14",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T19",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T23",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T28",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T88",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T67",
                    Type = ExplorerType.Robot
                },
                new Explorer
                {
                    Id = Guid.NewGuid(),
                    Name = "T59",
                    Type = ExplorerType.Robot
                }
            );
        }
    }
}
