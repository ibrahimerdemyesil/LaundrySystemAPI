using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondExamGroupA.Models;

[Table("Program")]
public class MProgram
{
    [Key]
    public int ProgramId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new HashSet<AvailableProgram>();
}