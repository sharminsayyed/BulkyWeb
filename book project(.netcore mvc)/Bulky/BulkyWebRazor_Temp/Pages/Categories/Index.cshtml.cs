using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Category> CategoryList { get; set; }
        // onget()function here is used to get the list of category from the database and display it on the screen 
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
