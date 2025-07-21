using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Bulky_DataAcccess.Data;
using Bulky_Models;
using Bulky_DataAccess.Repository.IRepository;

// here we can perfrom crud operations 
namespace BulkyWeb.Areas.Admin.Controllers
{
    // here we need to specify to which area this controller belongs to
    [Area("Admin")]
    public class CategoryController : Controller
    {
        /* comment this section because we are using repository pattern 
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
            Category? obj3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();// //this is a more complex way to find the category by id

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
        */


        /*--------------------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------------------*/


        /* here using repository pattern where we use IcategoryRepository
         * here we use predefined method rather than EFCore methods direct 
         where as we have use the EFCore methods in the repository to define these methods 
        The methods like Add(), Update(), Remove() (or Delete()), and SaveChanges() are predefined methods provided by Entity Framework Core (EF Core) through the DbSet<T> and DbContext classes.
        */
        /*
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            // use EFCORE to get the data from the database 
            // retrieve data from the database and table (select)
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        // this is basically the get action method 
        public IActionResult NewC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewC(Category obj)
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
                _categoryRepo.Add(obj);
                _categoryRepo.Save(); // here it will actually go to the database and create that category
                // here it says after adding and saving redirect to index action of category controller
                // tempdata is used if we have to display notification message on next page then add value in tempdata
                TempData["success"] = "Category Create Successfully!";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }

        }

        // this is basically the get action method 
        public IActionResult Edit(int? id)
        {// we need the id the user wants to edit 
            if (id == null || id == 0)
            {
                return NotFound(); // if the id is not found then return not found
            }
            //here we have to retrive the category from the database using the id
            Category obj = _categoryRepo.Get(u => u.Id == id); 
            
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
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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
            Category obj = _categoryRepo.Get(u => u.Id == id);
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
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            // tempdata is used if we have to display notification message on next page then add value in tempdata
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index", "Category");   
            
        }

        */


/*--------------------------------------------------------------------------------------------------------*/
/*--------------------------------------------------------------------------------------------------------*/


        /*
         here we use UnitOfWork class and IUnitOfWork interface that consist of instances of IcategoryRepository and CategoryRepository and (other repository also like product and user)
        You use the Unit of Work pattern because it allows you to group multiple repositories (like CategoryRepository, ProductRepository, OrderRepository, etc.) under one shared interface.
        */

        private readonly IUnitOfWork _unitOfWork;
        // here dependency injection is used to inject the UnitOfWork class instance
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // here unitofwork consist of category instance of ICategoryRepository which is CategoryRepository which extends the IRepository interface that has all methods except the update method
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        // this is basically the get action method 
        public IActionResult NewC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewC(Category obj)
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save(); // here it will actually go to the database and create that category
                // here it says after adding and saving redirect to index action of category controller
                // tempdata is used if we have to display notification message on next page then add value in tempdata
                TempData["success"] = "Category Create Successfully!";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }

        }

        // this is basically the get action method 
        public IActionResult Edit(int? id)
        {// we need the id the user wants to edit 
            if (id == null || id == 0)
            {
                return NotFound(); // if the id is not found then return not found
            }
            //here we have to retrive the category from the database using the id
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                // tempdata is used if we have to display notification message on next page 
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            // tempdata is used if we have to display notification message on next page then add value in tempdata
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index", "Category");

        }

        

    }
}
