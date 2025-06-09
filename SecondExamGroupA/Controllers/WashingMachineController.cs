using Microsoft.AspNetCore.Mvc;
using SecondExamGroupA.DTOs;
using SecondExamGroupA.Exceptions;
using SecondExamGroupA.Services;

namespace SecondExamGroupA.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IDbService _dbService;

    public WashingMachinesController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddWashingMachine(AddWashingMachineDto dto)
    {
        try
        {
            await _dbService.AddWashingMachineWithProgramsAsync(dto);
            return Created("", null);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}