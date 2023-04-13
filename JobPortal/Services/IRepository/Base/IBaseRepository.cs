namespace JobPortal.Services.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}
