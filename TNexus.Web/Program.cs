using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TNexus.Web.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* 10. Ovde definisemo koje parametre cemo koristiti za konekciju na bazu. Prvo moramo da uvezemo dodatnu bibioteky za metodu UseSqlServer
 * U ApplicationDbContext smo definisali koje tabele ce nasa aplikacija da koristi*/
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

/*In combination with UseDeveloperExceptionPage, this captures database-related exceptions that can be resolved by using Entity Framework migrations
 *When these exceptions occur, an HTML response with details about possible actions to resolve the issue is generated.
 https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.databasedeveloperpageexceptionfilterserviceextensions.adddatabasedeveloperpageexceptionfilter?view=aspnetcore-6.0
 */
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

/*20. Ovde moramo definisati da nasa aplikacija ima mogucnost da pravi i manipulise sa korisnicima.
 */
builder.Services.AddDefaultIdentity<ApplicationUser>(
    options =>
        options.SignIn.RequireConfirmedAccount = false

    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireUserRegularRole", policy => policy.RequireRole("UserRegular"));
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

/* 21. Ovde smo definisali dodatne parametre koji cemo koristiti prilikom kreiranja korisnika
 */
builder.Services.Configure<IdentityOptions>(options =>
{
    //Password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 12;
    options.Password.RequiredUniqueChars = 1;

    //LockOut
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+#$&";

    // Required unique email
    options.User.RequireUniqueEmail = true;

    // Email confirmation settings
    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie Settings
    // options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Account/Identity/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
    options.LogoutPath = "/Account/Identity/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
    options.AccessDeniedPath = "/Account/Identity/AccessDenied"; // AccessDenied
    options.SlidingExpiration = true;
});

/* 1. Ovde definisemo pipeline koja ce nasa aplikacija koristiti, Aplikacija ce pratiti tok pipelina. U ovom slucaju ici ce Enviroment, pa UseHttpsRedirect, pa staticFiles
 * pa routing pa autorizacija pa mapiranja kontroler. Sada ako bismo zeleli da implementiramo autentifikaciju u nasoj aplikaciji moramo da pazimo na kom mestu da ga stavimo
 * jer ne mozemo da stavimo autentifikaciju posle autorizacije u nasem projektu.*/
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

/* 2. Defaltna ruta nase web aplikacije, ako putanja nije definisana u url-u web browsera ovo ce biti redirekcije aplikacije
 * podesili smo podrazumevani kontroler i podrezumevanu akciju*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

/* 22. Kada smo kreirali areas zaboravili smo da dodamo ovde da on postoji
 */
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();