using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Get(string include = "");
        void Create(T t);
        void Update(T t);
        void Delete(int id);
        void Save();
    }

    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T:class
    {
        private readonly ApplicationContext _db;
        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            _db = new ApplicationContext();
            _dbSet = _db.Set<T>();
        }

        public void Create(T t)
        {
            _dbSet.Add(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            T t = _dbSet.Find(id);
            if (t != null)
            {
                _dbSet.Remove(t);
                _db.SaveChanges();
            }
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Get(string include = "")
        {
            if (!String.IsNullOrEmpty(include))
                return _dbSet.Include(include).ToList();
            return _dbSet.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T t)
        {
            _db.Entry(t).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
