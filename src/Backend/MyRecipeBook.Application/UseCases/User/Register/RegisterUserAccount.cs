using Mapster;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Security.PasswordsHashing;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccount : IRegisterUserAccount
{
    private readonly IPasswordHasher _passwordHasher;
    public RegisterUserAccount(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public void Execute(RequestRegisterUserAccountJson request)
    {
        ValidateAndThrowOnFailures(request);
        var user = request.Adapt<Domain.Entities.User>();
        user.Password = _passwordHasher.HashPassword(user.Password);
    }

    private void ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ArgumentException($"Validation failed: {string.Join(", ", errorMessages)}");
        }
    }
}
