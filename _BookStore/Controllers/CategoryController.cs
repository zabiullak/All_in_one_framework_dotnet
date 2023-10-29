using _BookStore.Data;
using _BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace _BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCatList = _db.Categories.ToList();
            return View(objCatList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
