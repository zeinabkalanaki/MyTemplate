﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public interface IAuditable
    {
        bool IsDeleted { get; set; }
    }
}
