﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Excpetions
{
    public  class NotFoundException :Exception
    {
        public NotFoundException(string message):base(message){}
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) wos not found.")
        {
            
        }
    }
}
