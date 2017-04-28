using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        IQueryable<User> GetUsersByUserName(string username);
    }
}
