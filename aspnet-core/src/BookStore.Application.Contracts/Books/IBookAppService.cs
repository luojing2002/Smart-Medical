using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    public interface IBookAppService :IApplicationService
    {
        Task< ApiResult<BookDto>> GetAsync(Guid id);
        Task<PageResult<List<BookDto>>> GetListAsync([FromQuery] Seach seach);
        Task<ApiResult<BookDto>> CreateAsync(CreateUpdateBookDto input);
        Task<ApiResult<BookDto>> UpdateAsync(Guid id, CreateUpdateBookDto input);
        Task<ApiResult> DeleteAsync(Guid id);
    }

}
