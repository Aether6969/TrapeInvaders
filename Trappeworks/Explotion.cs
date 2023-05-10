using GameEngine;

namespace Trappeworks
{
    internal sealed class Explotion : GameObj
    {
        public int Radius => Texture!.Width / 2;

        private long lifeTimeframes = Random.Shared.Next(10, 100)* 4;
        private long instFrame;

        private Explotion(Game game, Transform transform, Texture? texture) : base(game, transform, texture)
        {
            this.instFrame = game.FramesFromStart;
        }

        public static Explotion CreateRandomExplotion(Game game, Vec2 pos)
        {
            FunctionalTexture texture = ExplotionTextures.RandomExpoltion();

            return new Explotion(game, new Transform(pos, texture.Size), texture);
        }

        public override void Update()
        {
            if (Game.FramesFromStart - instFrame > lifeTimeframes)
            {
                Game.RemoveObject(this);
            }
        }
    }
}
