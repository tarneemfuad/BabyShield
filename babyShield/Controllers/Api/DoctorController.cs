using AutoMapper;
using babyShield.Areas.Identity.Data;
using babyShield.DTOs;
using babyShield.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers.Api
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorApiController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreateVaccine")]

        public IActionResult CreateVaccine([FromBody] patientVaccineDtos pVaccine)
        {
            if (pVaccine == null)
            {
                return BadRequest("Invalid data");
            }

            var patient = _context.patients.Find(pVaccine.PatientId);
            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            var vaccine = _context.vaccines.Find(pVaccine.vaccineId);
            if (vaccine == null)
            {
                return NotFound("Vaccine not found");
            }

            var patientVaccine = new PatientVaccine
            {
                PatientId = pVaccine.PatientId,
                vaccineId = pVaccine.vaccineId,
                vaccineDate = DateTime.Now,
                width = pVaccine.width,
                hight = pVaccine.hight,
                headRadios = pVaccine.headRadios,
               
            };

            _context.patientVaccines.Add(patientVaccine);
            _context.SaveChanges();

            return Ok(new { Id = patientVaccine.Id, Message = "patientVaccine saved successfully." });

        }
        [HttpPost("addPrescription")]
        public IActionResult addPrescription([FromBody] prescriptionDtos prescriptionDtos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new Prescription instance and populate its properties
                    var prescription = new prescription
                    {
                        patientId = prescriptionDtos.patientId,
                        medicalCondition = prescriptionDtos.medicalCondition,
                        medication = prescriptionDtos.medication,
                        dosage = prescriptionDtos.dosage,
                        frequency = prescriptionDtos.frequency,
                        datePrescribed = DateTime.Now
                    };

                    // Save the new prescription to the database
                    _context.prescriptions.Add(prescription);
                    _context.SaveChanges();

                    return Ok(prescription.Id); // Return the ID of the newly created prescription
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("Editprofile")]
        public IActionResult Editprofile([FromBody] DoctorDtos doctorDtos)
        {
            if (!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad Request");
            }
            var doctorInDb = _context.doctors.SingleOrDefault(d => d.Id == doctorDtos.Id);
            if (doctorInDb == null)
            {
                throw new HttpRequestException("NotFound");
            }
            _mapper.Map(doctorDtos, doctorInDb);

            _context.SaveChanges();
            return Ok("update successfully");
        }
        [HttpPost("CreateAppointment")]
        public IActionResult CreateAppointment([FromBody] appointmentDtos appDtos)
        {
            var doctorInDb = _context.doctors.Include(d=>d.clinic).Where(d => d.Id == appDtos.DoctorId).FirstOrDefault();

            var appointment = new DoctorAppointment
            {
                isBooked = appDtos.isBooked,
                DoctorId = appDtos.DoctorId,
                Doctor = doctorInDb,
                dateTime = appDtos.dateTime,


            };
            _context.doctorAppointments.Add(appointment);
            _context.SaveChanges();
            return Ok();
        }
    }
}
