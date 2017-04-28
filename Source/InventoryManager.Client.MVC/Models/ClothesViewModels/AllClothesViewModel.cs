using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManager.Client.MVC.Models.ClothesViewModels
{
    public class AllClothesViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ClothesType Type { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }
    }
}