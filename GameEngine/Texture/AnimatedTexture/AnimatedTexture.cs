using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapeInvaders
{
    public sealed class AnimatedTexture : Texture
    {
        public int Frame = 0;
        public bool Loop = true;
        private MonoColTexture[] _Textures;

        public int NumFrames => _Textures.Length;

        public AnimatedTexture(int width, int height, params MonoColTexture[] textures) : base(width, height)
        {
            this._Textures = textures;
        }

        public void Step()
        {
            if (Frame == NumFrames - 1)
            {
                if (Loop)
                {
                    Frame = 0;
                }
            }
            else
            {
                Frame++;
            }

        }

        public override Pixel this[int x, int y] 
        {
            get 
            { 
                return _Textures[Frame][x, y]; 
            }
        }
    }
}
