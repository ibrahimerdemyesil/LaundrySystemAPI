using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondExamGroupA.Models;

[Table("Available_Program")]
public class AvailableProgram
{   [Key]
    public int AvailableProgramId { get; set; }
    public int WashingMachineId { get; set; }
    public int ProgramId { get; set; }
    public decimal Price { get; set; }

    [ForeignKey(nameof(WashingMachineId))]
    public WashingMachine WashingMachine { get; set; } = null!;
    [ForeignKey(nameof(ProgramId))]
    public MProgram MProgram { get; set; } = null!;
    
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new HashSet<PurchaseHistory>();
}