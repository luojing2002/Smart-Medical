using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Pharmacy.InAndOutWarehouse
{
    public class CreateDrugInStockDto
    {
        [Required]
        public Guid DrugId { get; set; }

        [Required]
        public Guid PharmaceuticalCompanyId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime StockInDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(64)]
        public string BatchNumber { get; set; }
    }
} 