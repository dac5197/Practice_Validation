using BookStore.WebApi.ApiRequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStore.WebApi.Validators
{
    public class BookApiRequestModelValidator : AbstractValidator<BookApiRequestModel>
    {
        public BookApiRequestModelValidator()
        {
            // Title
            RuleFor(b => b.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(1024);

            // Author
            RuleFor(b => b.Author)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(1024)
                .Matches("^\\w+$").WithMessage("'{PropertyName}' contains invalid characters.");

            // PageCount
            RuleFor(b => b.PageCount)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .GreaterThan(0);

            // Price
            RuleFor(b => b.Price)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .GreaterThan(0);

            // PublishedDate
            RuleFor(b => b.Author)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(BeAValidDate).WithMessage("'{PropertyName}' is invalid datetime format.");

        }

        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }
}
