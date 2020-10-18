using NETSPARKER.Core.Entities.Base;
using NETSPARKER.Core.Interfaces;

namespace NETSPARKER.Core.Entities
{
    public class UserEntity: BaseEntity<int>, IUser
    {
        public UserEntity() { 
        
        }
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
