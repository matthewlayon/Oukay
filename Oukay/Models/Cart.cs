using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Oukay.Models;
using Microsoft.AspNetCore.Mvc;

namespace Oukay.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public class CartDetail
    {
        [Key]
        public int CDId { get; set; }
        public int? CartId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
