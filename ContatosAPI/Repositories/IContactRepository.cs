using ContatosAPI.Models;
using System.Linq.Expressions;

namespace ContatosAPI.Repositories
{
    public interface IContactRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] toInclude);
        T? GetByParams(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] toInclude);
        T? GetById(object id);

        void Add(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        void Save();
    }
}
