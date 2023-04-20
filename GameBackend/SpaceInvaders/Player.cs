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

            int x = Transform.Pos.x + (int)input.Horizontal;
            if (x < 0 || x + Texture!.Width > 50)
            {
                x = Transform.Pos.x;
            }

            Transform.Pos = new Vec2(x, Transform.Pos.y);

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
