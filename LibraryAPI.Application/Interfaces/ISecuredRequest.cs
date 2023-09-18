namespace LibraryAPI.Application.Interfaces
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}
