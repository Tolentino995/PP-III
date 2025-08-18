using ClaseUno.Data;
using ClaseUno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaseUno.Pages.Categories
{
    public class CategoryListModel(ContactManagerContext context) : PageModel
    {
        private readonly ContactManagerContext _context = context;

        public IList<Category> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var categories = from c in _context.Categories
                             select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                categories = categories.Where(s => s.Name.Contains(SearchString));
            }
            Categories = await categories.ToListAsync();
        }
    }
}
