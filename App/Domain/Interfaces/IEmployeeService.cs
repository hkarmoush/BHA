public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
    Task AddEmployeeAsync(EmployeeDto employeeDto);
    Task UpdateEmployeeAsync(EmployeeDto employeeDto);
    Task DeleteEmployeeAsync(Guid id);
}