using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        private static int id = 1;
        public int Id { get; }
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Поле роль должно содержать от 4 до 10 символов")]
        public string Name { get; set; }
        public Role()
        {
            Id = id;
            id++;
        }

    }
}
