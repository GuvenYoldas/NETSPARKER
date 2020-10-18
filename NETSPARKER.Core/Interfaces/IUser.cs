using NETSPARKER.Core.Interfaces.Base;


namespace NETSPARKER.Core.Interfaces
{
    public interface IUser : IBase<int>
    {
        string Name { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        string SaltString { get; set; }
        string AvatarUrl { get; set; }
        int UserType { get; set; }

    }
}
