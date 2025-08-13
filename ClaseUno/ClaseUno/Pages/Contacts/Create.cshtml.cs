using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClaseUno.Pages.Contacts
{
    using System.Threading.Tasks;


    public class CreateModel : PageModel
    {
        private readonly ContactManagerContext _context;
        public CreateModel(ContactManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contact Contact { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}


