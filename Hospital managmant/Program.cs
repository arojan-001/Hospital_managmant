using Hospital_BLL.Interfaces;
using Hospital_BLL.Mappings;
using Hospital_BLL.Services;
using Hospital_DAL.EF;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// This automatically picks up all profiles from the current domain's assemblies
builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(Hospital_management.Mappings.AutoMapperProfile));

// Register DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<EFDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1")));

// Add services to the container.
builder.Services.AddControllersWithViews();



// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();


// Register repository interfaces with their implementations
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IOtherStaffRepository, OtherStaffRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientVisitRepository, PatientVisitRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register BLL services
// Register BLL services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IOtherStaffService, OtherStaffService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientVisitService, PatientVisitService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

// Seed the default admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userService = services.GetRequiredService<IUserService>();
        Task.Run(async () => await userService.SeedDefaultAdminAsync()).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the default admin user.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
