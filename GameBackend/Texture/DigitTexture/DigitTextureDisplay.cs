using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapeInvaders
{
    internal class DigitTextureDisplay : Texture
    {
        public byte Digit { get; set; }
        public Pixel Color 
        { 
            get => _DigitTexture.Color; 
            set
            {
                _DigitTexture.Color = value;
            }
        }

        private MonoColTexture _DigitTexture;

        public DigitTextureDisplay(int width, int height, byte digit) : base(width, height) 
        { 
            this.Digit = digit;
            this._DigitTexture = Textures.GetTextureByDigit(digit);
        }

        public override Pixel this[int x, int y] => _DigitTexture[x, y];
    }
}
