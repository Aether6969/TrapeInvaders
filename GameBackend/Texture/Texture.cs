using TrapeInvadersEngine;

namespace TrapeInvaders
{
    public abstract class Texture
    {
        public int Width { get; }
        public int Height { get; }

        public Texture(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract Pixel this[int x, int y] { get; }
    }
}
