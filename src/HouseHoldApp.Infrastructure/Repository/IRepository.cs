namespace HouseHoldApp.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(int id);
    }
}
