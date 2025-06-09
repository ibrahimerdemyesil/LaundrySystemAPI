using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondExamGroupA.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    
    public decimal MaxWeight { get; set; }
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new HashSet<AvailableProgram>();
    
}