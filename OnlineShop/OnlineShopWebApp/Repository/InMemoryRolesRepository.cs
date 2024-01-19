using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace OnlineShopWebApp.Repository
{
    public class InMemoryRolesRepository : IRolesRepository
	{
		private readonly List<Role> roles = new List<Role>();
		public void Add(Role role)
		{
			roles.Add(role);
		}

		public List<Role> GetAll()
		{
			return roles;
		}

		public Role TryGetByName(string name)
		{
            return roles.FirstOrDefault(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
		}

		public void Remove(int roleId)
		{
			roles.RemoveAll(x => x.Id == roleId);
		}
	}
}
