using GameEngine;

namespace Trappeworks
{
    internal sealed class Explotion : GameObj
    {
        private Explotion(Game game, Transform transform, Texture? texture) : base(game, transform, texture)
        {
        }

        public static Explotion CreateRandomExplotion(Game game, Vec2 pos)
        {
            FunctionalTexture texture = ExplotionTextures.RandomExpoltion();

            return new Explotion(game, new Transform(pos, 0), texture);
        }
    }
}
