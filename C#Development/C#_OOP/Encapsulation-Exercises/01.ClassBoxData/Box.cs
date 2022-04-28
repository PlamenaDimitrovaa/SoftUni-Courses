using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;

        private double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }
        private double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }
        private double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea()
        {
            //2lw + 2lh + 2wh
            var surfaceArea = 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            //2lh + 2wh
            var lateralSurfaceArea = 2 * (this.Length * this.Height) + 2*(this.Width * this.Height);
            return lateralSurfaceArea;
        }

       public double Volume()
        {
            //lwh
            var volume = this.Length * this.Width * this.Height;
            return volume;
        }
    }
}
