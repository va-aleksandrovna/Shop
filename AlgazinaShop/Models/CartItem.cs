using Microsoft.AspNetCore.Mvc;

namespace AlgazinaShop.Models
{
    public class CartItem
    {
        public ProductModel Product { get; set; }
        public int Sum { get; set; }
        public int Count { get; set; }

        public CartItem() { }
        public CartItem(ProductModel product)
        { 
            Product = product;
            Count++;
            Sum = Product.Price * Count;
        }
    }
}
