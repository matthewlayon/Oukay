using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Oukay.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0.00, 100000.00, ErrorMessage ="Invalid price range.")]
        public decimal Price { get; set; }

        [Display(Name="Image")]
        public string ImagePath { get; set; }
        public int Available { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime?  DateModified { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage = "Required.")]
        public virtual Category Category { get; set; }
        public  int? CatId { get; set; }
    }

    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string Name { get; set; }
    }
}
