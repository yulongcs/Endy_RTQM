using System;
using System.Collections.Generic;
using System.Linq;
using Lgsoft.RTQM.Application.SecurityModule.DTOs;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Services;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;
using Lgsoft.SF.Infrastructure.CrossCutting.Logging;

namespace Lgsoft.RTQM.Application.SecurityModule.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleService _userRoleService;

        public UserAppService(ITypeAdapter typeAdapter, IUserRepository userRepository, IUserRoleService userRoleService)
        {
            _typeAdapter = typeAdapter;
            _userRepository = userRepository;
            _userRoleService = userRoleService;
        }

        #region Implementation of IUserAppService

        public UserDTO CreateNewUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return null;

            var user = UserFactory.CreateUser(userDTO.UserName, userDTO.ADAccount, userDTO.RealName,
                                              userDTO.Department, userDTO.Email);
            user.Id = IdentityGenerator.NewSequentialGuid();
            user.CreateDate = DateTime.Now;
            user.SetPassword(userDTO.Password);

            _userRepository.Add(user);

            _userRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<User, UserDTO>(user);
        }

        public UserDTO UpdateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return null;

            var persisted = _userRepository.Get(userDTO.Id);

            if (persisted != null)
            {
                var current = UserFactory.CreateUser(persisted.UserName, userDTO.ADAccount, userDTO.RealName,
                                                     userDTO.Department, userDTO.Email);
                current.Id = userDTO.Id;
                current.CreateDate = persisted.CreateDate;
                current.Password = persisted.Password;

                _userRepository.Merge(persisted, current);

                _userRepository.UnitOfWork.Commit();

                return _typeAdapter.Adapt<User, UserDTO>(persisted);
            }
            return null;
        }

        public void RemoveUser(Guid userId)
        {
            if (userId == Guid.Empty)
                return;

            var user = _userRepository.Get(userId);

            if (user != null)
            {
                _userRepository.Remove(user);

                _userRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning("不能删除不存在的用户信息。");
        }

        public void SetUserRoles(Guid userId, Guid[] roleIds)
        {
            _userRoleService.SetUserRoles(userId, roleIds);
        }

        public void SetUserPassword(Guid userId, string password)
        {
            if (userId == Guid.Empty)
                return;

            var user = _userRepository.Get(userId);

            if (user != null)
            {
                user.SetPassword(password);

                _userRepository.UnitOfWork.Commit();
            }
        }

        public bool CheckUserPassword(string userName, string password)
        {
            var spec = UserSpecifications.UserNameExactMatching(userName);

            var user = _userRepository.AllMatching(spec).SingleOrDefault();

            if (user == null)
                return false;
            return user.CheckPassword(password);
        }

        public List<RoleDTO> GetUserRoles(Guid userId)
        {
            return _typeAdapter.Adapt<IEnumerable<Role>, List<RoleDTO>>(_userRepository.GetUserRoles(userId));
        }

        public UserDTO GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
                return null;

            var user = _userRepository.Get(userId);

            if (user != null)
                return _typeAdapter.Adapt<User, UserDTO>(user);
            return null;
        }

        public UserDTO GetUser(string userName)
        {
            var user = _userRepository.AllMatching(UserSpecifications.UserNameExactMatching(userName)).SingleOrDefault();

            if (user != null)
                return _typeAdapter.Adapt<User, UserDTO>(user);
            return null;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _typeAdapter.Adapt<IEnumerable<User>, List<UserDTO>>(_userRepository.GetAll());
        }

        #endregion
    }
}
