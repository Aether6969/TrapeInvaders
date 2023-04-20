using System.Collections;
using TrapeInvaders;

namespace TrapeInvaders
{
    public class MonoColTexture : Texture
    {
        byte[] _Image;

        public Pixel Color;

        public MonoColTexture(int width, int height, Pixel col, byte[] image) : base(width, height)
        {
            Assert.True(image.Length == width * height);

            _Image = image;
            Color = col;
        }

        //flip y and draw color if byte not 0
        public override Pixel this[int x, int y] => _Image[(Height - 1 - y) * Width + x] != 0 ? Color : Pixel.None;
    }
}
