using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oukay.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name ="Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format.")]
        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }

        public DateTime OrderDate { get; set; }
        public virtual Product Product { get; set; }

    }
}
