using babyShield;
using babyShield.Areas.Identity.Data;
using babyShield.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");


builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Add this line to enable role management
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register the RoleManager service with Scoped lifetime
builder.Services.AddScoped<RoleManager<IdentityRole>>();

// Add other services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var result = await roleManager.CreateAsync(new IdentityRole("admin"));
    result = await roleManager.CreateAsync(new IdentityRole("manager"));
    result = await roleManager.CreateAsync(new IdentityRole("doctor"));
    result = await roleManager.CreateAsync(new IdentityRole("patient"));
    result = await roleManager.CreateAsync(new IdentityRole("reception"));

    // Check if role creation succeeded
    if (result.Succeeded)
    {
        Console.WriteLine("Roles have been created successfully.");
    }
    else
    {
        Console.WriteLine("An error occurred while creating roles.");
    }
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var nationalId = "2000012345";
    string password = "Hala@2000012345";

    if (await userManager.FindByEmailAsync(nationalId) == null)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.nationalId == long.Parse(nationalId));
        if (user == null)
        {
            user = new ApplicationUser
            {
                nationalId = long.Parse(nationalId),
                UserName = "2000012345",
                Email = "HALA" + "@gmail.com" // Set an email address for the user
            };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, "ADMIN");
            var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var admin = new Admin
            {
                adminName = "HALA",
                nationalId = long.Parse(nationalId),
                PhoneNumber= "962787777777",
                ApplicationUser = user
            };
            _context.admins.Add(admin);
            _context.SaveChanges();
        }
    }

    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

}



app.Run();
