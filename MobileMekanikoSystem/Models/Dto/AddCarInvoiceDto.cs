namespace MobileMekanikoSystem.Models.Dto
{
    public class AddCarInvoiceDto
    {
        public string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarMake { get; set; }
        public string? CarModel { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public required string IssueName { get; set; }
        public string? PaymentTerm { get; set; }
        public string? Notes { get; set; }
        public decimal? LaborPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public bool? IsPaid { get; set; }
        public string? PaymentStatus { get; set; }

        // Invoice Items
        public List<AddInvoiceItemDto> InvoiceItems { get; set; } = new List<AddInvoiceItemDto>();
    }
}
