using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public struct Pixel
    {
        public byte R, G, B;
        
        public Pixel(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public static Pixel operator + (Pixel left, Pixel right)
        {
            return new Pixel(
                (byte)(left.R + right.R), 
                (byte)(left.G + right.G), 
                (byte)(left.B + right.B));
        }
        public static Pixel operator * (Pixel col, double scalar)
        {
            byte R = (byte)(col.R * scalar);
            byte G = (byte)(col.G * scalar);
            byte B = (byte)(col.B * scalar);

            return new Pixel(R, G, B);
        }

        public static implicit operator Pixel(double scalar)
        {
            double s = Math.Clamp(scalar, 0, 1);

            byte b = (byte)(s * 255);

            return new Pixel(b, b, b);
        }
        public static implicit operator Color(Pixel pixel)
        {
            return Color.FromArgb(pixel.R, pixel.G, pixel.B);
        }

        public override string ToString()
        {
            return $"({ R }, { G }, { B })";
        }
    }
}
