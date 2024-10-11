using AlgazinaShop.Data;
using System.Linq;

namespace AlgazinaShop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public int Sum { get; set; }

        public Cart() { }

        public Cart(CartItem item)
        {
            Items.Add(item);
            Sum = Items.Sum(x => x.Sum);
        }

        public void Add(int id)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var product = productsRepository.GetById(id);
            var cartItem = Items.FirstOrDefault(item => item.Product.Id == id);
            if (cartItem == null)
            {
                cartItem = new CartItem(product);
                Items.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
                cartItem.Sum = cartItem.Product.Price * cartItem.Count;
            }
            Sum = Items.Sum(s => s.Sum);

        }

        public void Delete(int id)
        {
            var cartItem = Items.FirstOrDefault(item => item.Product.Id == id);
            if (cartItem != null)
            {
                Items.Remove(cartItem);
            }
            Sum = Items.Sum(s => s.Sum);
        }

        public void DeleteAll()
        {
            Items.Clear();
            Sum = Items.Sum(s => s.Sum);
        }

        public void Update(int id, int count)
        {
            var cartItem = Items.FirstOrDefault(item => item.Product.Id == id);
            if(count < 1)
            {
                count = 1;
            }
            cartItem.Count = count;
            cartItem.Sum = cartItem.Product.Price * cartItem.Count;
            Sum = Items.Sum(s => s.Sum);
        }
    }
}
