namespace TritonExpress.API.Persistence
{
    public interface IUserSession
    {
        string LoginName { get; set; }

        bool IsAuthenticated { get; set; }
    }
}