using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Models;

namespace BackendApp.Context
{
    public class AppDbContext : DbContext
    {
        // TO DO - move to config
        private static string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=BackendAppDB;Integrated Security=True";

        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceTypeProperty> DeviceTypeProperties { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly("BackendApp.DAL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceType>()
              .HasData(
                    new DeviceType { Id = 1, Name = "Racunar", ParentId = null },
                    new DeviceType { Id = 2, Name = "Laptop", ParentId = 1 },
                    new DeviceType { Id = 3, Name = "Tablet", ParentId = 2 }
                    );

            modelBuilder.Entity<DeviceTypeProperty>()
                .HasData(
                    new DeviceTypeProperty { Id = 1, DeviceTypeId = 1, Name = "OS" },
                    new DeviceTypeProperty { Id = 2, DeviceTypeId = 1, Name = "Memory" },
                    new DeviceTypeProperty { Id = 3, DeviceTypeId = 1, Name = "Processor" },
                    new DeviceTypeProperty { Id = 4, DeviceTypeId = 2, Name = "Diagonal" }
                    );

            modelBuilder.Entity<Device>()
                 .HasData(
                    new Device { Id = 1, Name = "Racunar 1", DeviceTypeId = 1 },
                    new Device { Id = 2, Name = "Laptop 1", DeviceTypeId = 2 },
                    new Device { Id = 3, Name = "Tablet 1", DeviceTypeId = 3 }
                    );

            modelBuilder.Entity<DevicePropertyValue>()
                .HasData(
                    new DevicePropertyValue { Id = 1, DeviceId = 1, DeviceTypePropertyId = 1, Value = "Windows 10" },
                    new DevicePropertyValue { Id = 2, DeviceId = 1, DeviceTypePropertyId = 2, Value = "16 GB" },
                    new DevicePropertyValue { Id = 3, DeviceId = 1, DeviceTypePropertyId = 3, Value = "Intel i5" },
                    new DevicePropertyValue { Id = 4, DeviceId = 2, DeviceTypePropertyId = 1, Value = "Windows 10" },
                    new DevicePropertyValue { Id = 5, DeviceId = 2, DeviceTypePropertyId = 2, Value = "8 GB" },
                    new DevicePropertyValue { Id = 6, DeviceId = 2, DeviceTypePropertyId = 3, Value = "Intel i3" },
                    new DevicePropertyValue { Id = 7, DeviceId = 2, DeviceTypePropertyId = 4, Value = "15.6" },
                    new DevicePropertyValue { Id = 8, DeviceId = 3, DeviceTypePropertyId = 1, Value = "Android 12" },
                    new DevicePropertyValue { Id = 9, DeviceId = 3, DeviceTypePropertyId = 2, Value = "2 GB" },
                    new DevicePropertyValue { Id = 10, DeviceId = 3, DeviceTypePropertyId = 3, Value = "Intel Atom" },
                    new DevicePropertyValue { Id = 11, DeviceId = 3, DeviceTypePropertyId = 4, Value = "10.1" }
                    );
        }
    }
}
