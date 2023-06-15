using babyShield.Areas.Identity.Data;
using babyShield.Models;
using babyShield.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult index(int id)
        {
            var doctor = _context.doctors.Where(d => d.Id == id).FirstOrDefault();
            var patient = _context.patients.Where(d => d.doctorId == id).ToList();
            var appointments=_context.doctorAppointments.Include(a=>a.Patient).Where(a=>a.DoctorId==id).ToList();
           
            var viewModel = new DoctorViewModel
            {
                doctor = doctor,
                patients = patient,
                appointments = appointments,

            };
            return View(viewModel);
        }
        public IActionResult viewInfo(int id)
        {
            var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();
            var vaccines = _context.vaccines.ToList();
            var pateintVaccines = _context.patientVaccines.Where(p => p.PatientId == id).ToList();
            var viewModel = new VaccineViewModel
            {
                patient = patient,
                vaccines = vaccines,
                patientVaccine = pateintVaccines
            };

            return View(viewModel);
        }
        public IActionResult addVaccine(int id)
        {
            var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();
            var vaccines = _context.vaccines.ToList();
            var viewModel = new VaccineViewModel
            {
                patient = patient,
                vaccines = vaccines,
            };

            return View(viewModel);
        }
        public IActionResult addPrescription(int id)
        {
            var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();

            var viewModel = new prescription
            {
                patient = patient

            };

            return View(viewModel);
        }
        public IActionResult editProfile(int id)
        {
            var doctor = _context.doctors.Where(d => d.Id == id).FirstOrDefault();
            var clinics = _context.clinics.ToList();
            var viewModle = new DoctorViewModel
            {
                doctor = doctor,
                clinics = clinics
            };
            return View(viewModle);
        }
        public IActionResult addAppointment(int id)
        {
            var doctor = _context.doctors.Include(d=>d.clinic).Where(d => d.Id == id).FirstOrDefault();
            var appointments = _context.doctorAppointments.Where(d => d.DoctorId == id).ToList();
            var clinics = _context.clinics.Where(c => c.Id == doctor.clinicId).ToList();
            var patients = _context.patients.Where(p => p.doctorId == id).ToList();
            var viewModle = new DoctorViewModel
            {
                doctor = doctor,
                appointments = appointments,
                clinics = clinics,
                patients = patients,
                
            };
            return View(viewModle);
        }
    }
}
