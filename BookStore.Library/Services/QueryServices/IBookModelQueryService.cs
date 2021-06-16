using BookStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Library.Services.QueryServices
{
    public interface IBookModelQueryService
    {
        Task<List<BookModel>> GetAsync();
        Task<BookModel> GetAsync(Guid id);
    }
}