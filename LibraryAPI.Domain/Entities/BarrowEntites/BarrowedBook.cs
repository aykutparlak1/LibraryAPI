using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Domain.Entities.BarrowEntites
{
    public class BarrowedBook : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BarrowStartDate { get; set; }
        public DateTime BarrowEndDate { get; set; }
        public bool IsReturn { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
