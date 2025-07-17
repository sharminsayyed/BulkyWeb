using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// here we can perfrom crud operations 
namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        // here we have to use the dbcontext 

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // use EFCORE to get the data from the database 
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        

        public IActionResult NewC()
        {
            return View();
        }

       

    }
}
