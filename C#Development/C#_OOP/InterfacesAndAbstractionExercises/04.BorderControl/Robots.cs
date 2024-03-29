﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robots : IIdentifiable
    {
        public string Model { get; private set; }
        public string Id { get; private set; }

        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
