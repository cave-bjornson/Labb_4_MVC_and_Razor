using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LibraryWebApp;

[Dependency(ReplaceServices = true)]
public class LibraryWebAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LibraryWebApp";
}
