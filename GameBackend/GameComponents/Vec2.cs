using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace TrapeInvadersEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        public int x;
        public int y;

        public double Len => Math.Sqrt(x * x + y * y);

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

        public static implicit operator Vec2(int scalar)
        {
            return new Vec2(scalar, scalar);
        }

        public static Vec2 operator - (Vec2 left, Vec2 right)
        {
            return new Vec2(left.x - right.x, left.y - right.y);
        }

        public override string ToString()
        {
            return $"({ x }, { y })";
        }
    }
}
