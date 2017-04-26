using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Models
{
    public class Clothes
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length is 5 symbols!")]
        [MaxLength(100, ErrorMessage = "The maximum length is 100 symbols!")]
        public string Name { get; set; }

        [Required]
        public ClothesType Type { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "The quantity should be between 1 and 10 quantities!")]
        public double Quantity { get; set; }

        [Required]
        public SizeType Size { get; set; }

        [Required]
        [Range(0.01, 1000, ErrorMessage = "The price should be between 0.01 and 1000 $!")]
        public decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length is 5 symbols!")]
        [MaxLength(1000, ErrorMessage = "The maximum length is 1000 symbols!")]
        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
