using MobileMekanikoSystem.Models.Dto;

namespace MobileMekanikoSystem.Repository.Irepository
{
    public interface ICustomerCarRepository
    {
        Task<List<CustomerCarDto>> GetCustomerCarsByIdAsync(int id);

    }
}
