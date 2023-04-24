using GameEngine;

namespace TrapeInvaders
{
    internal class Projectile : GameObj
    {
        public bool Friendly;
        public Player? Player;

        public Projectile(Game game, Transform transform, Player? player, bool friendly) 
            : base(game, transform, Textures.Projectile) 
        {
            this.Friendly = friendly;

            this.Player = player;
            if (player is not null)
            {
                player.Projectil = this;
            }
        }

        public static Projectile Create(Game game, Vec2 pos, Player player, bool friendly)
        {
            return new Projectile(game, new Transform(pos, 1), player, friendly);
        }

        public override void Update()
        {
            if (Friendly)
            {
                if (!Game.OnecePerFrames(2)) return;
            }
            else
            {
                if (!Game.OnecePerFrames(4)) return;
            }

            Transform.Pos += new Vec2(0, Friendly ? -2 : 2);

            if (Transform.Pos.y < -2 || Transform.Pos.y > 90)
            {
                Game.RemoveObject(this);
                if (Player is not null)
                {
                    Player!.Projectil = null;
                }
                return;
            }

            foreach (GameObj obj in Game.OverLaps(this))
            {
                if (Friendly && obj is Invader invader)
                {
                    invader.Destroy();
                    Game.RemoveObject(this);
                    Player!.Projectil = null;
                }
                else if (obj is Player)
                {
                    throw new NotImplementedException();
                    Game.RemoveObject(this);
                }
            }
        }
    }
}
