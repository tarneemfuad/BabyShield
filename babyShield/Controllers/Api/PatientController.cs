using babyShield.Areas.Identity.Data;
using babyShield.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// Serialize your object using Json.NET


namespace babyShield.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/doctors")]
        public IActionResult GetDoctorsForClinic(int id)
        {
            var clinic = _context.clinics.Include(c => c.Doctors)
                .FirstOrDefault(c => c.Id == id);

            if (clinic == null)
            {
                return NotFound();
            }

            var doctors = clinic.Doctors.Select(d => new
            {
                d.Id,
                d.doctorName
            }).ToList();

            return Ok(new { doctors });
        }
        [HttpGet("{clinicId}/doctors/{doctorId}/appointments")]
        public IActionResult GetAppointmentsForDoctor(int clinicId, int doctorId)
        {
            var doctor = _context.doctors.Include(d => d.DoctorAppointments)
                .FirstOrDefault(d => d.Id == doctorId && d.clinicId == clinicId);

            if (doctor == null)
            {
                return NotFound();
            }

            var appointments = doctor.DoctorAppointments.Select(a => new
            {
                a.Id,
                a.dateTime,
                a.isBooked
            }).ToList();

            return Ok(new { appointments });
        }

        [HttpPut("UpdateAppointment")]
        public IActionResult UpdateAppointment([FromBody] patientAppointmentDtos appointmentDto)
        {



            var appointment = _context.doctorAppointments.FirstOrDefault(a => a.Id == appointmentDto.Id);
            var patient = _context.patients.FirstOrDefault(p => p.Id == appointmentDto.PatientId);

            if (appointment == null || appointment.isBooked)
            {
                // Appointment not found or already booked, return appropriate response or error
                return NotFound();
            }

            appointment.PatientId = appointmentDto.PatientId;
            appointment.isBooked = true;
            appointment.Patient = patient;
            _context.SaveChanges();

            return Ok();
        }



    }
}
