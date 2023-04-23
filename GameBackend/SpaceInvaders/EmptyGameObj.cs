using GameEngine;

namespace TrapeInvaders
{
    internal class EmptyGameObj : GameObj
    {
        private EmptyGameObj(Game game, Transform transform, Texture texture) 
            : base(game, transform, texture)
        {
        }

        public static EmptyGameObj Create(Game game, Vec2 pos, Texture texture)
        {
            return new EmptyGameObj(game, new Transform(pos, texture.Size), texture);
        }
    }
}
