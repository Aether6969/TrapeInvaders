namespace GameEngine
{
    public abstract class Texture
    {
        public int Width { get; }
        public int Height { get; }

        public Vec2 Size => new Vec2(Width, Height);

        public Texture(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract Pixel this[int x, int y] { get; }

        public override string ToString()
        {
            return Size.ToString();
        }
    }
}
