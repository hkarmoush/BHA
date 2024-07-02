// Presentation/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] AuthRequestDto request)
    {
        try
        {
            var accessToken = await _authService.AuthenticateAsync(request.Email, request.Password);
            var refreshToken = await _authService.GenerateRefreshTokenAsync(request.Email);

            return Ok(new AuthResponseDto { AccessToken = accessToken, RefreshToken = refreshToken });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthResponseDto>> RefreshToken([FromBody] RefreshTokenRequestDto request)
    {
        try
        {
            var accessToken = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(new AuthResponseDto { AccessToken = accessToken, RefreshToken = request.RefreshToken });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}