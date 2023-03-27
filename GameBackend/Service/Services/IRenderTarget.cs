using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public interface IRenderTarget
    {
        public int Width { get; }
        public int Height { get; }

        public Pixel this[int x, int y] { set; }

        public void Draw();
    }
}
