﻿using LanguageExt;
using UbikLink.Common.Api;
using UbikLink.Common.Errors;
using UbikLink.Security.Api.Data.Models;
using UbikLink.Security.Api.Features.Subscriptions.Services;
using UbikLink.Security.Api.Features.Subscriptions.Services.Poco;

namespace UbikLink.Security.Api.Features.Subscriptions.Queries.GetSubscriptionAllLinkedTenantsForOwner
{
    public class GetSubscriptionAllLinkedTenantsForOwnerHandler(SubscriptionQueryService queryService, ICurrentUser currentUser)
    {
        private readonly SubscriptionQueryService _queryService = queryService;
        private readonly ICurrentUser _currentUser = currentUser;

        public async Task<Either<IFeatureError, List<TenantWithLinkedUsers>>> Handle()
        {
            return await _queryService.GetSelectedSubscriptionForOwnerAsync(_currentUser.Id)
                .BindAsync(s => _queryService.GetSubscriptionAllLinkedTenantsAsync(s.Id));
        }
    }
}
