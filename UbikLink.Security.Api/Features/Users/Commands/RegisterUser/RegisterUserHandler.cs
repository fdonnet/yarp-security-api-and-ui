﻿using LanguageExt;
using UbikLink.Common.Db;
using UbikLink.Common.Errors;
using UbikLink.Security.Api.Data.Models;
using UbikLink.Security.Api.Features.Tenants.Services;
using UbikLink.Security.Api.Features.Users.Services;
using UbikLink.Security.Api.Mappers;
using UbikLink.Security.Contracts.Tenants.Commands;
using UbikLink.Security.Contracts.Users.Commands;

namespace UbikLink.Security.Api.Features.Users.Commands.RegisterUser
{
    public class RegisterUserHandler(UserCommandService commandService)
    {
        private static Guid SYSTEM_USER_ID = new("dc820000-5dd4-0015-b13b-08dd55cc80f7");
        private readonly UserCommandService _commandService = commandService;


        public async Task<UserModel> Handle(RegisterUserCommand command)
        {
            var user = command.MapToUser();
            
            //Need to put the system user as the creator of the user (for registration)
            var now = DateTime.UtcNow;
            user.AuditInfo = new AuditData(now, SYSTEM_USER_ID, now, SYSTEM_USER_ID);

            return await _commandService.AddUserInDbAsync(user);
        }
    }
}
