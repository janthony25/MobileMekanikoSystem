using MobileMekanikoSystem.Models;
using MobileMekanikoSystem.Models.Dto;
using System.Threading.Tasks;

namespace MobileMekanikoSystem.Repository.Irepository
{
    public interface ICarInvoiceRepository
    {
        Task<List<CarInvoiceListDto>> GetCarInvoiceListByIdAsync(int id);
        Task AddInvoiceWithDetailsAsync(AddCarInvoiceDto model);
        Task<CustomerCarDto> GetCarInvoiceDetailsAsync(int carId);
    }
}
