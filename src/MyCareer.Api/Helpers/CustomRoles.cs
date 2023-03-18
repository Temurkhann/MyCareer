namespace ZaminEducation.Api.Helpers;

#pragma warning disable
public static class CustomRoles
{
    private const string Admin = "Admin";
    private const string Mentor = "Mentor";
    private const string User = "User";
    public const string SuperAdmin = "SuperAdmin";

    public const string AllRoles = User + "," + Mentor + "," + Admin + "," + SuperAdmin;
    public const string UserRole = User + "," + AdminRole + "," + SuperAdmin;
    public const string MentorRole = Mentor + "," + AdminRole + "," + SuperAdmin;
    public const string AdminRole = Admin + "," + SuperAdmin;
    public const string SuperAdminRole = SuperAdmin;

}
