using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordsHashing;
using MyRecipeBook.Infrastructure.Security.PasswordsHashing;

namespace MyRecipeBook.Infrastructure;

public class DependencyInjectionExtension
{
    public static void AddInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}
