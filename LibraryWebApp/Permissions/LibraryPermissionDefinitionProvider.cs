using LibraryWebApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LibraryWebApp.Permissions;

public class LibraryPermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <inheritdoc />
    public override void Define(IPermissionDefinitionContext context)
    {
        var libraryGroup = context.AddGroup(LibraryPermissions.GroupName, L("Permission:Library"));

        var booksPermission = libraryGroup.AddPermission(LibraryPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(LibraryPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(LibraryPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(LibraryPermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LibraryWebAppResource>(name);
    }
}