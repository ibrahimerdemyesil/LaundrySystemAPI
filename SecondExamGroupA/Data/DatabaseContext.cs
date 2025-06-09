using Microsoft.EntityFrameworkCore;
using SecondExamGroupA.Models;

namespace SecondExamGroupA.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<Customer> Customers { get; set; } 
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<MProgram> Programs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MProgram>().HasData(new List<MProgram>
        {
            new MProgram()
            {
                ProgramId = 1,
                Name = "Quick Wash",
                DurationMinutes = 69
            },
            new MProgram()
            {
                ProgramId = 2,
                Name = "Cotton Cycle",
                DurationMinutes = 143
            },
            new MProgram()
            {
                ProgramId = 3,
                Name = "Synthetic",
                DurationMinutes = 190
            }
        });

        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>
        {
            new WashingMachine()
            {
                WashingMachineId = 1,
                MaxWeight = 32.23M,
                SerialNumber = "WM2012/S431/12"
            },
            new WashingMachine()
            {
                WashingMachineId = 2,
                MaxWeight = 52.23M,
                SerialNumber = "WM2014/S491/28"
            }
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = null
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Ibrahim",
                LastName = "Yesil",
                PhoneNumber = "+48453043988"
            }
        });
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>
        {
            new AvailableProgram()
            {
                AvailableProgramId = 1,
                ProgramId = 1,
                WashingMachineId = 1,
                Price = 33.40m
            },
            new AvailableProgram()
            {
                AvailableProgramId = 2,
                ProgramId = 2,
                WashingMachineId = 2,
                Price = 48.7m
            }
        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>
        {
            new PurchaseHistory()
            {
                AvailableProgramId = 1,
                CustomerId = 1,
                PurchaseDate = DateTime.Parse("2025-06-03T09:00:00"),
                Rating = 4
            },
            new PurchaseHistory()
            {
                AvailableProgramId = 2,
                CustomerId = 1,
                PurchaseDate = DateTime.Parse("2025-06-04T09:00:00"),
                Rating = null
            }
        });


    }
}    