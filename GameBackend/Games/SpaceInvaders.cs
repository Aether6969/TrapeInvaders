using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend
{
    public sealed class SpaceInvaders : Game
    {
        public SpaceInvaders(IInputManager inputManager, IRenderTarget renderTarget) : 
            base(inputManager, renderTarget)
        {
        }
    }
}
