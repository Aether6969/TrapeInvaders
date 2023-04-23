namespace GameEngine
{
    internal static class Extentions
    {
        public static void Clear(this IRenderTarget renderTarget, Pixel col)
        {
            for (int x = 0; x < renderTarget.Size.x; x++)
            {
                for (int y = 0; y < renderTarget.Size.y; y++)
                {
                    renderTarget[x, y] = col;
                }
            }
        }
    }
}
