using TrapeInvaders;
using System.Diagnostics;

namespace GDD_Eksamen
{
    internal sealed class WFDrawImage : IRenderTarget
    {
        Graphics _BackigTarget;
        Action _Draw;

        const int diameter = 7;

        public Vec2 Size { get; }

        public WFDrawImage(int width, int height, Graphics graphics, Action draw) 
        { 
            this.Size = new Vec2(width, height);
            this._BackigTarget = graphics;
            this._Draw = draw;
        }

        public Pixel this[int x, int y]
        {
            set
            {
                Debug.Assert(!(x > (Size.x - 1) || y > (Size.y - 1)));

                _BackigTarget.FillEllipse(
                    new SolidBrush(value), 
                    new Rectangle((int)(x * 7.5d), (int)((Size.y - 1 - y) * 7.5d), diameter, diameter));
            }
        }

        public void Draw()
        {
            _Draw();
        }
    }
}
