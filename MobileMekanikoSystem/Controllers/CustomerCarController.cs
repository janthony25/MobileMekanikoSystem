using Microsoft.AspNetCore.Mvc;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Controllers
{
    public class CustomerCarController : Controller
    {
        private readonly ICustomerCarRepository _customerCarRepository;
        public CustomerCarController(ICustomerCarRepository customerCarRepository)
        {
            _customerCarRepository = customerCarRepository;
        }
        
        // GET - Customer's Car List
        public async Task<IActionResult> GetCustomerCars(int id)
        {
            var customer = await _customerCarRepository.GetCustomerCarsByIdAsync(id);
            return View(customer);
        }
    }
}
