using Aflevering1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aflevering1.MVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemDbContext _dbcontext;
        public ItemController(ItemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _dbcontext.Items.ToList();
            return View(items);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var placements = _dbcontext.Placements.ToList();
            var units = _dbcontext.Units.ToList();
            ItemAndPlacementData data = new ItemAndPlacementData();            
            data.Placements = placements;
            data.Units = units;
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var item = _dbcontext.Items.Find(id);
            var placements = _dbcontext.Placements.ToList();
            var units = _dbcontext.Units.ToList();
            ItemAndPlacementData data = new ItemAndPlacementData();
            data.Item = item;
            data.Placements = placements;
            data.Units = units;
            return View(data);
        }
        public IActionResult Delete(int? id) 
        {
            var item = _dbcontext.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _dbcontext.Items.Find(id);
            _dbcontext.Items.Remove(item);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            _dbcontext.Items.Update(item);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            int itemId = 1;
            try
            {
                itemId = _dbcontext.Items.Select(x => x.Id).Max() + 1;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            item.Id = itemId;
            _dbcontext.Items.Add(item);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
