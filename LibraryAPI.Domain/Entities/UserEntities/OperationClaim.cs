namespace LibraryAPI.Domain.Entities.UserEntities
{
    public class OperationClaim : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> Users { get; set; }
    }
}
