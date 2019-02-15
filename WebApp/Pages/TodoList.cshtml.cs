using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class TodoList : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public TodoList(DAL.AppDbContext context)
        {
            _context = context;
        }

        // public User User { get;set; }
        public IList<Todo> Todos { get; set; }
        [BindProperty]public User MyUser { get; set; }

        [BindProperty]public string Search { get; set; }

        public int Order { get; set; }

        public async Task OnGetAsync(int id, int? order, string search)
        {
            MyUser = await _context.Users.FirstAsync(u => u.UserId == id);

            var query = _context.Todos.Where(u => u.UserId == id)
                .Include(c => c.Category)
                .Include(u => u.User).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                Search = search.ToLower();
                query = query.Where(
                    c => c.Category.CategoryName.ToLower().Contains(Search) ||
                         c.Priority.ToString().Contains(Search) ||
                         c.Created.ToString(CultureInfo.CurrentCulture).Contains(Search) ||
                         c.DueDate.ToString(CultureInfo.CurrentCulture).Contains(Search) ||
                         c.HeadLine.ToLower().Contains(Search) ||
                         c.Description.ToLower().Contains(Search));
            }

            if (order > 0)
            {
                Order = order.Value;
            }
            


            switch (order)
            {
                case null:
                    query = query.OrderBy(u => u.Done);
                    break;
                case 1:
                    query = query.OrderByDescending(u => u.HeadLine).ThenBy(u => u.Done);
                    break;
                case 2:
                    query = query.OrderBy(u => u.HeadLine).ThenBy(u => u.Done);
                    break;
                case 3:
                    query = query.OrderByDescending(u => u.Description).ThenBy(u => u.Done);
                    break;
                case 4:
                    query = query.OrderBy(u => u.Description).ThenBy(u => u.Done);
                    break;
                case 5:
                    query = query.OrderByDescending(u => u.Created).ThenBy(u => u.Done);
                    break;
                case 6:
                    query = query.OrderBy(u => u.Created).ThenBy(u => u.Done);
                    break;
                case 7:
                    query = query.OrderByDescending(u => u.DueDate).ThenBy(u => u.Done);
                    break;
                case 8:
                    query = query.OrderBy(u => u.DueDate).ThenBy(u => u.Done);
                    break;
                case 9:
                    query = query.OrderByDescending(u => u.Done);
                    break;
                case 10:
                    query = query.OrderBy(u => u.Done);
                    break;
                case 11:
                    query = query.OrderByDescending(u => u.Priority).ThenBy(u => u.Done).ThenBy(u => u.PriorityNo);
                    break;
                case 12:
                    query = query.OrderBy(u => u.Priority).ThenBy(u => u.Done).ThenBy(u => u.PriorityNo);
                    break;
                case 13:
                    query = query.OrderByDescending(u => u.PriorityNo).ThenBy(u => u.Done);
                    break;
                case 14:
                    query = query.OrderBy(u => u.PriorityNo).ThenBy(u => u.Done);
                    break;
                case 15:
                    query = query.OrderByDescending(u => u.Category).ThenBy(u => u.Done);
                    break;
                case 16:
                    query = query.OrderBy(u => u.Category).ThenBy(u => u.Done);
                    break;
                default:
                    throw new ArgumentException();
            }

            Todos = await query.ToListAsync();
        }
    }
}