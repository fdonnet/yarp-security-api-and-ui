﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbikLink.Security.Contracts.Users.Results
{
    public record UserRegisterResult
    {
        public Guid Id { get; init; }
        public required string AuthId { get; init; }
        public required string Firstname { get; init; }
        public required string Lastname { get; init; }
        public required string Email { get; init; }
        public Guid Version { get; init; }
    }
}
