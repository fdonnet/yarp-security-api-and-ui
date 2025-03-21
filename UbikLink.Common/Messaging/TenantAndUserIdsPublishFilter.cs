﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbikLink.Common.Api;

namespace UbikLink.Common.Messaging
{
    public class TenantAndUserIdsPublishFilter<T>(ICurrentUser currentUser) :
        IFilter<PublishContext<T>>
        where T : class
    {
        public Task Send(PublishContext<T> context, IPipe<PublishContext<T>> next)
        {
            context.Headers.Set("TenantId", currentUser.TenantId.ToString());
            context.Headers.Set("UserId", currentUser.Id.ToString());

            return next.Send(context);
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}
