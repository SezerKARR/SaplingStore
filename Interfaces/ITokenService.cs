using SaplingStore.Models;

namespace SaplingStore.Interfaces;

public interface ITokenService
{
    string GenerateToken(AppUser user);
}