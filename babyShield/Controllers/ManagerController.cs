using babyShield.Areas.Identity.Data;
using babyShield.Models;
using babyShield.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult index(int id)
        {
            // استعادة بيانات المدير
            var manager = _context.managers.Where(m => m.Id == id).FirstOrDefault();
            // استعادة بيانات العيادة
            var clinic = _context.clinics.Where(m => m.managerId == id).FirstOrDefault();

           
                // استعادة بيانات الأطباء
                var doctors = _context.doctors.Include(d => d.DoctorAppointments)
                    .Where(d => d.clinicId == clinic.Id)
                    .ToList();

           
            // استعادة بيانات المرضى
            var patients = _context.patients.Include(p => p.clinic)
                .Where(p => p.clinicId == clinic.Id)
                .ToList();

            // استعادة بيانات المواعيد
            var docc = _context.doctors.ToList();
            var docApp = _context.doctorAppointments.ToList();
            var clic = _context.clinics.ToList();

            var fullInfo = from d in docc
                           join doc in docApp on d.Id equals doc.DoctorId
                           join c in clic on d.clinicId equals c.Id
                           where c.Id == clinic.Id
                           select new JoinTable { doctors = d, clinics = c, doctorAppointments = doc };



            var appointments = fullInfo.Select(ft => ft.doctorAppointments).ToList();
            
            var viewModel = new ManagerViewModel
            {
                doctors = doctors,
                patients = patients,
                appointments = appointments,
                manager = manager,
                clinic = clinic
            };
            
            return View(viewModel);
            
            
        }
        public IActionResult doctorForm(int id)
        {
            var manager = _context.managers.Where(m=>m.Id==id).FirstOrDefault();
            // استعادة بيانات العيادة
            var clinic = _context.clinics.Where(m => m.managerId==id).FirstOrDefault();
            var reception = _context.receptions.FirstOrDefault();
            var viewModel = new ManagerViewModel
            {

                manager = manager,
                clinic = clinic,
                reception = reception
            };

            return View(viewModel);

        }
        public IActionResult deleteDoctor(int id)
        {
            var clinic = _context.clinics.Where(c => c.managerId == id).FirstOrDefault();
            var doctors = _context.doctors.Include(d => d.DoctorAppointments).Where(d=>d.clinicId==clinic.Id).ToList();
            var manager = _context.managers.Where(m=>m.Id==id).FirstOrDefault();
            var viewModel = new ManagerViewModel
            {
                doctors = doctors,
                manager = manager

            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Save(Doctor doctor)
        {

            var selectedClinic = _context.clinics.SingleOrDefault(m => m.Id == doctor.clinicId);

            doctor.clinic = selectedClinic;

            if (doctor.Id == 0)
            {
                _context.doctors.Add(doctor);
            }
            else
            {
                var doctorInDb = _context.doctors.Single(c => c.Id == doctor.Id);
                doctorInDb.doctorName = doctor.doctorName;
                doctorInDb.nationalId = doctor.nationalId;
                doctorInDb.clinic = doctor.clinic;
                doctorInDb.clinicId = doctor.clinicId;
                //doctorInDb.phoneNumber = doctor.phoneNumber;
                doctorInDb.specialest = doctor.specialest;

            }
            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }

}
