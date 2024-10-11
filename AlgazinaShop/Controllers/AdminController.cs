using AlgazinaShop.Data;
using AlgazinaShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO.Pipelines;
using System.Numerics;

namespace AlgazinaShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
		public IActionResult Index()
		{
            UsersRepository productsRepository = new UsersRepository();
            var product = productsRepository.GetById(1);

            return View();
		}

        public IActionResult GetProducts()
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var products = productsRepository.GetAll();

            return View(products);
        }

        public IActionResult GetUsers()
        {
            UsersRepository usersRepository = new UsersRepository();
            var users = usersRepository.GetAll();

            return View(users);
        }

        public IActionResult EditUser(int id)
        {
            UsersRepository usersRepository = new UsersRepository();
            var user = usersRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaShopContext(); // создание экземпляра контекста
                var user = context.Users.FirstOrDefault(u => u.Id == model.Id);
                user.Name = model.Name;
                user.Login = model.Login;
                user.Password = model.Password;
                user.Admin = model.Admin;
                //context.Users.Update(newUser);
                context.SaveChanges();

                return RedirectToAction("GetUsers", "Admin");
            }
            return View(model);
        }

        public IActionResult DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaShopContext(); // создание экземпляра контекста
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                context.Users.Remove(user);
                context.SaveChanges();

                return RedirectToAction("GetUsers", "Admin");
            }
            return View("GetUsers");
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserModel userReg)
        {
            if (ModelState.IsValid)
            {
                // Создание нового пользователя и сохранение его в базу данных
                User newUser = new User
                {
                    Name = userReg.Name,
                    Login = userReg.Login,
                    Password = userReg.Password,
                    Admin = userReg.Admin
                };
                // Сохранение нового пользователя в базе данных
                var context = new AlgazinaShopContext(); // создание экземпляра контекста
                context.Users.Add(newUser); // добавление нового пользователя
                context.SaveChanges(); // сохранение изменений в базе данных

                return RedirectToAction("GetUsers", "Admin");
            }
            return View(userReg);
        }

        [HttpPost]
        public IActionResult AddProductCategory(string type)
        {
            switch (type)
            {
                case "photo":
                    {
                        return RedirectToAction("AddProductPhoto", "Admin");
                    }
                case "obectiv":
                    {
                        return RedirectToAction("AddProductObectiv", "Admin");
                    }
                case "action":
                    {
                        return RedirectToAction("AddProductAction", "Admin");
                    }
            }
            return View(type);
        }

        public IActionResult AddProductPhoto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductPhoto(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    var context = new AlgazinaShopContext(); // создание экземпляра контекста
                    var category = context.Categories.FirstOrDefault(u => u.Name == product.Category);
                    var brend = context.Brands.FirstOrDefault(u => u.Name == product.Brend);

                    // Создание нового пользователя и сохранение его в базу данных
                    Product newproduct = new Product
                    {
                        Id = product.Id,
                        Category = category,
                        Brand = brend,
                        Model = product.Model,
                        Price = product.Price,
                        Description = product.Description,
                        Image = product.Image,
                        CropFactor = product.CropFactor,
                        FullFrame = product.FullFrame,
                        Lens = product.Lens,
                        FocalLength = product.FocalLength,
                        TypeOfFocalLength = product.TypeOfFocalLength,
                        ViewingAngle = product.ViewingAngle,
                        DiagonalDisplay = product.DiagonalDisplay,
                        MaxNumberOfFrames = product.MaxNumberOfFrames,
                        WaterResistance = product.WaterResistance,
                        NumberOfMegapixels = product.NumberOfMegapixels,
                        Bayonet = product.Bayonet
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Products.Add(newproduct); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("GetProducts", "Admin");
                }
            }
            return View(product);
        }

        public IActionResult AddProductObectiv()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductObectiv(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    var context = new AlgazinaShopContext(); // создание экземпляра контекста
                    var category = context.Categories.FirstOrDefault(u => u.Name == product.Category);
                    var brend = context.Brands.FirstOrDefault(u => u.Name == product.Brend);

                    // Создание нового пользователя и сохранение его в базу данных
                    Product newproduct = new Product
                    {
                        Id = product.Id,
                        Category = category,
                        Brand = brend,
                        Model = product.Model,
                        Price = product.Price,
                        Description = product.Description,
                        Image = product.Image,
                        CropFactor = product.CropFactor,
                        FullFrame = product.FullFrame,
                        Lens = product.Lens,
                        FocalLength = product.FocalLength,
                        TypeOfFocalLength = product.TypeOfFocalLength,
                        ViewingAngle = product.ViewingAngle,
                        DiagonalDisplay = product.DiagonalDisplay,
                        MaxNumberOfFrames = product.MaxNumberOfFrames,
                        WaterResistance = product.WaterResistance,
                        NumberOfMegapixels = product.NumberOfMegapixels,
                        Bayonet = product.Bayonet
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Products.Add(newproduct); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("GetProducts", "Admin");
                }
            }
            return View(product);
        }

        public IActionResult AddProductAction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductAction(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    var context = new AlgazinaShopContext(); // создание экземпляра контекста
                    var category = context.Categories.FirstOrDefault(u => u.Name == product.Category);
                    var brend = context.Brands.FirstOrDefault(u => u.Name == product.Brend);

                    // Создание нового пользователя и сохранение его в базу данных
                    Product newproduct = new Product
                    {
                        Id = product.Id,
                        Category = category,
                        Brand = brend,
                        Model = product.Model,
                        Price = product.Price,
                        Description = product.Description,
                        Image = product.Image,
                        CropFactor = product.CropFactor,
                        FullFrame = product.FullFrame,
                        Lens = product.Lens,
                        FocalLength = product.FocalLength,
                        TypeOfFocalLength = product.TypeOfFocalLength,
                        ViewingAngle = product.ViewingAngle,
                        DiagonalDisplay = product.DiagonalDisplay,
                        MaxNumberOfFrames = product.MaxNumberOfFrames,
                        WaterResistance = product.WaterResistance,
                        NumberOfMegapixels = product.NumberOfMegapixels,
                        Bayonet = product.Bayonet
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Products.Add(newproduct); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("GetProducts", "Admin");
                }
            }
            return View(product);
        }

        public IActionResult EditProduct(int id)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var product = productsRepository.GetById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    var context = new AlgazinaShopContext(); // создание экземпляра контекста
                    var category = context.Categories.FirstOrDefault(u => u.Name == product.Category);
                    var brend = context.Brands.FirstOrDefault(u => u.Name == product.Brend);
                    var newproduct = context.Products.FirstOrDefault(u => u.Id == product.Id);
                    newproduct.Id = product.Id;
                    newproduct.Category = category;
                    newproduct.Brand = brend;
                    newproduct.Model = product.Model;
                    newproduct.Price = product.Price;
                    newproduct.Description = product.Description;
                    newproduct.Image = product.Image;
                    newproduct.CropFactor = product.CropFactor;
                    newproduct.FullFrame = product.FullFrame;
                    newproduct.Lens = product.Lens;
                    newproduct.FocalLength = product.FocalLength;
                    newproduct.TypeOfFocalLength = product.TypeOfFocalLength;
                    newproduct.ViewingAngle = product.ViewingAngle;
                    newproduct.DiagonalDisplay = product.DiagonalDisplay;
                    newproduct.MaxNumberOfFrames = product.MaxNumberOfFrames;
                    newproduct.WaterResistance = product.WaterResistance;
                    newproduct.NumberOfMegapixels = product.NumberOfMegapixels;
                    newproduct.Bayonet = product.Bayonet;

                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("GetProducts", "Admin");
                }
            }
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaShopContext(); // создание экземпляра контекста
                var product = context.Products.FirstOrDefault(u => u.Id == id);
                context.Products.Remove(product);
                context.SaveChanges();

                return RedirectToAction("GetProducts", "Admin");
            }
            return View("GetProducts");
        }
    }
}