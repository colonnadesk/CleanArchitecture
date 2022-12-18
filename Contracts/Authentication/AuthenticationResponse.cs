﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(Guid Id, string Email, string FirstName, string LastName, string Token);
}