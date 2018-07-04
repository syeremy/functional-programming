namespace Demo.InputModels
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Models.User ToModel() =>
            new Models.User(this.UserName, this.FirstName, this.LastName);
    }
}
