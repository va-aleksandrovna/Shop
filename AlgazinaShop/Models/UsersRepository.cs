using AlgazinaShop.Data;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AlgazinaShop.Models
{
    public class UsersRepository
    {
        public List<UserModel> GetAll()
        {
            List<UserModel> users = new List<UserModel>();
            using (AlgazinaShopContext bd = new AlgazinaShopContext())
            {
                users = bd.Users.Select(List => new UserModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    Login = List.Login,
                    Password = List.Password,
                    Admin = List.Admin
                }).ToList();
            }
            return users;
        }

		public UserModel GetAuthUser(UserModel model)
		{
			List<UserModel> users = GetAll();
			UserModel user = users.Where(item => item.Login == model.Login && item.Password == model.Password).FirstOrDefault();
			return user;
		}

		public UserModel GetById(int id)
        {
            List<UserModel> users = new List<UserModel>();
            using (AlgazinaShopContext bd = new AlgazinaShopContext())
            {
                users = bd.Users.Select(List => new UserModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    Login = List.Login,
                    Password = List.Password,
					Admin = List.Admin
				}).ToList();
            }

            var user = users.Find(p => p.Id == id);
            return user;
        }
    }
}
