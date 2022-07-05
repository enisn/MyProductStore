using AutoMapper;
using MyProductStore.Products;

namespace MyProductStore.Blazor;

public class MyProductStoreBlazorAutoMapperProfile : Profile
{
    public MyProductStoreBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        CreateMap<ProductDto, UpdateProductDto>();
    }
}
