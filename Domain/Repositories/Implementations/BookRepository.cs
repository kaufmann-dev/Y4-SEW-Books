using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations; 

public class BookRepository : ARepository<Book>, IBookRepository {
    
    public BookRepository(TestDbContext dbContext) : base(dbContext) {
        
    }
    public async Task<List<Book>> ReadGraphAsync(Expression<Func<Book, bool>> filter)
        => await _table
            .Include(t => t.BookAuthorList)
            .ThenInclude(m => m.Author)
            .Where(filter)
            .ToListAsync();
}