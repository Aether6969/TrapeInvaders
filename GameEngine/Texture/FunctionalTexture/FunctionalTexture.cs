namespace GameEngine
{
    public sealed class FunctionalTexture : Texture
    {
        private Func<(int x, int y), Pixel> _Func;

        public FunctionalTexture(int width, int height, Func<(int x, int y), Pixel> func) : base(width, height)
        {
            this._Func = func;
        }

        public override Pixel this[int x, int y]
        {
            get
            {
                return _Func((x, y));
            }
        }
    }
}
