using Microsoft.EntityFrameworkCore;
using MobileMekanikoSystem.Data;
using MobileMekanikoSystem.Models;
using MobileMekanikoSystem.Models.Dto;
using MobileMekanikoSystem.Repository.Irepository;

namespace MobileMekanikoSystem.Repository
{
    public class CarInvoiceRepository : ICarInvoiceRepository
    {
        private readonly DataContext _dataContext;

        public CarInvoiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddInvoiceWithDetailsAsync(AddCarInvoiceDto model)
        {
            var car = await _dataContext.tblCar
                .Include(c => c.tblCustomer)
                .FirstOrDefaultAsync(c => c.CarId == model.CarId);

            if (car == null)
            {
                throw new ArgumentException("Invalid CarId provided.");
            }

            var customer = car.tblCustomer;

            if (customer == null)
            {
                customer = new tblCustomer
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    tblCar = new List<tblCar> { car }
                };
                _dataContext.tblCustomer.Add(customer);
            }
            else
            {
                customer.CustomerName = model.CustomerName;
                customer.CustomerEmail = model.CustomerEmail;
            }

            var invoice = new tblInvoice
            {
                DateAdded = model.DateAdded ?? DateTime.Now,
                DueDate = model.DueDate,
                IssueName = model.IssueName,
                PaymentTerm = model.PaymentTerm,
                Notes = model.Notes,
                LaborPrice = model.LaborPrice,
                Discount = model.Discount,
                ShippingFee = model.ShippingFee,
                SubTotal = model.SubTotal,
                TaxAmount = model.TaxAmount,
                TotalAmount = model.TotalAmount,
                AmountPaid = model.AmountPaid,
                IsPaid = model.IsPaid,
                PaymentStatus = model.PaymentStatus,
                CarId = model.CarId,
                tblCar = car
            };

            _dataContext.tblInvoice.Add(invoice);
            await _dataContext.SaveChangesAsync();

            var invoiceItems = model.InvoiceItems.Select(item => new tblInvoiceItem
            {
                ItemName = item.ItemName,
                Quantity = item.Quantity,
                ItemPrice = item.ItemPrice,
                InvoiceId = invoice.InvoiceId
            }).ToList();

            _dataContext.tblInvoiceItem.AddRange(invoiceItems);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<CarInvoiceListDto>> GetCarInvoiceListByIdAsync(int id)
        {
            return await _dataContext.tblCar
                .Include(car => car.tblCustomer)
                .Include(car => car.tblInvoice)
                .Where(car => car.CarId == id)
                .SelectMany(car => car.tblInvoice.DefaultIfEmpty(), (car, invoice) => new CarInvoiceListDto
                {
                    CustomerId = car.tblCustomer.CustomerId,
                    CustomerName = car.tblCustomer.CustomerName,
                    CustomerEmail = car.tblCustomer.CustomerEmail,
                    CustomerNumber = car.tblCustomer.CustomerNumber,
                    CarId = car.CarId,
                    CarRego = car.CarRego,
                    CarMake = car.CarMake,
                    CarModel = car.CarModel,
                    InvoiceId = invoice != null ? invoice.InvoiceId : 0,
                    IssueName = invoice.IssueName,
                    DateAdded = invoice.DateAdded,
                    DueDate = invoice.DueDate,
                    TotalAmount = invoice.TotalAmount,
                    AmountPaid = invoice.AmountPaid
                }).ToListAsync();
        }

        public async Task<CustomerCarDto> GetCarInvoiceDetailsAsync(int carId)
        {
            var car = await _dataContext.tblCar
                .Include(c => c.tblCustomer)
                .FirstOrDefaultAsync(c => c.CarId == carId);

            if (car == null) return null;

            var customerCarDto = new CustomerCarDto
            {
                CustomerId = car.tblCustomer.CustomerId,
                CustomerName = car.tblCustomer.CustomerName,
                CustomerNumber = car.tblCustomer.CustomerNumber,
                CustomerEmail = car.tblCustomer.CustomerEmail,
                PaymentStatus = car.tblCustomer.PaymentStatus,
                CarId = car.CarId,
                CarRego = car.CarRego,
                CarMake = car.CarMake,
                CarModel = car.CarModel
            };

            return customerCarDto;
        }
    }
}
 