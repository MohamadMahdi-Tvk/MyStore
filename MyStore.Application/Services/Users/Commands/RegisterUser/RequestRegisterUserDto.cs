﻿namespace MyStore.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RePasword { get; set; }

        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
