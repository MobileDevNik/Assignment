namespace AssignmentApi.Authentication
{
    public interface IUserServiceProtocol
    {
        User Authenticate(string username, string password);
    }
}
