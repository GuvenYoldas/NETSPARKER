
using NETSPARKER.Core.Interfaces;
using NETSPARKER.API.Models.Base;

namespace NETSPARKER.API.Models
{
    public class UserModel : BaseModel<int>, IUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SaltString { get; set; }
        public string AvatarUrl { get; set; }
        public int UserType { get; set; }
        

    }
}
