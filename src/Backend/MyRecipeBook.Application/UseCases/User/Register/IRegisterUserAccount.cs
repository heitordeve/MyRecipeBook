using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.User.Register;

public interface IRegisterUserAccount
{
    void Execute(RequestRegisterUserAccountJson request);
}
