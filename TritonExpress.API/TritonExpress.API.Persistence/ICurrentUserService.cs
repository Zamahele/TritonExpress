namespace TritonExpress.API.Persistence
{
    public interface ICurrentUserService
    {
        IUserSession GetCurrentUser();
    }
}
