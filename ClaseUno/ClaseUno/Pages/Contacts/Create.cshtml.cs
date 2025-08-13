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
        //Iyeccionc de independecia atravez del constructor
        public CreateModel(ContactManagerContext context)
        {
            _context = context;
        }
        // Mis etiquetas de HTML se pueden enlazar
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


