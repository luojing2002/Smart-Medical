using AutoMapper;
using BookStore.Books;
using BookStore.Pharmacy;
using BookStore.Medical;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<CreateUpdateBookDto, Book>().ReverseMap();

        CreateMap<Drug, DrugDto>().ReverseMap();
        CreateMap<CreateUpdateDrugDto, Drug>().ReverseMap();

        CreateMap<Sick, SickDto>().ReverseMap();
        CreateMap<CreateUpdateSickDto, Sick>().ReverseMap();
    }
}
