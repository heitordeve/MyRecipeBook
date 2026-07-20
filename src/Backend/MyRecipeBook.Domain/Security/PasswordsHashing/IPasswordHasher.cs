namespace MyRecipeBook.Domain.Security.PasswordsHashing;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}
