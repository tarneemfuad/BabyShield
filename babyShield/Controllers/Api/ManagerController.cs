using AutoMapper;
using babyShield.Areas.Identity.Data;
using babyShield.DTOs;
using babyShield.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManagerController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDtos doctorDto)
        {
            var clinic = _context.clinics.Where(c => c.Id == doctorDto.clinicId).FirstOrDefault();
            // قم بإضافة الطبيب إلى قاعدة البيانات أو القيام بأي عمليات أخرى المطلوبة
            var doctor = new Doctor
            {
                doctorName = doctorDto.doctorName,
                nationalId = doctorDto.nationalId,
                clinicId = doctorDto.clinicId,
                specialest = doctorDto.specialest,
                clinic = clinic,
               
            };

            _context.doctors.Add(doctor);
            _context.SaveChanges();

            var user = new ApplicationUser
            {
                UserName = $"{doctorDto.nationalId}",
                Email = $"{doctorDto.doctorName.ToUpper()}@gmail.com",
               PhoneNumber=$"{doctorDto.phoneNumber}"
                
            };

            var DoctorName = doctorDto.doctorName;
            var capitalizedReceptionName = char.ToUpperInvariant(DoctorName[0]) + DoctorName.Substring(1).ToLowerInvariant();
            var password = $"{capitalizedReceptionName}@{doctorDto.nationalId}";
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Assign the newly created user as the receptionist's user
                doctor.ApplicationUser = user;
                _context.SaveChanges();
                await _userManager.AddToRoleAsync(user, "DOCTOR");

                return Ok(new { hiddenManagerId = doctor.Id, Message = "Manager saved successfully." });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }
        }

        [HttpGet("GetClinic")]
        public IActionResult GetClinic(int id)
        {
            using (_context)
            {
                var unassignedClinics = _context.clinics
                    .FromSqlRaw("SELECT * FROM clinics WHERE managerId = {0}", id)
                    .ToList();

                var response = unassignedClinics.Select(clinic => new Clinic
                {
                    Id = clinic.Id,
                    managerId = clinic.managerId,
                    receptionId = clinic.receptionId,
                    clinicName = clinic.clinicName,
                    reception = clinic.reception,
                    manager = clinic.manager,
                    isFreaze = clinic.isFreaze
                });

                return Ok(response);
            }

        }
        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            var doctorInDb = _context.doctors.SingleOrDefault(c => c.Id == id);
            if (doctorInDb == null)
            {
                throw new HttpRequestException("NotFound");
            }

            _context.doctors.Remove(doctorInDb);
            _context.SaveChanges();
        }
    }
}
