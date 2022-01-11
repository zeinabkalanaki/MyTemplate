﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Infrastructures.Security
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
