using MyStore.Application.Interfaces.Context;
using MyStore.Application.Interfaces.FacadPattern;
using MyStore.Application.Services.Users.Commands.EditUser;
using MyStore.Application.Services.Users.Commands.RegisterUser;
using MyStore.Application.Services.Users.Commands.RemoveUser;
using MyStore.Application.Services.Users.Commands.UserLogin;
using MyStore.Application.Services.Users.Commands.UserStatusChange;
using MyStore.Application.Services.Users.Queries.GetRoles;
using MyStore.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Users.FacadPattern
{
    public class UserFacad : IUserFacad
    {
        private readonly IDataBaseContext _context;
        public UserFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetRolesService _getRolesService;
        public IGetRolesService GetRolesService
        {
            get
            {
                return _getRolesService = _getRolesService ?? new GetRolesService(_context);
            }
        }


        private IGetUsersService _getUsersService;
        public IGetUsersService GetUsersService
        {
            get
            {
                return _getUsersService = _getUsersService ?? new GetUsersService(_context);
            }
        }


        private IEditUserService _editUserService;
        public IEditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }


        IRegisterUserService _registerUserService;
        public IRegisterUserService RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }


        private IRemoveUserService _removeUserService;
        public IRemoveUserService RemoveUserService
        {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            }
        }


        private IUserLoginService _userLoginService;
        public IUserLoginService UserLoginService
        {
            get
            {
                return _userLoginService = _userLoginService ?? new UserLoginService(_context);
            }
        }


        private IUserStatusChangeService _userStatusChangeService;
        public IUserStatusChangeService UserStatusChangeService
        {
            get
            {
                return _userStatusChangeService = _userStatusChangeService ?? new UserSatusChangeService(_context);
            }
        }
    }
}
