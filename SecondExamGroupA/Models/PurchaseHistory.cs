using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SecondExamGroupA.Models;

[Table("Purchase_History")]
[PrimaryKey(nameof(AvailableProgramId), nameof(CustomerId))]
public class PurchaseHistory
{
    public int AvailableProgramId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int? Rating {get; set;}
    
    [ForeignKey(nameof(AvailableProgramId))]
    public AvailableProgram AvailableProgram { get; set; } = null!;
    
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;
}