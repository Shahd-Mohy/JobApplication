using JobApplication.Application.DTOs.Auth;

namespace JobApplication.Application.Interfaces
{
    /// <summary>
    /// Contract for creating access tokens.
    /// Implemented in Infrastructure, because it depends on JWT libraries and configuration.
    /// </summary>
    public interface IJwtTokenGenerator
    {
        (string Token, DateTime ExpiresAtUtc) GenerateToken(AuthUserDto user);
    }
}
