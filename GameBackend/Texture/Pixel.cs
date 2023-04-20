using System.Drawing;

namespace TrapeInvaders
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
        public Pixel(double r, double g, double b)
        {
            this.R = (byte)(r * 255);
            this.G = (byte)(g * 255);
            this.B = (byte)(b * 255);
        }

        public static readonly Pixel None           = new Pixel(0, 0, 0);
        public static readonly Pixel AlienBlue      = new Pixel(0, 0, 255);
        public static readonly Pixel PlayerGreen    = new Pixel(0, 255, 0);
        public static readonly Pixel FunnyYellow    = new Pixel(255, 255, 0);

        public static Pixel operator + (Pixel left, Pixel right)
        {
            return new Pixel(
                (byte)(left.R + right.R), 
                (byte)(left.G + right.G), 
                (byte)(left.B + right.B));
        }
        public static Pixel operator * (Pixel col, double scalar)
        {

            return new Pixel(
                (byte)(col.R * scalar), 
                (byte)(col.G * scalar), 
                (byte)(col.B * scalar));
        }
        public static Pixel operator *(Pixel left, Pixel right)
        {

            return new Pixel(
                (byte)(left.R * (right.R / 255d)), 
                (byte)(left.G * (right.G / 255d)), 
                (byte)(left.B * (right.B / 255d)));
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
