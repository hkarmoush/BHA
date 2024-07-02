public interface IUserService
{
    Task<User> GetUserByIdAsync(Guid userId);
}