using FluentValidation;
using MediatR;
using Project.Application.Contracts.Services;

namespace Project.Application.Commands.Handlers;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IValidator<CreateAccountCommand> _validator;

    public CreateAccountCommandHandler(IAccountService accountService, IValidator<CreateAccountCommand> validator)
    {
        _accountService = accountService;
        _validator = validator;
    }

    public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await _accountService.CreateUserAsync(request);
    }
}