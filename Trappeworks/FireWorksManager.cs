using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trappeworks
{
    internal sealed class FireWorksManager : GameObj
    {
        private FireWorksManager(Game game, Transform transform) : base(game, transform, null)
        {
        }

        public static FireWorksManager Create(Game game)
        {
            return new FireWorksManager(game, new Transform());
        }

        public override void Update()
        {
            if (!Game.OnecePerFrames(1)) return;

            Vec2 pos = new Vec2(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));

            Explotion explotion = Explotion.CreateRandomExplotion(Game, pos);

            if (Game.GetAllObjects().Where((o) => o is Explotion).Count() == 0)
            {
                Game.Instantiate(explotion);
            }
        }
    }
}
