using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.Infrastructure.Interfaces.Base;
using NETSPARKER.Infrastructure.Services.Base;
using System;


namespace NETSPARKER.Infrastructure.Services
{
    public class UserService : EntityService<UserEntity, int>, IUser
    {
        IUnitOfWork _unitOfWork;
        IUser _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUser userRepository) : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

    }
}
