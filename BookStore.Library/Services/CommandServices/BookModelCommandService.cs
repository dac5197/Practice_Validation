using BookStore.Library.DataAccess;
using BookStore.Library.Models;
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

        public BookModelCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookModel> CreateAsync(BookModel book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<BookModel> UpdateAsync(BookModel book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
