﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public virtual ICollection<OfficeUsers> OfficeUsers { get; set; } = new List<OfficeUsers>();

    }
}