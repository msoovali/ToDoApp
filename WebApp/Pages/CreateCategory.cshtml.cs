using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class CreateCategory : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateCategory(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        

        public async Task OnGetAsync(int id)
        {
            UserId = id;
        }

        [BindProperty]
        public Category Category { get; set; }
        [BindProperty]
        public int UserId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("NewTodo", new {id = Category.UserId});
        }
    }
}