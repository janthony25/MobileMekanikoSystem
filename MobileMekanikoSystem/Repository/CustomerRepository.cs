using Microsoft.EntityFrameworkCore;
using MobileMekanikoSystem.Data;
using MobileMekanikoSystem.Models.Dto;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;
        public CustomerRepository(DataContext data)
        {
            _data = data;   
        }
        public async Task<List<CustomerListDto>> GetCustomerListAsyn()
        {
            return await _data.tblCustomer
                .Select(c => new CustomerListDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CustomerNumber = c.CustomerNumber
                }).ToListAsync();
        }
    }
}
