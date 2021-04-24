using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oukay.Data;
using Oukay.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Oukay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact record)
        {

           
            using (MailMessage mail = new MailMessage("mattlayon@gmail.com", record.Email))
            {
             
                mail.Subject = record.Subject;
                string message = "Hello, " + record.FullName + "! <br/><br/>" +
                    "We have receive your inquiry. Here are the details: <br/><br/>" +
                    "Contact Number: <strong>" + record.Phone + "</strong><br/><br/>" +
                     "Message: <strong>" + record.Message + "</strong><br/><br/>" +

                    
                     "Thank you for shopping at Oukay!";
                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred =
                        new NetworkCredential("mattlayon@gmail.com", "qwerty123!");
                 
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Inquiry sent";
                }
            }

            var contact = new Contact()
            {
                FullName = record.FullName,
                Message = record.Message,
                Subject = record.Subject,
                Phone = record.Phone,
                Email = record.Email
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return View();
        }

    }
}
