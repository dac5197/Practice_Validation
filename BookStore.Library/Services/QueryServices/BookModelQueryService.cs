using BookStore.Library.DataAccess;
using BookStore.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Library.Services.QueryServices
{
    public class BookModelQueryService : IBookModelQueryService
    {
        private readonly ApplicationDbContext _context;

        public BookModelQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookModel>> GetAsync()
        {
            var output = await _context.Books.ToListAsync();
            return output;
        }

        public async Task<BookModel> GetAsync(Guid id)
        {
            var output = await _context.Books.FindAsync(id);
            return output;
        }
    }
}
