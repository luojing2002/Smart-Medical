using System.ComponentModel.DataAnnotations;

namespace BookStore.Pharmacy
{
    public class CreateUpdatePharmaceuticalCompanyDto
    {
        [Required]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(64)]
        public string ContactPerson { get; set; }

        [StringLength(32)]
        public string ContactPhone { get; set; }

        [StringLength(256)]
        public string Address { get; set; }
    }
} 