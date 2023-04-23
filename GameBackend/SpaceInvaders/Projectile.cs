using GameEngine;

namespace TrapeInvaders
{
    internal class Projectile : GameObj
    {
        public bool Friendly;
        public Projectile(Game game, Transform transform, Texture? texture, bool friendly) 
            : base(game, transform, texture) 
        {
            this.Friendly = friendly;
        }

        public override void Update()
        {
            if (Friendly)
            {
                if (!Game.OnecePerFrames(6)) return;
            }
            else
            {
                if (!Game.OnecePerFrames(8)) return;
            }

            Transform.Pos += new Vec2(0, Friendly ? -1 : 1);

            foreach (GameObj obj in Game.OverLaps(this))
            {
                if (Friendly && obj is Invader invader)
                {
                    invader.Destroy();
                }
                else if (obj is Player)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
