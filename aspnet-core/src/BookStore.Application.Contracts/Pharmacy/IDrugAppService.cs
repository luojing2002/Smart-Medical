using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Pharmacy
{
    public interface IDrugAppService : IApplicationService
    {
        Task<DrugDto> GetAsync(Guid id);
        Task<PagedResultDto<DrugDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<DrugDto> CreateAsync(CreateUpdateDrugDto input);
        Task<DrugDto> UpdateAsync(Guid id, CreateUpdateDrugDto input);
        Task DeleteAsync(Guid id);
    }
}