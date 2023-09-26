using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ogani.Areas.Admin.Models;
using Ogani.Data;
using Ogani.Data.Entities;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConsoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ConsoleController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products(int page = 1, int pageSize = 10)
        {
            try
            {
                var totalCount = await _db.Products.CountAsync();
                var products = await _db.Products
                    .OrderBy(p => p.DateOfCreation) // You can order products as needed
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var model = new ProductListViewModel
                {
                    Products = products,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalCount = totalCount
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError(string.Empty, "An error occurred while fetching products.");
                return View(new ProductListViewModel());
            }
        }

        public async Task<IActionResult> Categories()
        {
            List<Category> products = await _db.Categories.ToListAsync();
            return View(products);
        }
    }

 
}
