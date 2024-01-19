using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repository
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(int roleId);
    }
}
