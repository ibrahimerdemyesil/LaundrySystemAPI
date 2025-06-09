using SecondExamGroupA.DTOs;

namespace SecondExamGroupA.Services;

public interface IDbService
{
    Task<CustomerPurchasesDto?> GetCustomerPurchasesAsync(int customerId);
    Task AddWashingMachineWithProgramsAsync(AddWashingMachineDto dto);

}