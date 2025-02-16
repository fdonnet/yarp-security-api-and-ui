﻿using Microsoft.AspNetCore.Components;
using UbikLink.Common.Frontend.Auth;
using UbikLink.Common.RazorUI.Components;
using UbikLink.Security.UI.Shared.Httpclients;

namespace UbikLink.Security.UI.Components.Tenant
{
    public partial class TenantUpdateUserRolesPage(ClientUserService userService, IHttpSecurityClient securityClient)
        : Basepage(userService, securityClient)
    {
        [Parameter]
        public Guid Id { get; set; }

        private bool _isTenantManager = false;

        protected override List<BreadcrumbListItem> BreadcrumbItems
        {
            get
            {
                return _breadcrumbItems;
            }
        }

        private bool _isSubscriptionOwner = false;

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
                Url = "/tenant",
                Name = "Tenant"
            }];

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _isTenantManager = CanAccessIfHasAuthorizations(["tenant:read", "user:read", "tenant-user-role:write", "tenant-role:read"]);
            _isSubscriptionOwner = User?.IsSubOwnerOfTheSelectetdTenant ?? false;
        }
    }
}
