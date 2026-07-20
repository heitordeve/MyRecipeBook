using MyRecipeBook.Domain.Security.PasswordsHashing;

namespace MyRecipeBook.Infrastructure.Security.PasswordsHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
