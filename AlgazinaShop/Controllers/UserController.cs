using AlgazinaShop.Data;
using AlgazinaShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace AlgazinaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registration(UserModel userReg)
        {
            if (ModelState.IsValid)
            {
                // Создание нового пользователя и сохранение его в базу данных
                User newUser = new User
                {
                    Name = userReg.Name,
                    Login = userReg.Login,
                    Password = userReg.Password
                };
                // Сохранение нового пользователя в базе данных
                var context = new AlgazinaShopContext(); // создание экземпляра контекста
                context.Users.Add(newUser); // добавление нового пользователя
                context.SaveChanges(); // сохранение изменений в базе данных

                UserModel authInfo = new UserModel
                {
                    Login = userReg.Login,
                    Password = userReg.Password
                };

                // Вызов метода авторизации
                IActionResult authResult = Index(authInfo) as RedirectToActionResult;

                return authResult;
            }
            return View(userReg);
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserModel userAuth = new UserModel();
            return View(userAuth);
        }

        [HttpPost]
        public IActionResult Index(UserModel userAuth)
        {
			UsersRepository rep = new UsersRepository();
			UserModel user = rep.GetAuthUser(userAuth);
            if (user == null)
            {
                userAuth.Error = "Некорректно введен логин или пароль!";
                return View(userAuth);
            }
            if (user.Admin == true)
            {
				HttpContext.Session.Set<UserModel>("User", user);
				return RedirectToAction("GetProducts", "Admin");
			}
            else
            {
				HttpContext.Session.Set<UserModel>("User", user);
				return RedirectToAction("Index", "Home");
			}
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.DeleteAll();
                HttpContext.Session.Set("Cart", cart);
            }
            return RedirectToAction("Index", "User");
        }


    }
}