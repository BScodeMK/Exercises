﻿using Microsoft.AspNetCore.Mvc;
using Ogani.Data;
using Ogani.Data.Entities;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Categories", "Console");
            }
            else
            {
                Category? category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (category == null)
                {
                    return RedirectToAction("Categories", "Console");
                }
                else
                {
                    return View(category);
                }
            }
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category? category)
        {
            if(category == null)
            {
                return RedirectToAction("Categories", "Console");
            }
            else
            {
                try
                {
                    Category newCategory = new Category(category.CategoryName, category.CategoryDescription);
                    _context.Categories.Add(newCategory);
                    _context.SaveChanges();

                    return RedirectToAction("Categories", "Console");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Console", ex);
                }
               
            }
        }

        //GET Admin/Category/Delete
        public IActionResult Delete(Guid? id)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
                return RedirectToAction("Categories", "Console");
            else
                return View(category);
        }

        //POST Admin/Category/Delete/B67F3EB8-861A-4701-977D-020221F3F21B
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(Guid? id)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (category == null)
                return RedirectToAction("Categories", "Console");
            else
            {
                try
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return RedirectToAction("Categories", "Console");
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException("Category not found", ex.InnerException);
                }
               
            }
        }
    }
}
