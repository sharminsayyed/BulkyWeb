using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Bulky_DataAcccess.Data;
using Bulky_Models;

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
            // retrieve data from the database and table (select)
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // this is basically the get action method 
        public IActionResult NewC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewC(Category obj )
        {
            // custom error messgae for validation - server side validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category Name and Display Order cannot be the same ");
            }
            // it checks if the obj passed to add to the table is valid(checks all the annotation and validations)
            if (ModelState.IsValid)
            {
                // add the category to the table (insert)
                _db.Categories.Add(obj);
                _db.SaveChanges(); // here it will actually go to the database and create that category
                // here it says after adding and saving redirect to index action of category controller
                // tempdata is used if we have to display notification message on next page then add value in tempdata
                TempData["success"] = "Category Create Successfully!";
                return RedirectToAction("Index","Category");
            }
            else
            {
                return View();
            } 
           
        }

        // this is basically the get action method 
        public IActionResult Edit(int? id)
        {// we need the id the user wants to edit 
            if(id == null || id == 0){
                 return NotFound(); // if the id is not found then return not found
            }
            //here we have to retrive the category from the database using the id
            // there are multiple was to do it 
            Category obj = _db.Categories.Find(id); // this is a simple way to find the category by id works with primary key
            /*
            Category? obj2 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            Category? obj3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();// this is a more complex way to find the category by id*/

            if (obj == null)
            {
                return NotFound(); // if the category is not found then return not found
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {// here we try to update / edit an category id 
                _db.Categories.Update(obj);
                _db.SaveChanges();
                // tempdata is used if we have to display notification message on next page then add value in tempdata
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }

        // this is basically the get action method 
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //// if we have to pass id instead of the category obj 
        //[HttpPost ,ActionName("Delete")]
        //// here we used different method name because it will overload as the get Delete methodname is same
        //public IActionResult DeletePost(int? id)
        //{
        //    Category obj = _db.Categories.Find(id);
        //    if(id == null) { return NotFound(); }
        //    _db.Categories.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "Category");

        //}
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            // tempdata is used if we have to display notification message on next page then add value in tempdata
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index", "Category");   
            
        }
    }
}
