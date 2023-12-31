﻿using LibraryWebApp.Localization;
using LibraryWebApp.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace LibraryWebApp.Menus;

public class LibraryWebAppMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<LibraryWebAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                LibraryWebAppMenus.Home,
                nameof(LibraryWebAppMenus.Home),
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                LibraryWebAppMenus.Library,
                nameof(LibraryWebAppMenus.Library),
                icon: "fa fa-book"
            )
                .AddItem(new ApplicationMenuItem(LibraryWebAppMenus.Books, "Books", url: "/Books"))
                .AddItem(
                    new ApplicationMenuItem(
                        LibraryWebAppMenus.Loans,
                        "Loans",
                        url: "/Loans"
                    ).RequirePermissions(LibraryPermissions.Loans.Default)
                )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                LibraryWebAppMenus.Customers,
                nameof(LibraryWebAppMenus.Customers),
                icon: "fa fa-user"
            ).AddItem(
                new ApplicationMenuItem(
                    LibraryWebAppMenus.Manage,
                    "Manage",
                    url: "/Customers"
                ).RequirePermissions(LibraryPermissions.Customers.Default)
            )
        );

        if (LibraryWebAppModule.IsMultiTenant)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        return Task.CompletedTask;
    }
}
