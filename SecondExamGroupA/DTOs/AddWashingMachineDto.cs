using System.ComponentModel.DataAnnotations;

namespace SecondExamGroupA.DTOs
{
    public class AddWashingMachineDto
    {
        [Required]
        public CreatingWashingMachineDto WashingMachine { get; set; }

        [Required]
        [MinLength(1)]
        public List<AvailableProgramsDto> AvailablePrograms { get; set; }
    }

    public class AvailableProgramsDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ProgramName { get; set; }

        [Required]
        [Range(0.01, 1000)]
        public decimal Price { get; set; }
    }

    public class CreatingWashingMachineDto
    {
        [Required]
        [Range(1, 100)]
        public decimal MaxWeight { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string SerialNumber { get; set; }
    }
}