namespace Publico_Kommunikation_Project.DataAccess
{
    public interface IRepository<T> where T : class
    {
        //Generic interface implementing CRUD
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
