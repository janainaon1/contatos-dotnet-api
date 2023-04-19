using ContatosAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContatosAPI.Repositories
{
    public class ContactRepository<T> : IContactRepository<T> where T : class
    {
        internal ContactListDbContext _context;
        internal DbSet<T> _dbSet;

        public ContactRepository(ContactListDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] toInclude)
        {
            var result = _dbSet.AsNoTracking().Where(predicate);
            result = toInclude.Aggregate(result, (cur, includeProperty) => cur.Include(includeProperty));
            
            return result.ToList();
        }

        public T? GetByParams(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] toInclude)
        {
            var result = _dbSet.Where(predicate);
            result = toInclude.Aggregate(result, (cur, includeProperty) => cur.Include(includeProperty));

            return result.FirstOrDefault();
        }

        public T? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public void Update(T entidade)
        {
            _dbSet.Update(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public void Delete(T entidade)
        {
            if (_context.Entry(entidade).State == EntityState.Detached)
            {
                _dbSet.Attach(entidade);
            }
            _dbSet.Remove(entidade);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
