using TrapeInvaders;

namespace TrapeInvaders
{
    public abstract class GameObj
    {
        public Game Game { get; }
        public Transform Transform { get; }
        public Texture Texture { get; }

        public GameObj(Game game, Transform transform, Texture texture)
        {
            this.Game = game;
            this.Transform = transform;
            this.Texture = texture;
        }

        public virtual void Inizialize() { }
        public virtual void Update() { }
    }
}
