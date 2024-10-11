namespace AlgazinaShop.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
		public string Error { get; set; }
		public bool? Admin { get; set; }

		public UserModel()
        {

        }    

        public UserModel(int id, string name, string login, string password, string error, bool admin)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            Error = error;
            Admin = admin;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Имя: " + Name + " Login: " + Login + "Пароль: " + Password + Admin;
        }
    }
}
