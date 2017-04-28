using InventoryManager.Data.Models;
using InventoryManager.Data.Repositories;
using InventoryManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;

        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.userRepo.All();
        }

        public User GetUserById(string id)
        {
            return this.userRepo.GetById(id);
        }

        public IQueryable<User> GetUsersByUserName(string username)
        {
            return this.userRepo.GetUsersByUserName(username);
        }

        public void UpdateUserInformation(User userToUpdate)
        {
            this.userRepo.Update(userToUpdate);
            this.userRepo.SaveChanges();
        }
    }
}
