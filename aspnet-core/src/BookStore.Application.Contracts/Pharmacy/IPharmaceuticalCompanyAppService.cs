using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Pharmacy
{
    public interface IPharmaceuticalCompanyAppService :
        ICrudAppService<
            PharmaceuticalCompanyDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePharmaceuticalCompanyDto>
    {
        /// <summary>
        /// 根据公司名称模糊查询
        /// </summary>
        /// <param name="name">公司名称</param>
        /// <returns></returns>
        Task<ListResultDto<PharmaceuticalCompanyDto>> FindByNameAsync(string name);

        /// <summary>
        /// 获取所有公司列表
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<PharmaceuticalCompanyDto>> GetListAllAsync();
    }
} 