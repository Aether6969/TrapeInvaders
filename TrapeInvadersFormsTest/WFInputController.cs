using GameEngine;

namespace TrapeInvadersFormsTest
{
    internal sealed class WFInputController : IInputManager
    {
        public float Vertical => throw new NotImplementedException();

        public float Horizontal => -1;

        public bool GetKeyShoot()
        {
            return true;
        }
    }
}
