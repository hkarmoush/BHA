using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class KpiController : ControllerBase
{
    private readonly IKpiService _kpiService;

    public KpiController(IKpiService kpiService)
    {
        _kpiService = kpiService;
    }

    [HttpGet("role-kpis")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<KpiDto>>> GetKpisForUserRole()
    {
        var roleClaim = User.FindFirstValue(ClaimTypes.Role);
        if (string.IsNullOrEmpty(roleClaim))
        {
            return Unauthorized();
        }

        if (!Enum.TryParse(roleClaim, out Role userRole))
        {
            return BadRequest("Invalid role");
        }

        var kpis = await _kpiService.GetKpisForUserRoleAsync(userRole);
        return Ok(kpis);
    }
}