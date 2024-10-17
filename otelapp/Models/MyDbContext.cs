using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace otelapp.Models 
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyEntity> KiralikOteller { get; set; }
        public DbSet<KiralananOtel> KiralananOteller { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string OtelMetin { get; set; }
        public string OtelGorsel { get; set; }
        public string OtelFiyat { get; set; }
    }


    public class KiralananOtel
    {
        public int Id { get; set; }
        public int KiralananOtelId { get; set; }
        public string KiralananOtelMetin { get; set; }
        public string KiralananOtelGorsel { get; set; }
    }
}
