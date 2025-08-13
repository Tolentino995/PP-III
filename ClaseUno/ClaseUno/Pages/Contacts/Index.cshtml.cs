using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaseUno.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ContactManagerContext _context;
        public IndexModel(ContactManagerContext context)
        {
            _context = context;
        }
        public IList<Contact> Contacts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var contacts = from c in _context.Contacts
                           select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(s => s.Name.Contains(SearchString));
            }
            Contacts = await contacts.ToListAsync();
        }
    }
}
