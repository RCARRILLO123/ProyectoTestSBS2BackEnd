﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Application.DTOs.Account.Response
{
    public class AuthenticationResponse
    {
        public string? JWToken { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
