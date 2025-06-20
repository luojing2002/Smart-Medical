using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Prescriptions
{
    public interface IPrescriptionService: IApplicationService
    {
        Task<ApiResult> CreateAsync(PrescriptionDto input);
        Task<ApiResult<List<PrescriptionTree>>> GetPrescriptionTree(int pid);
    }
}
