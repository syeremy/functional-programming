using System.Linq;
using Demo.Errors;
using Demo.Functional;

namespace Demo
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Add(T obj);
        Either<Error, T> AddSafe(T obj);
    }
}
