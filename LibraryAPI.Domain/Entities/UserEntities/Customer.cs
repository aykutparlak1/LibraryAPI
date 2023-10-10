namespace LibraryAPI.Domain.Entities.UserEntities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? SubStartDate { get; set; }
        public DateTime? SubEndDate { get; set; }
        public bool IsSub { get; set; }
        public User? User { get; set; }
    }
}
