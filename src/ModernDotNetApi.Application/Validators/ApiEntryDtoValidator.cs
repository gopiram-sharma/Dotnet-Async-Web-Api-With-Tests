using FluentValidation;
using ModernDotNetApi.Application.DTOs;

namespace ModernDotNetApi.Application.Validators
{
    public class ApiEntryDtoValidator : AbstractValidator<ApiEntryDto>
    {
        public ApiEntryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(500)
                .WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage("URL is required.")
                .MaximumLength(200)
                .WithMessage("URL cannot exceed 200 characters.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("URL must be a valid URI.");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category is required.")
                .MaximumLength(50)
                .WithMessage("Category cannot exceed 50 characters.");
        }
    }
}
