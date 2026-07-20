using Mapster;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccount
{
    public void Execute(RequestRegisterUserAccountJson request)
    {
        Console.WriteLine(request);
        ValidateAndThrowOnFailures(request);
        var user = request.Adapt<Domain.Entities.User>();
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
