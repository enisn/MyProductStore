using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace MyProductStore;

[DependsOn(
    typeof(MyProductStoreApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class MyProductStoreHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Dynamic Proxies:
        //context.Services.AddHttpClientProxies(
        //    typeof(MyProductStoreApplicationContractsModule).Assembly,
        //    RemoteServiceName
        //);

        // Static proxies:
        context.Services.AddStaticHttpClientProxies(
            typeof(MyProductStoreApplicationContractsModule).Assembly,
            RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MyProductStoreHttpApiClientModule>();
        });
    }
}
