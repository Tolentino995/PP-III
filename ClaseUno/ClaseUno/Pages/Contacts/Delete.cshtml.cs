using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ClaseUno.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ContactManagerContext _context;
        public DeleteModel(ContactManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contact? Contact { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            Contact = await _context.Contacts.FindAsync(id);
            if (Contact == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}