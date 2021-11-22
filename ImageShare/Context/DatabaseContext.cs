using ImageShare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        public DbSet<ImageUploaded> Images { get; set; }

        public DbSet<Shared> Shared { get; set; }
    }
}
