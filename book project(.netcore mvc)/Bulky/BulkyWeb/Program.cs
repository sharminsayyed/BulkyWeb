using Bulky_DataAcccess.Data;
using Bulky_DataAccess.Repository;
using Bulky_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services (on the builder) to the container.
// all the registration is done here 
builder.Services.AddControllersWithViews();

// we want to add EfCore to the project
// here we say that the DbContext  will be using sql server
// we have to also pass the connection string 
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// tools -> nuget package manager ->console -> update-database 
// this creates a database in SSMS

//adding category repository to the service collection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// register your custom repository class (CategoryRepository) with the built-in Dependency Injection (DI)
//Scoped = A new instance is created once per HTTP request.

// now instead of injecting ICategoryRepository in the controller, we can inject IUnitOfWork
// becaue it consist of all repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Whenever someone asks for IUnitOfWork, give them an instance of UnitOfWork class.
// asked of IUnitOfWork implementation of UnitOfWork class will be provided

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

// rounting - defines that if u type something in url where it should send request to 
// if nothing is defined go to the home Controller and index action 
// these are basically urls - that contains controllers and index and actions
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
// here we also add area (admin ,customer)routing
//pattern: "{controller=Home}/{action=Privacy}/{id?}"); // try this out ans see on the homepage u get the privacy view page displayed

// important point category controller is added to admin area 
// so need to add the views of te category controller in the admin area
// home controller is added to customer area
// so need to add the views of the home controller in the customer area

app.Run();
