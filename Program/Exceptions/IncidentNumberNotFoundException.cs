﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    internal class IncidentNumberNotFoundException: Exception
    {
        public IncidentNumberNotFoundException(string message) : base(message)
        {
        }
    }
}
