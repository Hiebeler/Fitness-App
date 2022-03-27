using FitnessApp.respository.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.respository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private fitness_appContext _context = null;
        private DbSet<T> table = null;


        public GenericRepository()
        {
            this._context = new fitness_appContext();
            table = _context.Set<T>();
        }

        public GenericRepository(fitness_appContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public String Delete(object id)
        {
            T existing = table.Find(id);
            if (existing != null)
            {
                table.Remove(existing);
                return "removed";
            }

            return "uid doesnt exist";
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}