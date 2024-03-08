namespace ApplicationCore.Contracts.Repositories;

public interface IRepository<T> where T: class
{
    Task<T> GetById(int id);
    
    Task<IEnumerable<T>> GetAll();
    
    Task<int> Insert(T entity);
    
    Task<int> Update(T entity);
    
    Task<int> DeleteById(int id);
    
}