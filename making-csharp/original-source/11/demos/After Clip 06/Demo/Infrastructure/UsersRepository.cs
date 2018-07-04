using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Errors;
using Demo.Models;
using Demo.Functional;

namespace Demo.Infrastructure
{
    public class UsersRepository : IRepository<User>
    {
        private IList<User> Content { get; } = new List<User>()
        {
            new User("donald", "Smart", "Guy")
        };

        public IQueryable<User> GetAll() =>
            this.Content.AsQueryable();

        public void Add(User obj)
        {
            if (this.Content.Any(user => user.UserName == obj.UserName))
                throw new ArgumentException("Username in use.");
            this.Content.Add(obj);
        }

        public Either<Error, User> AddSafe(User obj)
        {
            if (this.Content.Any(user => user.UserName == obj.UserName))
                return new UserExists(obj);

            this.Content.Add(obj);
            return obj;
        }
    }
}
