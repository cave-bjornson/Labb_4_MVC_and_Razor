using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LibraryWebApp;

[Dependency(ReplaceServices = true)]
public class Labb_4_MVC_and_RazorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LibraryWebApp";
}
