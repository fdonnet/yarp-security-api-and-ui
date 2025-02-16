﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace UbikLink.Common.Http
{
    public static class EndpointsExt
    {
        public static IServiceCollection AddEndpoints(
            this IServiceCollection services,
            Assembly assembly)
        {
            ServiceDescriptor[] serviceDescriptors = assembly
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                               type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        public static IApplicationBuilder MapEndpoints(
            this WebApplication app,
            RouteGroupBuilder? routeGroupBuilder = null)
        {
            using (var scope = app.Services.CreateScope())
            {
                IEnumerable<IEndpoint> endpoints = scope.ServiceProvider
                    .GetRequiredService<IEnumerable<IEndpoint>>();

                IEndpointRouteBuilder builder =
                    routeGroupBuilder is null ? app : routeGroupBuilder;

                foreach (IEndpoint endpoint in endpoints)
                {
                    endpoint.MapEndpoint(builder);
                }
            }

            return app;
        }
    }
}
