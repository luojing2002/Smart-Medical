using System;
using Volo.Abp.Application.Dtos;

namespace BookStore.Pharmacy
{
    public class PharmaceuticalCompanyDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
    }
} 