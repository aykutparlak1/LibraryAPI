

using LibraryAPI.Domain.Entities.BaseEntity;

namespace LibraryAPI.Domain.Entities.UserEntities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveTime { get; set; }
        public bool IsActive { get; set; }
        public User? User { get; set; }
    }
}
