using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class CreateUser : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateUser(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string message)
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users.FirstAsync(u => String.Equals(u.UserName, User.UserName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                Message = "This username already exists in database!";
                return Page();
            }
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}