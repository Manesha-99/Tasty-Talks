using Microsoft.AspNetCore.Identity;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
