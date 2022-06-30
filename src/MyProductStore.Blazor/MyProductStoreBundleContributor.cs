using Volo.Abp.Bundling;

namespace MyProductStore.Blazor;

/* Add your global styles/scripts here.
 * See https://docs.abp.io/en/abp/latest/UI/Blazor/Global-Scripts-Styles to learn how to use it
 */
public class MyProductStoreBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("myscript.js");
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", excludeFromBundle: true);
    }
}
