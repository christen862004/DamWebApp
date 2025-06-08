namespace DamWebApp.Repository
{
    public interface IRepository<T> where T : class 
    {
        //CRUD
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        
        void Save();
    }

}
