using BookStore.Pharmacy;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Medical
{
    public interface IMedicalAppService : IApplicationService
    {
        Task<SickDto> GetSickAsync(Guid id);
        Task<PagedResultDto<SickDto>> GetLisSicktAsync(PagedAndSortedResultRequestDto input);
        Task<SickDto> CreateSickAsync(CreateUpdateDrugDto input);
        Task<SickDto> UpdateSickAsync(Guid id, CreateUpdateDrugDto input);
        Task DeleteSickAsync(Guid id);
    }
} 