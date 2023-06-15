using babyShield.Areas.Identity.Data;
using babyShield.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace babyShield.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Clinic()
        {

            var clinics = _context.clinics.Include(c => c.manager).Include(c => c.reception).ToList();
            var admin = _context.admins.SingleOrDefault();

            var viewModel = new AdminViewModel
            {
                Clinics = clinics,
                admin = admin
            };

            return View(viewModel);
        }
        public IActionResult index()
        {
            return View();
        }

    }
}
