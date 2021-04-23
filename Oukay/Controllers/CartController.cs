using Microsoft.AspNetCore.Mvc;
using Oukay.Data;
using Oukay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oukay.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult OrderNow(int? id)
        //{
        //    //if(id == null)
        //    //{
        //    //    return new HttpStatusCodeResult
        //    //List<Cart> lsCart = new List<Cart>
        //    //{
        //    //    new Cart(_context.Products.Find(id),1)
        //    //};
        //    return View("Index");
        //}
    }
}
