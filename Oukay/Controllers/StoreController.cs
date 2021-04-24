using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oukay.Data;
using Oukay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Oukay.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        //List<Cart> li = new List<Cart>();
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var list = _context.Products.ToList();



            return View(list);
        }

        public IActionResult Order()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {

            var list = _context.Products.ToList();
            using (MailMessage mail = new MailMessage("mattlayon@gmail.com", order.Email))
            {
                string subject = "Order Detail";
                mail.Subject = subject;
                string message = "Hello, " + order.FullName + "! <br/><br/>" +
                    "Your Order has been successful. Here are the details: <br/><br/>" +
                    "Address: <strong>" + order.Address + "</strong><br/><br/>" +
                     "Phone: <strong>" + order.Phone + "</strong><br/><br/>" +
                     
                     "We will contact you once it it's delivered and we only accept Cash on Delivery <br/><br/>" +
                     "Thank you for shopping at Oukay!";
                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred =
                        new NetworkCredential("mattlayon@gmail.com", "JanMatthewLayon041300!");

                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Order sent";
                }
            }

            var email = new Order()
            {
                FullName = order.FullName,
                Address = order.Address,
                Phone = order.Phone,
                Email = order.Email
            };
            _context.Orders.Add(email);
            _context.SaveChanges();
            return View();
        }




        //public IActionResult AddtoCart(int id)
        //{
        //    var list = _context.Products.Where(x => x.ProductId == id).SingleOrDefault();




        //    return View(list);
        //}

       
        public IActionResult AddtoCart(int? id, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // get user id of the person who logged in
            var user =  _context.Users.Where(u => u.Id == userId).SingleOrDefault();

            Product p = _context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            if (p == null) // product is not existing
                return RedirectToAction("Order");

            var cart = new CartDetail()
            {
                Product = p,
                User = user,
                Quantity = quantity,
                Amount = p.Price,
                CartId = 0
               
            };

            _context.CartDetails.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Order");

        }

        //public IActionResult Checkout()
        //{
        //    return View();
        //}
        //public IActionResult CategoryMenu()
        //{
        //    var categories = _context.Categories.ToList();
        //    return PartialView(categories);

        //}
        //public IActionResult Browse(string category)
        //{
        //    var categoryModel = _context.Categories.Include("Product")
        //        .Single(c => c.Name == category);
        //    return View(categoryModel);
        //}
        //public IActionResult Details(int id)
        //{
        //    var product = _context.Products.Find(id);
        //    return View(product);
        //}

    }
}
