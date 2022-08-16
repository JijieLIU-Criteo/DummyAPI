using System;
using System.Linq;
using System.Threading.Tasks;
using DummyAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DummyAPI
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddTestData(service.GetRequiredService<DummyDbContext>());
        }

        public static async Task AddTestData(DummyDbContext context)
        {
            if (context.Rooms.Any())
                return;

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("DDE4BA55-808E-479F-BE8B-72F69913442F"),
                Name = "AAA",
                Rate = 12345
            });

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("DDE4BA55-808E-479F-BE8B-72F69913442E"),
                Name = "BBB",
                Rate = 98765
            });

            await context.SaveChangesAsync();
        }
    }
}

