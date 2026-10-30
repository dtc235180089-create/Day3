using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3.Models;
namespace Day3.Controllers
{
    public class CategoryController : Controller
    {
        //Gia lap CSDL

        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" }
        };  

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(b => b.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                //themcate
               int newId =_categories.Any() ? _categories.Max(b => b.Id) + 1 : 1;
                category.Id = newId;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(b => b.Id == category.Id);
            if(existingCategory == null)
            {
                return NotFound();
            }
            return View(existingCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var category = _categories.FirstOrDefault(b => b.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                // Update the category with the new values from the form
                category.Name = collection["Name"];
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(b => b.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var category = _categories.FirstOrDefault(b => b.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                _categories.Remove(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
