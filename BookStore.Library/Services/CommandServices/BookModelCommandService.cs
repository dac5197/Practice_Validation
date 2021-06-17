using BookStore.Library.DataAccess;
using BookStore.Library.Models;
using BookStore.Library.Services.QueryServices;
using BookStore.Library.Services.ValidatorServices;
using BookStore.Library.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Library.Services.CommandServices
{
    public class BookModelCommandService : IBookModelCommandService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookModelQueryService _bookQueryService;
        private readonly IValidatorService _validatorService;

        public BookModelCommandService(ApplicationDbContext context, IBookModelQueryService bookQueryService, IValidatorService validatorService)
        {
            _context = context;
            _bookQueryService = bookQueryService;
            _validatorService = validatorService;
        }

        public async Task<BookModel> CreateAsync(BookModel book)
        {
            //BookModelValidator validator = new(_bookQueryService);
            //var validationResults = await validator.ValidateAsync(book);
            //if (!validationResults.IsValid)
            //{
            //    throw new ValidationException(validationResults.Errors);
            //}

            await _validatorService.ValidateAsync(book);
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
            await _validatorService.ValidateAsync(book);
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
