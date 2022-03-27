namespace FitnessApp.respository.GenericRepository
{
    public interface IGenericRepository<T> where T : class

    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        String Delete(object id);
        void Save();
    }
}