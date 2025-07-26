using System.Diagnostics;
using Bulky_DataAccess.Repository.IRepository;
using Bulky_Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Customer.Controllers
{
    // here we need to specify to which area this controller belongs to
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger ,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // action methods that decides that view need to be returned back 
        public IActionResult Index()
        {// when the url is hit it renders here to the controller and action name and execute the function
            // so on Home/Index this information will be shown
            //return View("Privacy");

            // we have to display the list of products
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperty: "Category");
            return View(productList);
        }

        public IActionResult Details(int? productid)
        {
            Product p = _unitOfWork.Product.Get(u => u.Id == productid ,includeProperty:"Category");
            return View(p);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
