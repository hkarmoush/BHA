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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        try
        {
            await _authService.RegisterAsync(request);
            return Ok(new { message = "Registration successful" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
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

    [HttpPost("default-login")]
    public async Task<ActionResult<AuthResponseDto>> DefaultLogin()
    {
        var request = new AuthRequestDto
        {
            Email = "superadmin@example.com",
            Password = "Apple@123123"
        };

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

}