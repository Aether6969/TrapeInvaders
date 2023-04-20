using TrapeInvaders;

namespace TrapeInvaders
{
    public abstract class GameObj
    {
        public Game Game { get; }
        public Transform Transform { get; }
        public Texture? Texture { get; }

        public GameObj(Game game, Transform transform, Texture? texture)
        {
            this.Game = game;
            this.Transform = transform;
            this.Texture = texture;
        }

        public virtual void Inizialize() { }
        public virtual void Update() { }

        public void Draw()
        {
            if (Texture is null)
            {
                return;
            }

            for (int x = 0; x < Texture.Width; x++)
            {
                for (int y = 0; y < Texture.Height; y++)
                {
                    //draw texture to screne using size for the parts that fit on screen
                    Vec2 pixp = new Vec2(Transform.Pos.x + x, Transform.Pos.y + y);
                    if (pixp.IsInRange(0..(Game.RenderTarget.Size.x - 1), 0..(Game.RenderTarget.Size.y - 1)))
                    {
                        Game.RenderTarget[pixp.x, pixp.y] = Texture[x, y];
                    }
                }
            }
        }
    }
}
