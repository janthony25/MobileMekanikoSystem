using Microsoft.EntityFrameworkCore;
using MobileMekanikoSystem.Data;
using MobileMekanikoSystem.Models;
using MobileMekanikoSystem.Models.Dto;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Repository
{
    public class CustomerCarRepository : ICustomerCarRepository
    {
        private readonly DataContext _data;
        public CustomerCarRepository(DataContext data)
        {
            _data = data;
        }
        public async Task<List<CustomerCarDto>> GetCustomerCarsByIdAsync(int id)
        {
            return await _data.tblCustomer
                .Include(c => c.tblCar)
                .Where(c => c.CustomerId == id)
                .SelectMany(c => c.tblCar.DefaultIfEmpty(), (customer, car) => new CustomerCarDto
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail,
                    CustomerNumber = customer.CustomerNumber,
                    CarId = car != null ? car.CarId : 0,   
                    CarRego = car != null ? car.CarRego : string.Empty,
                    CarMake = car != null ? car.CarMake : string.Empty,
                    CarModel = car != null ? car.CarModel : string.Empty
                }).ToListAsync();
        }

      

        
    }
}
