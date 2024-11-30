﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Excpetions
{
    public class InternalServerException : Exception
    {
        public string? Details { get; }
        public InternalServerException(string message) : base(message) { }
        public InternalServerException(string message, string details) : base(message)
        {
            Details=details;
        }


    }
}

