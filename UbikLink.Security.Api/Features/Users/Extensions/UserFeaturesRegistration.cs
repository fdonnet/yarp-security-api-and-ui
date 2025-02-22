﻿using UbikLink.Security.Api.Features.Tenants.Commands.AddTenantForAdmin;
using UbikLink.Security.Api.Features.Tenants.Queries.GetAllTenantsForAdmin;
using UbikLink.Security.Api.Features.Tenants.Queries.GetTenantForAdmin;
using UbikLink.Security.Api.Features.Tenants.Services;
using UbikLink.Security.Api.Features.Users.Commands.UpdateUserSettingsMe;
using UbikLink.Security.Api.Features.Users.Queries.GetUserForProxy;
using UbikLink.Security.Api.Features.Users.Queries.GetUserMe;
using UbikLink.Security.Api.Features.Users.Services;

namespace UbikLink.Security.Api.Features.Users.Extensions
{
    public static class UserFeaturesRegistration
    {
        public static void AddUserFeatures(this IServiceCollection services)
        {
            services.AddScoped<GetUserForProxyHandler>();
            services.AddScoped<GetUserMeHandler>();

            services.AddScoped<UpdateUserSettingsMeHandler>();
            services.AddScoped<UpdateUserSettingsMeValidator>();

            services.AddScoped<UserQueryService>();
            services.AddScoped<UserCommandService>();
        }
    }
}
