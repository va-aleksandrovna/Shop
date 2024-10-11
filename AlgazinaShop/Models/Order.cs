using AlgazinaShop.Data;
using static System.Net.Mime.MediaTypeNames;

namespace AlgazinaShop.Models
{
    public class Order
    {
        //public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<CartItem> Items { get; set; }
        public int Sum { get; set; }

        public Order()
        {

        }

        public Order(string name, string email, string phone, List<CartItem> items, int sum)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Items = items;
            Sum = sum;
        }

        //public override string ToString()
        //{
        //    return "Имя: " + Name + " Email: " + Email + " Телефон: " + Phone + " Список: " + " Цена: " + Sum;
        //}
    }
}
