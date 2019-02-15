using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class DeleteTodo : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteTodo(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<RedirectToPageResult> OnGetAsync(int todoId, int userId)
        {
            _context.Todos.Remove(_context.Todos.First(t => t.TodoId == todoId));
            _context.SaveChanges();
            return RedirectToPage("TodoList", new {id = userId});
        }
    }
}