using Demo.Models;

namespace Demo.Errors
{
    public class UserExists : Error
    {
        public User ExistingUser { get; }

        public UserExists(User user)
        {
            this.ExistingUser = user;
        }
    }
}
