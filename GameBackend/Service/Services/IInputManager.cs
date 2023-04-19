namespace TrapeInvaders
{
    public interface IInputManager
    {
        public float Vertical { get; }
        public float Horizontal { get; }

        public bool GetKeyShoot();
    }
}
