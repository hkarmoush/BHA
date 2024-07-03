public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
}