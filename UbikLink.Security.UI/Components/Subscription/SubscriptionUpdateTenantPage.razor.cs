﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using UbikLink.Common.Frontend.Auth;
using UbikLink.Common.RazorUI.Components;
using UbikLink.Security.Contracts.Subscriptions.Results;
using UbikLink.Security.UI.Shared.Httpclients;

namespace UbikLink.Security.UI.Components.Subscription
{
    public partial class SubscriptionUpdateTenantPage(ClientUserService userService, IHttpSecurityClient securityClient)
        : Basepage(userService, securityClient)
    {
        protected override List<BreadcrumbListItem> BreadcrumbItems
        {
            get
            {
                return _breadcrumbItems;
            }
        }

        [Parameter]
        public Guid Id { get; set; }

        private bool _isSubscriptionOwner = false;
        private Guid _selectedSubscriptionId = default;

        private static readonly List<BreadcrumbListItem> _breadcrumbItems = [
            new BreadcrumbListItem()
            {
                Position =1,
                Url = "/",
                Name = "Home"
            },
            new BreadcrumbListItem()
            {
                Position =2,
                Url = "/subscription",
                Name = "Subscription"
            }];

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var (IsOwner, SelectedSubscriptionId) = await IsOwnerOfTheSelectedSubscription();

            _isSubscriptionOwner = IsOwner;
            if (SelectedSubscriptionId != null)
                _selectedSubscriptionId = (Guid)SelectedSubscriptionId;
        }
    }
}
