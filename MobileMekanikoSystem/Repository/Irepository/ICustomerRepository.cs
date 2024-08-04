using MobileMekanikoSystem.Models.Dto;

namespace MobileMekanikoSystem.Repository.Irepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerListDto>> GetCustomerListAsyn();
    }
}
