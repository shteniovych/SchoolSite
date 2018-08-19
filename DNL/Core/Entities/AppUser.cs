﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class AppUser : IdentityUser
    {
        public Personal Personal { get; set; }
    }
}
