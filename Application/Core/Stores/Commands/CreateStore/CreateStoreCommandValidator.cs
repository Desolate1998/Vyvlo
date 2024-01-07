using FluentValidation;

namespace Application.Core.Store.Commands.CreateStore;

public class CreateStoreCommandValidator:AbstractValidator<CreateStoreCommand>
{
    public CreateStoreCommandValidator()
    {
        RuleFor(x => x.Data.Description).NotEmpty()
                                         .WithMessage("Description cannot be empty")
                                         .MaximumLength(255)
                                         .WithMessage("Store description has a max length of 255 characters");

        RuleFor(x => x.Data.Name).NotEmpty()
                                  .WithMessage("Name cannot be empty")
                                  .MaximumLength(250)
                                  .WithMessage("Store name has a max length of 20 characters");
    }
}
