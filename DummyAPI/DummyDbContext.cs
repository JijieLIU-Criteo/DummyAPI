using System;
using DummyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyAPI
{
    public class DummyDbContext : DbContext
    {
        public DummyDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}

