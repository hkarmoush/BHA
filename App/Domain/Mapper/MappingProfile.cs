using AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<CustomerRecord, CustomerRecordDto>().ReverseMap();
        CreateMap<HRRecord, HRRecordDto>().ReverseMap();
        CreateMap<ITRecord, ITRecordDto>().ReverseMap();
    }
}