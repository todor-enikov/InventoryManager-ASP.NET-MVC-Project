using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManager.Client.MVC.Models.ClothesViewModels
{
    public class AddClothesViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public ClothesType Type { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "The quantity must be between {0} and {1}.")]
        public double Quantity { get; set; }

        [Required]
        public SizeType Size { get; set; }

        [Required]
        [Range(0.01, 1000, ErrorMessage = "The price should be between 0.01 and 1000 $!")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        [FileExtensions(Extensions = "jpg|jpeg|png|gif", ErrorMessage = "Please select a .jpg, .jpeg, .png or .gif file.")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}