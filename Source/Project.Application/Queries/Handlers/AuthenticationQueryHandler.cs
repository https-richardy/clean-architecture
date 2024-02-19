using FluentValidation;
using MediatR;
using Project.Application.Contracts.Services;

namespace Project.Application.Queries.Handlers;

public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AuthenticationQueryResponse>
{
    private readonly IAccountService _accountService;
    private readonly IValidator<AuthenticationQuery> _validator;

    public AuthenticationQueryHandler(IAccountService accountService, IValidator<AuthenticationQuery> validator)
    {
        _accountService = accountService;
        _validator = validator;
    }

    public async Task<AuthenticationQueryResponse> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var response = await _accountService.AuthenticateAsync(request);
        return response;
    }
}