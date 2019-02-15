using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class NewTodo : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public NewTodo(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        public User MyUser { get; set; }

        public async Task OnGetAsync(int id)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(u => u.UserId == id), "CategoryId", "CategoryName");
            MyUser = await _context.Users.FirstAsync(u => u.UserId == id);
        }

        [BindProperty]
        public Todo Todo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todos.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("TodoList", new {id = Todo.UserId});
        }
    }
}