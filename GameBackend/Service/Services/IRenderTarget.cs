namespace TrapeInvaders
{
    public interface IRenderTarget
    {
        public Vec2 Size { get; }

        public Pixel this[int x, int y] { set; }

        public void Draw();
    }
}
