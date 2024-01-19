using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Delete(Product product, string userId);
        void Clear(string userId);
    }
}
