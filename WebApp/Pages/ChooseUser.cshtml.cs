using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class ChooseUser : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public ChooseUser (DAL.AppDbContext context)
        {
            _context = context;
        }

        public string Search { get; set; }
        public IList<User> User { get;set; }

        public async Task OnGetAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                User = await _context.Users.ToListAsync();
            }
            else
            {
                search = search.ToLower();
                User = await _context.Users.Where(u => 
                    u.UserId.ToString() == search ||
                    u.UserName.ToLower().Contains(search)).ToListAsync();

                Search = search;
            }
        }
    }
}