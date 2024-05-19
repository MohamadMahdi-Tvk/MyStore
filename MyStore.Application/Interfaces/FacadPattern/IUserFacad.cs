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

namespace MyStore.Application.Interfaces.FacadPattern
{
    public interface IUserFacad
    {
        IGetRolesService GetRolesService { get; }

        IGetUsersService GetUsersService { get; }

        IEditUserService EditUserService { get; }

        IRegisterUserService RegisterUserService { get; }

        IRemoveUserService RemoveUserService { get; }

        IUserLoginService UserLoginService { get; }

        IUserStatusChangeService UserStatusChangeService { get; }
    }
}
