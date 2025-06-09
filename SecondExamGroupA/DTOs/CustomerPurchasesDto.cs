using System.ComponentModel.DataAnnotations;

namespace SecondExamGroupA.DTOs
{
    public class CustomerPurchasesDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MinLength(1)]
        public List<PurchaseDto> Purchases { get; set; }
    }

    public class PurchaseDto
    {
        [Required]
        public DateTime Date { get; set; }

        public int? Rating { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Required]
        public WashingMachineDto WashingMachine { get; set; }

        [Required]
        public ProgramDto Program { get; set; }
    }

    public class WashingMachineDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Serial { get; set; }

        [Required]
        [Range(1, 100)]
        public decimal MaxWeight { get; set; }
    }

    public class ProgramDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(1, 300)]
        public int Duration { get; set; }
    }
}