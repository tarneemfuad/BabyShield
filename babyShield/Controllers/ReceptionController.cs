using babyShield.Areas.Identity.Data;
using babyShield.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult index(int id)
        {

            var reception = _context.receptions.Where(r => r.Id == id).FirstOrDefault();
            // استعادة بيانات العيادة
            var clinic = _context.clinics.Include(m => m.reception).Where(c => c.reception.Id == reception.Id).FirstOrDefault();

            // استعادة بيانات المرضى
            var patients = _context.patients.Include(p => p.clinic)
                .Where(p => p.clinic.Id == clinic.Id)
                .ToList();
            // استعادة بيانات المواعيد
            var appointments = _context.doctorAppointments
                .Include(a => a.Patient).Where(a => a.Patient.clinic.Id == clinic.Id).ToList();
            // استعادة بيانات الأطباء
            var doctors = _context.doctors.Include(d => d.DoctorAppointments).ToList();


            // إنشاء عنصر ViewModel
            var viewModel = new ReceptionViewModel
            {
                reception = reception,
                patients = patients,
                clinic = clinic,
                appointments = appointments,
                doctors = doctors
            };

            return View(viewModel);
        }

    }
}
