using System.Runtime.InteropServices;

namespace GameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        public int x;
        public int y;

        public double Mag => Math.Sqrt(x * x + y * y);

        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2 WithX(int x)
        {
            return new Vec2(x, y);
        }
        public Vec2 WithY(int y)
        {
            return new Vec2(x, y);
        }

        public bool IsInRange(Range rangeX, Range rangeY)
        {
            if (rangeX.Start.Value <= x && rangeX.End.Value >= x && rangeY.Start.Value <= y && rangeY.End.Value >= y)
            {
                return true;
            }

            return false;
        }

        public static implicit operator Vec2(int scalar)
        {
            return new Vec2(scalar, scalar);
        }

        public static Vec2 operator + (Vec2 left, Vec2 right)
        {
            return new Vec2(left.x + right.x, left.y + right.y);
        }
        public static Vec2 operator - (Vec2 left, Vec2 right)
        {
            return new Vec2(left.x - right.x, left.y - right.y);
        }

        public static bool operator < (Vec2 left, Vec2 right)
        {
            return left < right.x && left < right.y;
        }
        public static bool operator > (Vec2 left, Vec2 right)
        {
            return left > right.x && left > right.y;
        }
        public static bool operator < (Vec2 vec, int upper)
        {
            return vec.x < upper && vec.y < upper;
        }
        public static bool operator > (Vec2 vec, int lower)
        {
            return vec.x > lower && vec.y > lower;
        }

        public override string ToString()
        {
            return $"({ x }, { y })";
        }
    }
}
