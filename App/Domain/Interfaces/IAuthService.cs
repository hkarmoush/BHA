public interface IAuthService
{
    Task<string> AuthenticateAsync(string email, string password);
    Task<string> RefreshTokenAsync(string refreshToken);
    Task<string> GenerateRefreshTokenAsync(string email);
}