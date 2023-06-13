namespace JobPortal.Services.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task Delete();
        Task Update(T entity);
    }
}
