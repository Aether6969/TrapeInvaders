using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TrapeInvadersEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public Vec2 Pos;
        public Vec2 Size;

        public Rect(Vec2 Pos, Vec2 Size)
        {
            Assert.Positive(Pos);

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

        public override string ToString()
        {
            return $"({ Pos }, { Size })";
        }
    }
}
