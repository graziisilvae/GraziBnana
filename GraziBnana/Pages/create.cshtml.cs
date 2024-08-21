namespace GraziBnana.Pages
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using GraziBnana.Models;

namespace StudentApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Student Student { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}