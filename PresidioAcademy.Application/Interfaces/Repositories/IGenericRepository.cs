namespace PresidioAcademy.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();

    T? Get(int id);

    void Add(T entity);

    void Delete(T entity);

    T Update(T entity);
}