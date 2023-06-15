// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using babyShield.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace babyShield.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

         if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                // Get the authenticated user
                var user = await _signInManager.UserManager.FindByNameAsync(Input.UserName);

                // Get the roles of the authenticated user
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                // Check the role(s) of the user and redirect accordingly
                if (roles.Contains("ADMIN"))
                {
                    var admin = await _userManager.FindByNameAsync(Input.UserName);
                    if (admin != null)
                    {
                        return RedirectToAction("Index", "Admin", new { id = admin.Id });
                    }
                }
                else if (roles.Contains("MANAGER"))
                {
                        var nationalId = int.Parse(Input.UserName);
                        var manager = _context.managers.FirstOrDefault(m => m.nationalId == nationalId);

                        if (manager != null)
                        {
                            return RedirectToAction("index", "Manager", new { id = manager.Id });
                        }
                    }
                else if (roles.Contains("RECEPTION"))
                {
                        var nationalId = int.Parse(Input.UserName);
                        var receptionist = _context.receptions.FirstOrDefault(m => m.nationalId == nationalId);
                        if (receptionist != null)
                    {
                        return RedirectToAction("index", "Reception", new { id = receptionist.Id });
                    }
                }
                else if (roles.Contains("PATIENT"))
                {
                        var nationalId = int.Parse(Input.UserName);
                        var patient = _context.patients.FirstOrDefault(m => m.nationalId == nationalId);
                        if (patient != null)
                    {
                        return RedirectToAction("index", "Patient", new { id = patient.Id });
                    }
                }
                else if (roles.Contains("DOCTOR"))
                {
                        var nationalId = int.Parse(Input.UserName);
                        var doctor = _context.doctors.FirstOrDefault(m => m.nationalId == nationalId);
                        if (doctor != null)
                    {
                        return RedirectToAction("index", "Doctor", new { id = doctor.Id });
                    }
                }
                else
                {
                    // Handle other roles or redirect to a default page
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }


        }
            

            // If model state is not valid, return the page with validation errors
            return Page();
        }

    }
}
