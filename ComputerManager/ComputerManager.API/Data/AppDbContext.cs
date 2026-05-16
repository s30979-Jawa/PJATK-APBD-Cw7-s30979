using Microsoft.EntityFrameworkCore;
using ComputerManager.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComputerManager.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PcComponent>()
            .HasKey(pc => new { pc.PcId, pc.ComponentCode });

        //comp type
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );

        //comp manu
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer {Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1)},
            new ComponentManufacturer {Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5)},
            new ComponentManufacturer {Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateOnly(1994, 1, 1)}
        );
        
        //pc
        modelBuilder.Entity<Pc>().HasData(
            new Pc {Id = 1, Name = "Komputer1", Weight = 50, Warranty = 5, CreatedAt = new DateTime(2025, 5, 5, 9, 0, 0), Stock = 1},
            new Pc {Id = 2, Name = "Stary Komputer", Weight = 700, Warranty = 1, CreatedAt = new DateTime(1999, 2, 12, 7, 3, 12), Stock = 12},
            new Pc {Id = 3, Name = "Nowy Komputer", Weight = 900, Warranty = 20, CreatedAt = new DateTime(2014, 8, 12, 17, 32, 45), Stock = 5}
        );

        //comp
        modelBuilder.Entity<Component>().HasData(
            new Component {Code = "GPU0000001", Name = "GjePeUu", Description = "To jest GPU", ComponentManufacturerId = 2, ComponentTypeId = 2},
            new Component {Code = "CPU9999999", Name = "Super Duper Processor", Description = "To jest CPU", ComponentManufacturerId = 1, ComponentTypeId = 1},
            new Component {Code = "RAM1234567", Name = "Osiem Bajtow", Description = "To jest RAM", ComponentManufacturerId = 3, ComponentTypeId = 3}
        );

        //PcComp
        modelBuilder.Entity<PcComponent>().HasData(
            new PcComponent {Amount = 30, ComponentCode = "RAM1234567", PcId = 3},
            new PcComponent {Amount = 20, ComponentCode = "CPU9999999", PcId = 2},
            new PcComponent {Amount = 10, ComponentCode = "GPU0000001", PcId = 1}
        );
    }
    
}