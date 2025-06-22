using System;
using System.Threading.Tasks;
using BookStore.Pharmacy.InAndOutWarehouse;
using Volo.Abp.Application.Services;

namespace BookStore.Pharmacy
{
    public interface IDrugInStockAppService : IApplicationService
    {
        Task<DrugDto> StockInAsync(CreateDrugInStockDto input);
    }
} 