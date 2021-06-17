using BookStore.Library.Models;
using System.Threading.Tasks;

namespace BookStore.Library.Services.ValidatorServices
{
    public interface IValidatorService
    {
        Task ValidateAsync(BookModel book);
    }
}