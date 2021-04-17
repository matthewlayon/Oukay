using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Oukay.Models
{
    public class Clothes
    {
        [Key]
        public int ClothesId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string ClothesName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal Price { get; set; }
        public string ClothesUrl { get; set; }

        [Display(Name ="Clothes Type")]
        public ClotheType Type { get; set; }

    }
    public enum ClotheType
    {
        Tops =1,
        Bottoms=2
    }
}
