﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IRepair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
}
