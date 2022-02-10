using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            //Populando a categoria a ser deletada na propriedade temporaria "Category"
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            
                var categoryFromDb = _db.Category.Find(Category.Id);

                if (categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Category deleted successfully";
                    return RedirectToPage("Index");
                }
                return Page();
                
            
          
        }
    }
}
