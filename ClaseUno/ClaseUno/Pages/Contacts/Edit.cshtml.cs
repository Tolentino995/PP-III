using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClaseUno.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ContactManagerContext _context;
        public EditModel(ContactManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contact Contact { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            Contact = await _context.Contacts.FindAsync(id);
            if (Contact == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Attach(Contact).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contacts.Any(e => e.Id == Contact.Id)) return
                NotFound();
                else throw;
            }

            return RedirectToPage("./Index");
        }
    }
}