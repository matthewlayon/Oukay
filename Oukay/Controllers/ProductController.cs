using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oukay.Data;
using Oukay.Models;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace Oukay.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Products.Include(p => p.Category).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product record, IFormFile ImagePath)
        {
            var selectedCategory = _context.Categories.
                Where(c => c.CatId == record.CatId).SingleOrDefault();

            var product = new Product()
            {
                Name = record.Name,
            Description = record.Description,
            Price = record.Price,
            Available = 0,
            DateAdded = DateTime.Now,
            Status ="Active",
            Category = selectedCategory,
            CatId= record.CatId


        };
            
            if(ImagePath != null)
            {
                if(ImagePath.Length >0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/products", ImagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    product.ImagePath = ImagePath.FileName;
                }
            }



            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();
            if(product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Product record)
        {
            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();

            var selectedCategory = _context.Categories.Where(c => c.CatId == record.CatId).SingleOrDefault();

            product.Name = record.Name;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Available = 0;
            product.DateAdded = DateTime.Now;
            product.Status = "Active";
            product.Category = selectedCategory;
            product.CatId = record.CatId;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(p => p.ProductId == id).SingleOrDefault();
            if(product == null)
            {
                return RedirectToAction("Index");
            }


            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
