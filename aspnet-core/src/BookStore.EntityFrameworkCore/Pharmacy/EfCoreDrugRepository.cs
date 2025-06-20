using BookStore.Pharmacy;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore.Pharmacy
{
    public class EfCoreDrugRepository : EfCoreRepository<BookStoreDbContext, Drug, Guid>, IRepository<Drug, Guid>
    {
        public EfCoreDrugRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
