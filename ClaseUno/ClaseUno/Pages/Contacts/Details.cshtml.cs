using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClaseUno.Pages.Contacts

{
    public class DetailsModel : PageModel
    {
        private readonly ContactManagerContext _context;

        public DetailsModel(ContactManagerContext context)
        {
            _context = context;
        }
        [BindProperty]

        public Contact? Contact { get; set; } 

        public ContactManagerContext Get_context()
        {
            return _context;
        }

        public IActionResult OnGet(int? id, ContactManagerContext _context)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

