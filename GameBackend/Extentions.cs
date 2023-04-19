using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrapeInvaders;

namespace TrapeInvaders
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

        public static void Draw(this GameObj gameObj)
        {
            for (int x = 0; x < gameObj.Texture.Width; x++)
            {
                for (int y = 0; y < gameObj.Texture.Height; y++)
                {
                    Vec2 pixp = new Vec2(gameObj.Transform.Pos.x + x, gameObj.Transform.Pos.y + y);
                    if (pixp.IsInRange(0..(gameObj.Game.RenderTarget.Size.x - 1), 0..(gameObj.Game.RenderTarget.Size.y - 1)))
                    {
                        gameObj.Game.RenderTarget[pixp.x, pixp.y] = gameObj.Texture[x, y];
                    }
                }
            }
        }
    }
}
