using AlgazinaShop.Data;
using AlgazinaShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace AlgazinaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string search = null, string sort = null, string category = null, string brend = null,
            int minprice = 100, int maxprice = 2999999, float? cropfactor = 0, string fullframe = null, string lens = null,
            string bayonet = null, string type = null, int minfocus = 3, int maxfocus = 601, double minmp = 11, double maxmp = 62,
            double minangle = 0, double maxangle = 181, string water = null, double mindiagonal = 0, double maxdiagonal = 10,
            int frame = 0)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            ProductsRepository productsRepository = new ProductsRepository();

            if (minprice > maxprice)
            {
                minprice = maxprice;
            }

            if (minmp > maxmp)
            {
                minmp = maxmp;
            }

            if (minfocus > maxfocus)
            {
                minfocus = maxfocus;
            }

            if (minangle > maxangle)
            {
                minangle = maxangle;
            }

            if (mindiagonal > maxdiagonal)
            {
                mindiagonal = maxdiagonal;
            }

            var products = productsRepository.GetAll(search, sort, category, brend, minprice, maxprice, cropfactor, fullframe, lens,
            bayonet, type, minfocus,  maxfocus,  minmp,  maxmp, minangle, maxangle, water, mindiagonal, maxdiagonal, frame);

            ViewBag.Search=search;
            ViewBag.Sort = sort;
            ViewBag.Category = category;
            //ViewBag.ListBrend = productsRepository.GetBrend();
            ViewBag.Brend = brend;
            ViewBag.Minprice = minprice;
            ViewBag.Maxprice = maxprice;

            //ViewBag.ListCropfactor = productsRepository.GetCropfactor();
            ViewBag.Cropfactor = cropfactor;
            ViewBag.Fullframe = fullframe;
            ViewBag.Lens = lens;
            //ViewBag.ListBayonet = productsRepository.GetBayonet();
            ViewBag.Bayonet = bayonet;
            ViewBag.Minmp = minmp;
            ViewBag.Maxmp = maxmp;

            ViewBag.TypeOfFocalLength = type;
            ViewBag.Minfocus = minfocus;
            ViewBag.Maxfocus = maxfocus;
            ViewBag.Minangle = minangle;
            ViewBag.Maxangle = maxangle;

            ViewBag.Water = water;
            ViewBag.Mindiagonal = mindiagonal;
            ViewBag.Maxdiagonal = maxdiagonal;
            ViewBag.Frame = frame;

            return View(products);
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

        public ContentResult GetString()
        {
            string str = "";
            str = "<h1>Algazina</h1>";

            return Content(str, "text/html");
        }

        public IActionResult Algazina()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var product = productsRepository.GetById(id);

            HttpContext.Session.Set("name", product);

            return View(product);
        }

        public IActionResult PostProduct()
        {

            return View();
        }

        public IActionResult PostProduct2(ProductModel product)
        {
            return View(product);
        }

    }
}