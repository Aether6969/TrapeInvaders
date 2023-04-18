using TrapeInvadersEngine;

namespace TrapeInvaders.Games
{
    public sealed class Player : IGameObj
    {
        public Game Game { get; }
        public Transform Transform { get; }
        public Texture Texture { get; }

        private Player(Transform transform, Game game) 
        { 
            this.Transform = transform;
            this.Game = game;
            this.Texture = Textures.Player;
        }

        public IGameObj Create(Vec2 pos, Vec2 size, Game game)
        {
            return new Player(
                new Transform(pos, size), 
                game);
        }

        public void Update()
        {
            IInputManager input = Game.InputManager;

            Transform.Pos = new Vec2(Transform.Pos.x + (int)input.Horizontal, Transform.Pos.y);

            if (input.GetKeyShoot())
            {
                Shoot();
            }
        }

        public void Draw()
        {
            for (int x = 0; x < Texture.Width; x++)
            {
                for (int y = 0; y < Texture.Height; y++)
                {
                    Game.RenderTarget[Transform.Pos.x + x, Transform.Pos.y + y] = Texture[x, y];
                }
            }
        }

        public void Shoot()
        {

        }
    }
}
