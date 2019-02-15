using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public User User { get; set; }

        public string Message { get; set; }
        
        public async Task<IActionResult> OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var userse = await _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
            
            if (userse != null)
            {
                return RedirectToPage("TodoList", new {id = userse.UserId});
            }

            Message = "User not found";
            return Page();
        }
    }
}