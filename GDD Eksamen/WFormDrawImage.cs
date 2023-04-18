using TrapeInvadersEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GDD_Eksamen
{
    internal sealed class WFDrawImage : IRenderTarget
    {
        Graphics _BackigTarget;
        Action _Draw;

        const int diameter = 7;

        public int Width { get; }
        public int Height { get; }

        public WFDrawImage(int width, int height, Graphics graphics, Action draw) 
        { 
            this.Width = width;
            this.Height = height;
            this._BackigTarget = graphics;
            this._Draw = draw;
        }

        public Pixel this[int x, int y]
        {
            set
            {
                Debug.Assert(!(x > (Width - 1) || y > (Height - 1)));

                _BackigTarget.FillEllipse(
                    new SolidBrush(value), 
                    new Rectangle((int)(x * 7.5d), (int)(y * 7.5d), diameter, diameter));
            }
        }

        public void Draw()
        {
            _Draw();
        }
    }
}
