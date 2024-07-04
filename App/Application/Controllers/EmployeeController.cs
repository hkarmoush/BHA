using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(Guid id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult> AddEmployee(EmployeeDto employeeDto)
    {
        await _employeeService.AddEmployeeAsync(employeeDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(Guid id, EmployeeDto employeeDto)
    {
        if (id != employeeDto.Id)
        {
            return BadRequest();
        }

        await _employeeService.UpdateEmployeeAsync(employeeDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(Guid id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return Ok();
    }
}