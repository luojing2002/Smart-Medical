using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Books
{
    public class BookAppService : ApplicationService, IBookAppService //implement the IBookAppService
    {
        IRepository<Book, Guid> bookRepository;

        public BookAppService(IRepository<Book, Guid> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<ApiResult<BookDto>> CreateAsync(CreateUpdateBookDto input)
        {
            var book = ObjectMapper.Map<CreateUpdateBookDto, Book>(input);
            var result = await bookRepository.InsertAsync(book);
            var bookDto = ObjectMapper.Map<Book, BookDto>(result);
            return ApiResult<BookDto>.Success(bookDto,ResultCode.Success);

        }

        public async Task<ApiResult> DeleteAsync(Guid id)
        {
            var book = await bookRepository.GetAsync(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            await bookRepository.DeleteAsync(book);
            return ApiResult.Success(ResultCode.Success);
        }

        public async Task<ApiResult<BookDto>> GetAsync(Guid id)
        {
            var book = await bookRepository.GetAsync(id);
            var bookDto = ObjectMapper.Map<Book, BookDto>(book);

            return ApiResult<BookDto>.Success(bookDto, ResultCode.Success);

        }

        public async Task<PageResult<List<BookDto>>> GetListAsync([FromQuery] Seach seach)
        {
            var list = await bookRepository.GetListAsync();
            
            var totalCount = list.Count;
            var totalPage = (int)Math.Ceiling((double)totalCount / seach.PageSize);
            var pagedList = list.Skip((seach.PageIndex - 1) * seach.PageSize).Take(seach.PageSize).ToList();
            var bookDtos = ObjectMapper.Map<List<Book>, List<BookDto>>(pagedList);
            return new PageResult<List<BookDto>>
            {
                TotleCount = totalCount,
                TotlePage = totalPage,
                Data = bookDtos
            };
        }

        public async Task<ApiResult<BookDto>> UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            var book= await bookRepository.GetAsync(id);
            if (book == null)
            {
               return ApiResult<BookDto>.Fail("没有数据", ResultCode.Error);
            }
            var updatedBook = ObjectMapper.Map(input, book);
            await bookRepository.UpdateAsync(updatedBook);
            return ApiResult<BookDto>.Success(ObjectMapper.Map<Book, BookDto>(updatedBook), ResultCode.Success);
        }
    }
}
