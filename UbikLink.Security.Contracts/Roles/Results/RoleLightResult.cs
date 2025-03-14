﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbikLink.Security.Contracts.Roles.Results
{
    public record RoleLightResult
    {
        public Guid Id { get; init; }
        public required string Code { get; init; }
    }
}
