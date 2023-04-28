using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GameEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public Vec2 Pos;
        public Vec2 Size;

        public Rect(Vec2 Pos, Vec2 Size)
        {
            Assert.Positive(Size);

            this.Pos = Pos;
            this.Size = Size;
        }
        public Rect(int x, int y, int width, int height)
        {
            Assert.Positive(width);
            Assert.Positive(height);

            this.Pos = new Vec2(x, y);
            this.Size = new Vec2(width, height);
        }

        public static bool Overlaps(Rect r1, Rect r2)
        {
            if (r2.Pos.x < r1.Pos.x + r1.Size.x &&
                r1.Pos.x < r2.Pos.x + r2.Size.x &&
                r2.Pos.y < r1.Pos.y + r1.Size.y &&
                r1.Pos.y < r2.Pos.y + r2.Size.y)
            {
                return true;
            }

            return false;
        }
        public bool Contains(Vec2 point)
        {
            if (Pos.x <= point.x && 
                point.x <= Pos.x + Size.x &&
                Pos.y <= point.y &&
                point.y <= Pos.y + Size.y)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"({ Pos }, { Size })";
        }
    }
}
