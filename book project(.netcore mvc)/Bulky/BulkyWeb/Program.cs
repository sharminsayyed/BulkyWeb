using Bulky_DataAcccess.Data;
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Privacy}/{id?}"); // try this out ans see on the homepage u get the privacy view page displayed


app.Run();
