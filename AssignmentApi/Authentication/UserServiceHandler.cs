using System.Linq;
using System.Collections.Generic;

namespace AssignmentApi.Authentication
{
    public class UserServiceHandler : IUserServiceProtocol
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "pass" }
        };

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
