using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties] // if we have bind multiple properties
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //[BindProperty] // important if we have to bind a single property
        public Category category { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                // tempdata is used if we have to display notification message on next page then add value in tempdata
                TempData["success"] = "Category Create Successfully!";
                return RedirectToPage("Index");
            }
            return Page();// if model state is not valid then return the same page with error messages
        }
    }
}
