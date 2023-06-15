using AutoMapper;
using babyShield.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace babyShield.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReceptionController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReceptionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpDelete("{id}")]
        public void DeleteAppointment(int id)
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
