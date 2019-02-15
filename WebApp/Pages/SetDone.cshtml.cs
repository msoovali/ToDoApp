using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class SetDone : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public SetDone(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<RedirectToPageResult> OnGetAsync(int userId, int id)
        {
            var todo = await _context.Todos.FirstAsync(t => t.TodoId == id);
            todo.Done = !todo.Done;
            _context.Update(todo);
            _context.SaveChanges();
            return RedirectToPage("TodoList", new {id = userId});
        }
    }
}