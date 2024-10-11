using AlgazinaShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlgazinaShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            
            return View("Index", cart);
        }

        public IActionResult Add(int id)
        {

            var cart = (Cart) HttpContext.Session.Get <Cart> ("Cart");
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.Add(id);
            HttpContext.Session.Set ("Cart", cart);

            return View("Index", cart);
        }

        public IActionResult Delete(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.Delete(id);
                HttpContext.Session.Set("Cart", cart);
            }

            return View("Index", cart);
        }

        public IActionResult DeleteAll()
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.DeleteAll();
                HttpContext.Session.Set("Cart", cart);
            }

            return View("Index", cart);
        }

        public IActionResult Update(int id, int count)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.Update(id, count);
                HttpContext.Session.Set("Cart", cart);
            }

            return View("Index", cart);
        }

        public IActionResult UpdateMinus(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == id);
                int count = cartItem.Count - 1;
                cart.Update(id, count);
                HttpContext.Session.Set("Cart", cart);
            }

            return View("Index", cart);
        }

        public IActionResult UpdatePlus(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == id);
                int count = cartItem.Count + 1;
                cart.Update(id, count);
                HttpContext.Session.Set("Cart", cart);
            }

            return View("Index", cart);
        }

        public IActionResult Checkout()
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");

            return View("Checkout", cart);
        }

        public IActionResult Checkout2(Order order)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            order.Items = new List<CartItem>(cart.Items);
            order.Sum = cart.Sum;
            cart.DeleteAll();
            HttpContext.Session.Set("Cart", cart);
            return View(order);
        }
    }
}
