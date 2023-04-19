using ContatosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosAPI.Data
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PhoneContact> PhoneContacts { get; set; }
        public DbSet<EmailContact> EmailContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name);
                e.Property(x => x.LastName).IsRequired(false);
                e.Property(x => x.Cpf);
                e.Property(x => x.IsDeleted);
                e.HasMany(x => x.PhoneContacts).WithOne().HasForeignKey(s => s.PersonId);
                e.HasMany(x => x.EmailContacts).WithOne().HasForeignKey(s => s.PersonId);
            });

            builder.Entity<PhoneContact>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.PhoneNumber);
                e.Property(x => x.IsWhatsapp);
                e.Property(x => x.PersonId);
            });

            builder.Entity<EmailContact>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.EmailAddress);
                e.Property(x => x.PersonId);
            });
        }
    }
}
