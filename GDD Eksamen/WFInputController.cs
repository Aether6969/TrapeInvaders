using TrapeInvaders;

namespace GDD_Eksamen
{
    internal sealed class WFInputController : IInputManager
    {
        public float Vertical => throw new NotImplementedException();

        public float Horizontal => 0;

        public bool GetKeyShoot()
        {
            return false;
        }
    }
}
