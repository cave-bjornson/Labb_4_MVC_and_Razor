namespace LibraryWebApp.Permissions;

public static class LibraryPermissions
{
    public const string GroupName = "Library";
    
    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}