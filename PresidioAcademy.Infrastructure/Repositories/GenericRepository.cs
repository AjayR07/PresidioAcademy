using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Infrastructure.DbContext;

namespace PresidioAcademy.Infrastructure.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{
    private readonly PresidioAcademyContext _context;

    public GenericRepository(PresidioAcademyContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T Update(T entity)
    { 
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
}