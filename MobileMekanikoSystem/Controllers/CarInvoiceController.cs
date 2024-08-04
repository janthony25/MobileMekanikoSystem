using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MobileMekanikoSystem.Models;
using MobileMekanikoSystem.Models.Dto;
using MobileMekanikoSystem.Repository;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Controllers
{
    public class CarInvoiceController : Controller
    {
        private readonly ICarInvoiceRepository _carInvoiceRepository;
        private readonly ICustomerCarRepository _customerCarRepository;
        public CarInvoiceController(ICarInvoiceRepository carInvoiceRepository, ICustomerCarRepository customerCarRepository)
        {
            _carInvoiceRepository = carInvoiceRepository;
            _customerCarRepository = customerCarRepository;
        }
       

        // GET - Car Invoice List
        public async Task<IActionResult> GetCarInvoiceById(int id)
        {
            if (id != null)
            {
                var carInvoice = await _carInvoiceRepository.GetCarInvoiceListByIdAsync(id);
                return View(carInvoice);
            }

            return View();
        }

        // GET - Add Car Invoice
        public async Task<IActionResult> CreateInvoice(int id)
        {
            var customerCarDetails = await _carInvoiceRepository.GetCarInvoiceDetailsAsync(id);

            if (customerCarDetails == null)
            {
                return NotFound(); // Handle the case where the car or customer is not found
            }

            var viewModel = new AddCarInvoiceDto
            {
                CustomerName = customerCarDetails.CustomerName,
                CustomerEmail = customerCarDetails.CustomerEmail,
                CarRego = customerCarDetails.CarRego,
                CarMake = customerCarDetails.CarMake,
                CarModel = customerCarDetails.CarModel,
                PaymentStatus = customerCarDetails.PaymentStatus,
                CarId = customerCarDetails.CarId,
                IssueName = string.Empty,
                InvoiceItems = new List<AddInvoiceItemDto>() // Initialize an empty list for invoice items
            };

            return View(viewModel);
        }

        // POST - Add Invoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInvoice(AddCarInvoiceDto model)
        {
            if (ModelState.IsValid)
            {
                await _carInvoiceRepository.AddInvoiceWithDetailsAsync(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}
