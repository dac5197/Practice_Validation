using BookStore.Library.Models;
using System;
using System.Threading.Tasks;

namespace BookStore.Library.Services.CommandServices
{
    public interface IBookModelCommandService
    {
        Task<BookModel> CreateAsync(BookModel book);
        Task<bool> DeleteAsync(Guid id);
        Task<BookModel> UpdateAsync(BookModel book);
    }
}