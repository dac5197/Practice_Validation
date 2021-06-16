using BookStore.Library.Models;
using BookStore.Library.Services.QueryServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Library.Validators
{
    public class BookModelValidator : AbstractValidator<BookModel>
    {
        private readonly IBookModelQueryService _bookQueryService;

        public BookModelValidator(IBookModelQueryService bookQueryService)
        {
            _bookQueryService = bookQueryService;

            // Title
            RuleFor(b => b.Title)
                .MustAsync(BeUniqueTitleAsync).WithMessage("'{PropertyName}' title already exists.");
        }

        private async Task<bool> BeUniqueTitleAsync(string title, CancellationToken cancellationToken)
        {
            var books = await _bookQueryService.GetAsync();
            bool isDuplicateAuthor = books.Where(b => b.Title == title).Any();

            return !isDuplicateAuthor;
        }
    }
}
