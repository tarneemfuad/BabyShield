using babyShield.Areas.Identity.Data;
using babyShield.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers
{
	public class PatientController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PatientController(ApplicationDbContext context)
		{
			_context = context;

		}
		public IActionResult index(int id)
		{
			var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();

			return View(patient);
		}
		public IActionResult ourDoctor()
		{
			var clinics = _context.clinics.ToList();
			var doctors = _context.doctors.Include(d => d.DoctorAppointments).ToList();
			//var appointments = _context.doctorAppointments.Where(a => a.isBooked == false).ToList();
			var ViewModel = new patientViewModel
			{
				clinics = clinics,
				doctors = doctors,
				//doctorAppointments = appointments
			};
			return View(ViewModel);
		}
		public IActionResult bookAppointment(int id)
		{
			var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();
			var clinics = _context.clinics.ToList();
			var viewModel = new patientViewModel
			{
				Patient = patient,
				clinics = clinics
			};
			return View(viewModel);
		}
		public IActionResult viewAppointment(int id)
		{
			var patient = _context.patients.Include(p=>p.clinic).Where(p => p.Id == id).FirstOrDefault();
			var clinics = _context.clinics.ToList();
			var appointments = _context.doctorAppointments.Include(a=>a.Doctor).Where(a => a.PatientId == id).ToList();
			var viewModel = new patientViewModel
			{
				Patient = patient,
				clinics = clinics,
				doctorAppointments = appointments,
				
			};
			return View(viewModel);
		}
		public IActionResult viewVaccinePrescription(int id)
		{
			var patient = _context.patients.Where(p => p.Id == id).FirstOrDefault();
			var clinics = _context.clinics.ToList();
			var doctors = _context.doctors.ToList();
			var vac = _context.vaccines.ToList();
			var appointments = _context.doctorAppointments.Where(a => a.PatientId == id).ToList();
			var prescription = _context.prescriptions.Where(p => p.patientId == id).ToList();
			var vaccine = _context.patientVaccines.Where(p => p.PatientId == id).ToList();
			var viewModel = new patientViewModel
			{
				Patient = patient,
				clinics = clinics,
				doctorAppointments = appointments,
				prescription = prescription,
				vaccine = vaccine
			};
			return View(viewModel);
		}

	}
}
