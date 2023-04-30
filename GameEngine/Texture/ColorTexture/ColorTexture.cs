using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public sealed class ColorTexture : Texture
    {
        private byte[] _Image;

        public ColorTexture(int width, int height, byte[] image) : base(width, height)
        {
            Assert.True(image.Length % 3 == 0);
            Assert.True(width * height * 3 == image.Length);

            this._Image = image;
        }

        public override Pixel this[int x, int y]
        {
            get
            {
                int row = y * Width * 3;
                int index = row + (x * 3);

                return new Pixel(
                    _Image[index], 
                    _Image[index + 1], 
                    _Image[index + 2]);
            }
        }
    }
}
