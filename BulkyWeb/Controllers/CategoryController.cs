using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
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
            //return all category information and display it as a list
            List<Category> objCategoryList = _db.Categories.ToList();//pass this obj to view below and fetch in view to display
            return View(objCategoryList);
        }

        //Create Category Action Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]//indicates that the following method will recieve the info users enter in the category form
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //custom validation
                ModelState.AddModelError("name", "The DisplayOrder can't exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);//adds the retrieved category that user enters to db
                _db.SaveChanges();//makes the change above and saves it
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");//goes back to index action after adding the new category
            }
            return View();
        }


        //Edit Category Action Method
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //another method to use: FirstOrDefault() / Where().FirstOrDefault()
            Category? categoryFromDb = _db.Categories.Find(id); 

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]//indicates that the following method will recieve the info users enter in the category form
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //adds the retrieved category that user enters to db
                _db.Categories.Update(obj);
                //makes the change above and saves it
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                //goes back to index action after adding the new category
                return RedirectToAction("Index");
            }
            return View();
        }


        //Delete Category Action Method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //another method to use: FirstOrDefault() / Where().FirstOrDefault()
            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]//adding an actionname will prevent confusion between both delete methods
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            //goes back to index action after adding the new category
            return RedirectToAction("Index");
        }
    }
}
