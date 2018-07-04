namespace Demo.Errors
{
    public class UserNotFound : Error
    {
        public string UserName { get; }

        public UserNotFound(string username)
        {
            this.UserName = username;
        }
    }
}
