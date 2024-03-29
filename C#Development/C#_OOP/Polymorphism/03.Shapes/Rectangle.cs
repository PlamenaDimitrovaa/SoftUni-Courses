﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
           return Height * Width;
        }


        public override double CalculatePerimeter()
        {
            return 2 * Width + 2 * Height;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
