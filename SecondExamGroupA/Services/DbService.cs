using Microsoft.EntityFrameworkCore;
using SecondExamGroupA.Data;
using SecondExamGroupA.DTOs;
using SecondExamGroupA.Exceptions;
using SecondExamGroupA.Models;

namespace SecondExamGroupA.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<CustomerPurchasesDto?> GetCustomerPurchasesAsync(int customerId)
    {
        var customer = await _context.Customers
            .Where(c => c.CustomerId == customerId)
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.MProgram)
            .FirstOrDefaultAsync();

        if (customer == null)
            return null;

        return new CustomerPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchaseHistories.Select(ph => new PurchaseDto
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                WashingMachine = new WashingMachineDto
                {
                    Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new ProgramDto
                {
                    Name = ph.AvailableProgram.MProgram.Name,
                    Duration = ph.AvailableProgram.MProgram.DurationMinutes
                }
            }).ToList()
        };
    }

    public async Task AddWashingMachineWithProgramsAsync(AddWashingMachineDto dto)
    {
        if (dto.WashingMachine.MaxWeight < 8)
            throw new ConflictException("MaxWeight must be at least 8");

        if (await _context.WashingMachines.AnyAsync(w => w.SerialNumber == dto.WashingMachine.SerialNumber))
            throw new ConflictException("Washing machine with this serial number already exists");

        var washingMachine = new WashingMachine
        {
            MaxWeight = dto.WashingMachine.MaxWeight,
            SerialNumber = dto.WashingMachine.SerialNumber
        };

        var availablePrograms = new List<AvailableProgram>();

        foreach (var ap in dto.AvailablePrograms)
        {
            if (ap.Price > 25)
                throw new ConflictException($"Price for program '{ap.ProgramName}' exceeds the limit");

            var program = await _context.Programs.FirstOrDefaultAsync(p => p.Name == ap.ProgramName);
            if (program == null)
                throw new NotFoundException($"Program '{ap.ProgramName}' not found");

            availablePrograms.Add(new AvailableProgram
            {
                ProgramId = program.ProgramId,
                Price = ap.Price,
                WashingMachine = washingMachine
            });
        }

        await _context.WashingMachines.AddAsync(washingMachine);
        await _context.AvailablePrograms.AddRangeAsync(availablePrograms);
        await _context.SaveChangesAsync();
    }
}