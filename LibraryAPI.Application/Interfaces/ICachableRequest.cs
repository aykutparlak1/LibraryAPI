namespace LibraryAPI.Application.Interfaces
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
        int  Duration{ get; }
    }
}
