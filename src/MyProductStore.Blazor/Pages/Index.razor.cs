using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using MyProductStore.Permissions;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Progression;
using Microsoft.Extensions.Localization;
using Volo.Abp.Users;
using Volo.Abp.MultiTenancy;
using Microsoft.JSInterop;

namespace MyProductStore.Blazor.Pages;

public partial class Index
{
    public List<BreadcrumbItem> Breadcrumbs { get; } = new();

    public PageToolbar Toolbar { get; } = new();

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected override Task OnInitializedAsync()
    {
        Breadcrumbs.Add(new BreadcrumbItem("Home", "/"));
        Breadcrumbs.Add(new BreadcrumbItem("Product Management", "/product-management"));
        Breadcrumbs.Add(new BreadcrumbItem("New", "/product-management/new"));

         
        Toolbar.AddButton("SayHello", async () =>
        {
            Alerts.Success("Hello!", dismissible: true);
        });

        Toolbar.AddButton("Clear Alerts", async () =>
        {
            Alerts.Clear();
        });

        Toolbar.AddComponent(typeof(Notifications));

        return Task.CompletedTask;
    }

    public Task AddPageAlertAsync()
    {
        Alerts.Danger("Hello World", "Alert Title");

        return Task.CompletedTask;
    }

    int progress = 0;
    public async Task MakeProgressAsync()
    {
        progress += 10;

        if (progress > 100)
        {
            progress = -1;
        }

        await Progress.Go(progress, options =>
        {
            options.Type = UiPageProgressType.Success;
        });
    }

    public async Task SayHelloFromJSAsync()
    {
        await JSRuntime.InvokeVoidAsync("sayHello", new[] { CurrentUser.UserName });
    }
}
