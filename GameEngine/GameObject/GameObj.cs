namespace GameEngine
{
    public abstract class GameObj
    {
        public Game Game { get; }
        public Transform Transform { get; }
        public Texture? Texture { get; set; }

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
                    if (pixp > -1 && pixp.x < Game.RenderTarget.Size.x && pixp.y < Game.RenderTarget.Size.y)
                    {
                        Game.RenderTarget[pixp.x, pixp.y] = Texture[x, y];
                    }
                }
            }
        }

        public static bool Overlaps(GameObj obj1, GameObj obj2)
        {
            return Rect.Overlaps(obj1.Transform.Rect, obj2.Transform.Rect);
        }

        public override string ToString()
        {
            return $"{ this.GetType().Name }, Tex { Texture }, Tra { Transform }";
        }
    }
}
