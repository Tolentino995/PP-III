using Microsoft.EntityFrameworkCore;
using ClaseUno.Models;

namespace ClaseUno.Data

{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext(DbContextOptions<ContactManagerContext>
        options)
        : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
