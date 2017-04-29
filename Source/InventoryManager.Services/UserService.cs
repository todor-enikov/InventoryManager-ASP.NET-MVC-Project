using InventoryManager.Common;
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
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new NullReferenceException(ApplicationConstants.Repository);
            }

            this.userRepository = userRepository;
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.userRepository.All();
        }

        public User GetUserById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public IQueryable<User> GetUsersByUserName(string username)
        {
            return this.userRepository.GetUsersByUserName(username);
        }

        public void UpdateUserInformation(User userToUpdate)
        {
            this.userRepository.Update(userToUpdate);
            this.userRepository.SaveChanges();
        }
    }
}
