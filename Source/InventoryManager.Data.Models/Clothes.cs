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

        public string Name { get; set; }

        public ClothesType Type { get; set; }

        public double Quantity { get; set; }

        public SizeType Size { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
