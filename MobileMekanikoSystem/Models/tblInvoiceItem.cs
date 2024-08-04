using System.ComponentModel.DataAnnotations;

namespace MobileMekanikoSystem.Models
{
    public class tblInvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public required string ItemName { get; set; }
        public required int Quantity { get; set; }
        public required decimal ItemPrice { get; set; }
        public decimal? ItemTotal { get; set; } // newley added

        // FK to tblInvoice
        public int InvoiceId { get; set; }
        public tblInvoice tblInvoice { get; set; }
    }
}
