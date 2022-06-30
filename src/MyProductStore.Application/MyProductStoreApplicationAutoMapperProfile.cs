using AutoMapper;
using MyProductStore.Products;

namespace MyProductStore;

public class MyProductStoreApplicationAutoMapperProfile : Profile
{
    public MyProductStoreApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
