
namespace TritonExpress.API.Persistence
{

    public class UserSession : IUserSession
    {
        public string LoginName { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}