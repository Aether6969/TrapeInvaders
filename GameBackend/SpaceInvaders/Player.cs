using TrapeInvaders;

namespace TrapeInvaders.Games
{
    public sealed class Player : GameObj
    {
        private Player(Transform transform, Game game) : base(game, transform, Textures.Player) { }

        public static Player Create(Vec2 pos, Game game)
        {
            return new Player(
                new Transform(pos, new Vec2(7, 5)), 
                game);
        }

        public override void Update()
        {
            IInputManager input = Game.InputManager;

            Transform.Pos = new Vec2(Transform.Pos.x + (int)input.Horizontal, Transform.Pos.y);

            if (input.GetKeyShoot())
            {
                Shoot();
            }
        }

        public void Shoot()
        {

        }
    }
}
