using MyProductStore.Permissions;
using MyProductStore.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

namespace MyProductStore.Blazor.Pages;
public partial class ProductManagement
{
    public PageToolbar Toolbar { get; } = new();

    public List<TableColumn> ProductManagementTableColumns => TableColumns.Get<ProductManagement>();

    public ProductManagement()
    {
        UpdatePolicyName = MyProductStorePermissions.Products.Edit;
        DeletePolicyName = MyProductStorePermissions.Products.Delete;
        CreatePolicyName = MyProductStorePermissions.Products.Create;
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<ProductManagement>()
            .AddRange(new[]
            {
                new EntityAction
                {
                    Text = L["Edit"],
                    Visible = (data) => HasUpdatePermission,
                    Clicked = async(data) =>await OpenEditModalAsync(data.As<ProductDto>())
                },
                new EntityAction
                {
                    Text = L["Delete"],
                    Visible = (data) => HasDeletePermission,
                    ConfirmationMessage = (data)=> GetDeleteConfirmationMessage(data.As<ProductDto>()),
                    Clicked = async(data)=>await DeleteEntityAsync(data.As<ProductDto>())
                }
            });

        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetTableColumnsAsync()
    {
        ProductManagementTableColumns.AddRange(new[]
        {
            new TableColumn
            {
                Title = L["Actions"],
                Actions = EntityActions.Get<ProductManagement>()
            },
            new TableColumn
            {
                Title = L["DisplayName:Name"],
                Sortable = true,
                Data = nameof(ProductDto.Name),
            },
            new TableColumn
            {
                Title = L["DisplayName:Price"],
                Sortable = true,
                Data = nameof(ProductDto.Price),
            },
            new TableColumn
            {
                Title = L["DisplayName:IsAvailable"],
                Sortable = true,
                Data = nameof(ProductDto.IsAvailable),
            }
        });

        return base.SetTableColumnsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["NewProduct"], async () =>
        {
            await OpenCreateModalAsync();
        });

        return base.SetToolbarItemsAsync();
    }
}