using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oukay.Data;
using Oukay.Models;
namespace Oukay.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Clothes.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clothes record)
        {
            var clothes = new Clothes();
            clothes.ClothesName = record.ClothesName;
            clothes.Description = record.Description;
            clothes.Price = record.Price;
            clothes.ClothesUrl = record.ClothesUrl;
            clothes.Type = record.Type;

            _context.Clothes.Add(clothes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            var clothes = _context.Clothes.Where(i => i.ClothesId == id).SingleOrDefault();
            if (clothes == null)
            {
                return RedirectToAction("Index");
            }

            return View(clothes);
        }


        [HttpPost]
        public IActionResult Edit(int? id, Clothes record)
        {
            //if(id == null)
            //{
            //    return RedirectToAction("Index");

            //}

            //var clothes = _context.Clothes.Where(i => i.ClothesId == id).SingleOrDefault();
            //if(clothes == null)
            //{
            //    return RedirectToAction("Index");
            //}

            //return View(clothes);
            var clothes = _context.Clothes.Where(i => i.ClothesId == id).SingleOrDefault();
            clothes.ClothesName = record.ClothesName;
            clothes.ClothesName = record.ClothesName;
            clothes.Description = record.Description;
            clothes.Price = record.Price;
            clothes.ClothesUrl = record.ClothesUrl;
            clothes.Type = record.Type;

            _context.Clothes.Update(clothes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var clothes = _context.Clothes.Where(i => i.ClothesId == id).SingleOrDefault();
            if(clothes == null)
            {
                return RedirectToAction("Index");
            }

            _context.Clothes.Remove(clothes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
