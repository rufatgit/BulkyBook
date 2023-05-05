using Microsoft.AspNetCore.Mvc;
using BulkyBookWEB.Data;
using BulkyBookWEB.Models;

namespace BulkyBookWEB.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST  
        [HttpPost]                   //Attributes
        [ValidateAntiForgeryToken]        //Cross-Site request forgery    
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }



        //GET
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDB = _db.Categories.Find(id);  //with Entity Framework
            // var categoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDBSingle=_db.Categories.SingleOrDefault(u=>u.Id==id);

            if (categoryFromDB == null) 
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //POST  
        [HttpPost]                   //Attributes
        [ValidateAntiForgeryToken]        //Cross-Site request forgery   
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }



        //GET
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDB = _db.Categories.Find(id);  //with Entity Framework
            // var categoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDBSingle=_db.Categories.SingleOrDefault(u=>u.Id==id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //POST  
        [HttpPost, ActionName("Delete")]      //Add different name             //Attributes
        [ValidateAntiForgeryToken]        //Cross-Site request forgery   
        public IActionResult DeletePOST(int id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
             
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");

            
        }




    }
}
