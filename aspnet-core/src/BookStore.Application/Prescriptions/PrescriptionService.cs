using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace BookStore.Prescriptions
{
    public class PrescriptionService: ApplicationService,IPrescriptionService
    {
        private readonly IRepository<Prescription, int> pres;

        public PrescriptionService(IRepository<Prescription, int> pres)
        {
            this.pres = pres;
        }
        [HttpPost]
        public async Task<ApiResult> CreateAsync(PrescriptionDto input)
        {
            var res= ObjectMapper.Map<PrescriptionDto, Prescription>(input);
            res=await pres.InsertAsync(res);
            //var prescription = await pres.InsertAsync(input);
            return ApiResult.Success(ResultCode.Success);
        }
        /// <summary>
        /// 获取处方树
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<List<PrescriptionTree>>> GetPrescriptionTree(int pid)
        {
            // 一次性查出所有数据
            var allList = await pres.GetListAsync();
            var tree = BuildTree(allList, pid);
            return ApiResult<List<PrescriptionTree>>.Success(tree, ResultCode.Success);
        }
        /// <summary>
        /// 内存递归组装树
        /// </summary>
        private List<PrescriptionTree> BuildTree(List<Prescription> all, int parentId)
        {
            var children = all.Where(x => x.ParentId == parentId).ToList();
            var result = new List<PrescriptionTree>();
            foreach (var item in children)
            {
                var node = new PrescriptionTree
                {
                    value = item.Id,
                    label = item.PrescriptionName,
                    children = BuildTree(all, item.Id)
                };
                result.Add(node);
            }
            return result;
        }


    }
}
