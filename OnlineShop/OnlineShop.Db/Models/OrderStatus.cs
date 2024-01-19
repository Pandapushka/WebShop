using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Db.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "В обработке")]
        Processed,
        [Display(Name = "Доставляется")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Отменён")]
        Canceled
    }
}