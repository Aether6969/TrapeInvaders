using TrapeInvaders;

namespace TrapeInvadersEngine
{
    public interface IGameObj
    {
        public Game Game { get; }
        public Transform Transform { get; }
        public Texture Texture { get; }

        public IGameObj Create(Vec2 pos, Vec2 size, Game game);

        public void Inizialize() { }
        public void Update() { }
        public void Draw() { }
    }
}
