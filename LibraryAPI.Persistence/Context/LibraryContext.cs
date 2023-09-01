using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryAPI.Persistence.Context
{
    public class LibraryContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<BarrowedBook> BarrowedBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options){  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            //modelBuilder.ApplyConfiguration(new BarrowedBookConfiguration());
            //modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            //modelBuilder.ApplyConfiguration(new BookConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

        }

    }
}
