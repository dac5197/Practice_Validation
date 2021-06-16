using BookStore.Library.Models;
using System.Threading.Tasks;

namespace BookStore.Library.Services.CommandServices
{
    public interface IBookModelCommandService
    {
        Task<BookModel> CreateAsync(BookModel book);
        Task<BookModel> UpdateAsync(BookModel book);
    }
}