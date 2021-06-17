using BookStore.Library.Models;
using BookStore.Library.Services.QueryServices;
using BookStore.Library.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Library.Services.ValidatorServices
{
    public class ValidatorService : IValidatorService
    {
        private readonly IBookModelQueryService _bookQueryService;

        public ValidatorService(IBookModelQueryService bookQueryService)
        {
            _bookQueryService = bookQueryService;
        }

        public async Task ValidateAsync(BookModel book)
        {
            BookModelValidator validator = new(_bookQueryService);
            var validationResults = await validator.ValidateAsync(book);
            if (!validationResults.IsValid)
            {
                throw new ValidationException(validationResults.Errors);
            }
        }
    }
}
