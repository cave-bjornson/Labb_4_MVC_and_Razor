namespace LibraryWebApp.Menus;

public class LibraryWebAppMenus
{
    private const string Prefix = "LibraryWebApp";
    public const string Home = Prefix + ".Home";

    //Add your menu items here...
    public const string Library = Prefix + ".Library";
    public const string Books = Library + ".Books";
    public const string Loans = Library + ".Loans";

    public const string Customers = Prefix + ".Customers";
    public const string Manage = Customers + ".Manage";
}
