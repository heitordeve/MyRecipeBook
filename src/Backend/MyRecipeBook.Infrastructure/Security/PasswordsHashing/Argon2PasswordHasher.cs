using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordsHashing;
using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Infrastructure.Security.PasswordsHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALLELISM = 1;
    private const int INTERATIONS = 2;
    private const int MEMORY_SIZE = 20 * 1024;
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            MemorySize = MEMORY_SIZE,
            Iterations = INTERATIONS,
            Salt = salt
        };
        var hash = hashAlgorithm.GetBytes(HASH_SIZE);

        var combinedBytes = new byte[hash.Length + salt.Length];
        salt.CopyTo(combinedBytes);
        hash.CopyTo(combinedBytes,index: salt.Length);

        return Convert.ToBase64String(combinedBytes);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
