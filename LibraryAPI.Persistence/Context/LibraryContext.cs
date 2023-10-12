using LibraryAPI.Domain.Entities;
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
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

           var datas= ChangeTracker.Entries<IEntity>();
            
            foreach (var data in datas)
            {
                _ = data.State switch  //  switch statement return type yok o yüzden veri tutmmamıza gerek yok direkt olarak  yapıyor _ ile veri olmaıgını belirtiyoruz.
                {
                   
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatingTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };

            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
