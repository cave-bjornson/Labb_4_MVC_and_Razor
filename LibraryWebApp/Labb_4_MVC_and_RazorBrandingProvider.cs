using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Labb_4_MVC_and_Razor;

[Dependency(ReplaceServices = true)]
public class Labb_4_MVC_and_RazorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LibraryWebApp";
}
