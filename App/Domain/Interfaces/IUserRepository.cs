public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
}