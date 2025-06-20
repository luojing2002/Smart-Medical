using System;
using BookStore.Medical;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore.Medical
{
    public class EfCoreMedicalRepository : EfCoreRepository<BookStoreDbContext, Sick, Guid>, IRepository<Sick, Guid>
    {
        public EfCoreMedicalRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
} 