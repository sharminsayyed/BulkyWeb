using Bulky_DataAccess.Repository.IRepository;
using Bulky_Models;
using Bulky_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        // using IUnitOFWork here 
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // get all the list of products 
            List<Product> productList = _unitOfWork.Product.GetAll().ToList();
           
            return View(productList);
        }

        // GET - Create and update 
        public IActionResult Upsert(int? id) {
            // we also have to pass the list of Categories to the view ab 
            // here we use projection (efcore) to convert the list of categories to a list of SelectListItem
            //used in ASP.NET Core MVC when you want to populate a dropdown list in a form, like when creating or editing a Product and selecting its Category.
            IEnumerable<SelectListItem> categorylist = _unitOfWork.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            // passing can be done in multiple ways 
            // we are passing the list of categories to the view using ViewBag
            // ViewBag is a dynamic object that allows you to pass data from the controller to the view
            // key = value
            //ViewBag.categorylist = categorylist;

            // ViewData - we have to some conversion here 
            // explicit conversion is required 
            // viewdbag internally inserts the data into ViewData dictionary.so the key of ViewData and property of viewbag must not match 
            //ViewData["CategoryList"] = categorylist;

            // instead we use view model -- in models folder
            // view model is specific for view 
            // ProductVM is product view model in models -> view models folder
            ProductVM productVM = new ProductVM()
            {
                categorylist = categorylist,
                Product = new Product()
            };

            if (id == null || id == 0)
            { // here we create the new product 
                return View(productVM);
            }
            else
            {
                // here we update the existing product 
                // fetching the obj from db
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                //if (productVM.Product == null) { return NotFound(); }
                return View(productVM);
            }
        }

        // POST - Create
        [HttpPost]
        public IActionResult Upsert(ProductVM obj , IFormFile file)
        {
            // here product.Category , product.CategoryList are invalid as we do not fill them in the form  
            // and we dont want to valid these 2 categories we use [Bind] attribute to ignore these 2 properties [ValidateNever]
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //// GET - Edit
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0) { return NotFound(); }
        //    // here we the obj from db
        //    Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (obj == null) { return NotFound(); }
        //    return View(obj);
        //}

        //// POST - Edit
        //[HttpPost]
        //public IActionResult Edit(Product obj)
        //{
        //    if (ModelState.IsValid)
        //    { 
        //        // here we update the given obj in db 
        //        _unitOfWork.Product.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product updated successfully";
        //        return RedirectToAction("Index"); 
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if(id == null | id == 0) { return NotFound(); }
            // fetching the obj from db
            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null) { return NotFound(); }
            return View(obj);
        }

        // POST - Delete
        [HttpPost]
        public IActionResult Delete(Product obj)
        {
            // removing the given obj from db 
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
