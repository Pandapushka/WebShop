namespace OnlineShopWebApp.Models
{
    public class UserAccount
    {
        private static int id = 1;
        public int Id { get; }
        public string Login { get; set; }
        public string Pasword { get; set; }
        public string Phone { get; set; }
        public UserAccount()
        {
            Id = id;
            id++;
        }

    }
}
