using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(AppDbContext data):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
        return Ok(await data.Patients.Select(p => new PatientDto
        {
            IdPatient = p.IdPatient,
            FirstName = p.FirstName,
            LastName = p.LastName,
            BirthDate = p.Birthdate,
            Prescriptions = p.Prescriptions.Select(pr => new PrescriptionDto
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                Doctor = new DoctorDto
                {
                    IdDoctor = pr.Doctor.IdDoctor,
                    FirstName = pr.Doctor.FirstName
                },
                Medicaments = pr.PrescriptionsMedicaments.Select(pm => new MedicamentDto
                {
                    IdMedicament = pm.IdMedicament,
                    Name = pm.Medicament.Name,
                    Description = pm.Medicament.Description,
                    Dose = pm.Dose,
                    Details = pm.Details
                }).ToList(),
                
            }).ToList()
        }).ToListAsync());

    }
}