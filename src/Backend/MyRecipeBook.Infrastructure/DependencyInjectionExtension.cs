using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Security.PasswordsHashing;
using MyRecipeBook.Infrastructure.Security.PasswordsHashing;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure()
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}
    
}
