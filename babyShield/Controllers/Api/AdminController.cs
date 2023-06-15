using AutoMapper;
using babyShield.Areas.Identity.Data;
using babyShield.DTOs;
using babyShield.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public ActionResult<AdminDtos> GetAdmin(int id)
    {
        var admin = _context.admins.SingleOrDefault(c => c.Id == id);
        if (admin == null)
        {
            return BadRequest();
        }

        var adminDto = _mapper.Map<Admin, AdminDtos>(admin);
        return Ok(adminDto);
    }

    [HttpDelete("{id}")]
    public void DeleteClinic(int id)
    {
        var clinicInDb = _context.clinics.SingleOrDefault(c => c.Id == id);
        if (clinicInDb == null)
        {
            throw new HttpRequestException("NotFound");
        }

        _context.clinics.Remove(clinicInDb);
        _context.SaveChanges();
    }
    [HttpPut("FreezeClinic/{id}")]
    public IActionResult FreezeClinic(int id)
    {
        var clinic = _context.clinics.SingleOrDefault(c => c.Id == id);
        if (clinic == null)
        {
            return NotFound();
        }

        if (clinic.isFreaze)
        {
            clinic.isFreaze = false;
        }
        else
        {
            clinic.isFreaze = true;
        }
        _context.SaveChanges();

        return Ok();
    }
   [HttpPost("CreateManager")]
public async Task<IActionResult> CreateManager([FromBody] ManagerDtos managerDto)
{
    // Perform the necessary operations to save the manager data to your database or storage
    // Example code:
    var manager = new Manager
    {
        managerName = managerDto.managerName,
        nationalId = managerDto.nationalId
    };

    // Save the manager to the database
    _context.managers.Add(manager);
    _context.SaveChanges();


    var user = new ApplicationUser
    {
        UserName = $"{managerDto.nationalId}",
        Email = $"{managerDto.managerName.ToUpper()}@gmail.com"
    };

        var managerName = managerDto.managerName;
        var capitalizedManagerName = char.ToUpperInvariant(managerName[0]) + managerName.Substring(1).ToLowerInvariant();
        var password = $"{capitalizedManagerName}@{managerDto.nationalId}";
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            // Assign the newly created user as the manager's user
            manager.ApplicationUser = user;
            _context.SaveChanges();
            await _userManager.AddToRoleAsync(user, "MANAGER");

            return await Task.FromResult(Ok(new { hiddenManagerId = manager.Id, Message = "Manager saved successfully." }));

        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Errors = errors });
        }
        // Return a success response
}


    [HttpPost("SaveReception")]
    public async Task<IActionResult> SaveReception([FromBody] ReceptionDtos receptionDto)
    {
        // Perform the necessary operations to save the receptionist data to your database or storage
        // Example code:
        var receptionist = new Reception
        {
            receptionName = receptionDto.receptionName,
            nationalId = receptionDto.nationalId
        };

        // Save the receptionist to the database
        _context.receptions.Add(receptionist);
        _context.SaveChanges();

        var user = new ApplicationUser
        {
            UserName = $"{receptionDto.nationalId}",
            Email = $"{receptionDto.receptionName.ToUpper()}@gmail.com"
        };

        var ReceptionName = receptionDto.receptionName;
        var capitalizedReceptionName = char.ToUpperInvariant(ReceptionName[0]) + ReceptionName.Substring(1).ToLowerInvariant();
        var password = $"{capitalizedReceptionName}@{receptionDto.nationalId}";
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            // Assign the newly created user as the receptionist's user
            receptionist.ApplicationUser = user;
            _context.SaveChanges();
            await _userManager.AddToRoleAsync(user, "RECEPTION");

            return Ok(new { hiddenManagerId = receptionist.Id, Message = "Manager saved successfully." });
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Errors = errors });
        }
    }

    // Action method to save the clinic
    [HttpPost("SaveClinic")]
    public IActionResult SaveClinic([FromBody] ClinicDtos clinicDto)
    {
        // Perform the necessary operations to save the clinic data to your database or storage
        // Example code:
        var manager = _context.managers.FirstOrDefault(m => m.Id == clinicDto.managerId);
        var reception = _context.receptions.FirstOrDefault(r => r.Id == clinicDto.receptionId);
        var clinic = new Clinic
        {
            clinicName = clinicDto.clinicName,
            manager = manager,
            reception = reception,
            isFreaze = true
        };

        // Save the clinic to the database
        _context.clinics.Add(clinic);
        _context.SaveChanges();

        // Return a success response
        return Ok("Clinic saved successfully.");
    }
    [HttpGet("GetUnassignedManagers")]
    public IActionResult GetUnassignedManagers()
    {
        using (_context)
        {
            var unassignedManagers = _context.managers
                .FromSqlRaw("SELECT * FROM managers WHERE Id NOT IN (SELECT managerId FROM clinics)")
                .ToList();

            var response = unassignedManagers.Select(manager => new ManagerDtos
            {
                Id = manager.Id,
                managerName = manager.managerName,
                nationalId = manager.nationalId
            });

            return Ok(response);
        }
    }
    [HttpGet("GetUnassignedReception")]
    public IActionResult GetUnassignedReception()
    {
        using (_context)
        {
            if (_context.receptions != null)
            {
                var unassignedReception = _context.receptions
                    .FromSqlRaw("SELECT * FROM receptions WHERE Id NOT IN (SELECT receptionId FROM clinics)")
                    .ToList();

                var response = unassignedReception.Select(Reception => new ReceptionDtos
                {
                    Id = Reception.Id,
                    receptionName = Reception.receptionName,
                    nationalId = Reception.nationalId
                });
            
            return Ok(response);
            }
            return Ok();
        }
    }
}





