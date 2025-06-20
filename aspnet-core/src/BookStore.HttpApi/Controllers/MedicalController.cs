using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace BookStore.Medical
{
    [Route("api/app/medical")]
    public class MedicalController : AbpController
    {
        private readonly IMedicalAppService _medicalAppService;
        public MedicalController(IMedicalAppService medicalAppService)
        {
            _medicalAppService = medicalAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<MedicalDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return _medicalAppService.GetListAsync(input);
        }

        [HttpGet("{id}")]
        public Task<MedicalDto> GetAsync(Guid id)
        {
            return _medicalAppService.GetAsync(id);
        }

        [HttpPost]
        public Task<MedicalDto> CreateAsync(CreateUpdateMedicalDto input)
        {
            return _medicalAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public Task<MedicalDto> UpdateAsync(Guid id, CreateUpdateMedicalDto input)
        {
            return _medicalAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _medicalAppService.DeleteAsync(id);
        }
    }
} 