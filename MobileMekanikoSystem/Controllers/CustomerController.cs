using Microsoft.AspNetCore.Mvc;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // GET - Customer List
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerRepository.GetCustomerListAsyn();
            return View(customer);
        }
    }
}
