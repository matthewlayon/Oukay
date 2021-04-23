using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oukay.Models
{   
   
    public class Contact
    {
         
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Subject { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format.")]
        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }
    }
}
