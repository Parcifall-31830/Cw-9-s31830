using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament),"IdPrescription")]
public class PrescriptionMedicament
{
    [Column("IdMedicament")]
    public int IdMedicament { get; set; }
    [Column("IdPrescription")]
    public int IdPrescription { get; set; }
    
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string? Details { get; set; }
    
    public virtual Medicament? Medicament { get; set; }
    
    
    
    
}