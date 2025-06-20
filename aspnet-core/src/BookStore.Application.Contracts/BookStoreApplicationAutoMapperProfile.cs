using AutoMapper;
using BookStore.Books;
using BookStore.Medical;
using BookStore.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<CreateUpdateBookDto, Book>().ReverseMap();

            CreateMap<Drug, DrugDto>().ReverseMap();
            CreateMap<CreateUpdateDrugDto, Drug>().ReverseMap();
            CreateMap<Sick, SickDto>().ReverseMap();
            CreateMap<CreateUpdateSickDto, Sick>().ReverseMap();
        }
    }
}
