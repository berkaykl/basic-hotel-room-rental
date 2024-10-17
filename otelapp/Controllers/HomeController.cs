using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using otelapp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace otelapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var entities = _context.KiralikOteller.ToList();
            return View(entities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyEntity entity)
        {
            if (ModelState.IsValid)
            {
                _context.KiralikOteller.Add(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }




        [HttpPost]
        public IActionResult Kirala(int otelId, string otelMetin, string otelGorsel)
        {
            var kiralananOtel = new otelapp.Models.KiralananOtel
            {
                KiralananOtelId = otelId,
                KiralananOtelMetin = otelMetin,
                KiralananOtelGorsel = otelGorsel
            };

            _context.KiralananOteller.Add(kiralananOtel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }


        public IActionResult KiralananOteller()
        {
            var kiralananOteller = _context.KiralananOteller.ToList();
            return View(kiralananOteller);
        }



        [HttpPost]
        public IActionResult IptalEt(int id)
        {
            var kiralananOtel = _context.KiralananOteller.Find(id);
            if (kiralananOtel != null)
            {
                _context.KiralananOteller.Remove(kiralananOtel);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(KiralananOteller));
        }


    }
}