using System.Linq.Expressions;
using Model.Entities;

namespace Domain.Repositories.Interfaces; 

public interface IBookRepository : IRepository<Book> {
    Task<List<Book>> ReadGraphAsync(Expression<Func<Book, bool>> filter);

}