namespace Demo.Models
{
    public class User
    {
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public User(string username, string firstName, string lastName)
        {
            this.UserName = username;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
