using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProductStore.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MyProductStore.Products;

public class ProductAppService : CrudAppService<
    Product,
    ProductDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateProductDto,
    UpdateProductDto>, IProductAppService
{
    private readonly IProductRepository _productRepository;

    public ProductAppService(IRepository<Product, Guid> repository, IProductRepository productRepository) :
        base(repository)
    {
        _productRepository = productRepository;
        GetListPolicyName = MyProductStorePermissions.Products.Default;
        GetPolicyName = MyProductStorePermissions.Products.Default;
        CreatePolicyName = MyProductStorePermissions.Products.Create;
        UpdatePolicyName = MyProductStorePermissions.Products.Edit;
        DeletePolicyName = MyProductStorePermissions.Products.Delete;
    }

    public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //throw new Exception("This operation can't be done!");

        //throw new UserFriendlyException(L["OperationCantBeDone"], "MyProductStore.0102");

        return await base.GetListAsync(input);
    }

    public async Task<List<ProductDto>> GetProductsByAvailabilityAsync(bool isAvailable)
    {
        var unavailableProducts = await _productRepository.GetListByAvailability(false);

        return ObjectMapper.Map<List<Product>, List<ProductDto>>(unavailableProducts);
    }
}