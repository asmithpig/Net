namespace ApplicationCore.Contracts.Repositories;

public interface IRepositoryAsync<T> where T: class
{
    Task<T> GetByIdAsync(int id);
    
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<int> InsertAsync(T entity);
    
    Task<int> UpdateAsync(T entity);
    
    Task<int> DeleteByIdAsync(int id);
    
}