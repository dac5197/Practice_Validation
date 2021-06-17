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
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty (Library).")
                .MustAsync(BeUniqueTitleAsync).WithMessage("'{PropertyName}' '{PropertyValue}' already exists.");
        }

        private async Task<bool> BeUniqueTitleAsync(BookModel book, string title, CancellationToken cancellationToken)
        {
            var books = await _bookQueryService.GetUntrackedAsync();
            bool isDuplicateAuthor = books.Where(b => b.Title == book.Title).Where(b => b.Id != book.Id).Any();

            return !isDuplicateAuthor;
        }
    }
}
