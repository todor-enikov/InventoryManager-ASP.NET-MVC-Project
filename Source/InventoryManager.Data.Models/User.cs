using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Clothes> clothes;

        public User()
        {
            this.clothes = new HashSet<Clothes>();
        }

        [Key]
        public override string Id { get; set; }

        [EmailAddress]
        public override string Email { get; set; }

        [Index(IsUnique = true)]
        public override string UserName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length is 5 symbols!")]
        [MaxLength(20, ErrorMessage = "The maximum length is 20 symbols!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length is 5 symbols!")]
        [MaxLength(20, ErrorMessage = "The maximum length is 20 symbols!")]
        public string LastName { get; set; }

        public virtual ICollection<Clothes> Clothes
        {
            get { return this.clothes; }
            set { this.clothes = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
