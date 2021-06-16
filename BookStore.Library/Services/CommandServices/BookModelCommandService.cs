using BookStore.Library.DataAccess;
using BookStore.Library.Models;
using BookStore.Library.Services.QueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Library.Services.CommandServices
{
    public class BookModelCommandService : IBookModelCommandService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookModelQueryService _bookQueryService;

        public BookModelCommandService(ApplicationDbContext context, IBookModelQueryService bookQueryService)
        {
            _context = context;
            _bookQueryService = bookQueryService;
        }

        public async Task<BookModel> CreateAsync(BookModel book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _bookQueryService.GetAsync(id);

            if (book is null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BookModel> UpdateAsync(BookModel book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
