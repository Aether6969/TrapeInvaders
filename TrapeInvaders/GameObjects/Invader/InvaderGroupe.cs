using GameEngine;

namespace TrapeInvaders
{
    internal class InvaderGroupe : GameObj
    {
        public List<Invader> Invaders = new List<Invader>();

        public bool MovingRight = true;
        public int FramesBeforeMove = 12;

        private bool _Colided = false;

        public InvaderGroupe(Game game) 
            : base(game, new Transform(), null)
        {
        }

        public override void Update()
        {
            if (!Game.OnecePerFrames(FramesBeforeMove)) return;
            if (Invaders.Count == 0) return;

            Vec2 move = new Vec2();
            if (Invaders.Max((v) => v.Transform.Pos.x) + 5 > 49)
            {
                MovingRight = false;
                _Colided = true;
            }
            else if (Invaders.Min((v) => v.Transform.Pos.x) < 1)
            {
                MovingRight = true;
                _Colided = true;
            }

            move.x = MovingRight ? 1 : -1;

            if (_Colided)
            {
                _Colided = false;
                move.y = 1;
            }

            foreach (Invader invader in Invaders)
            {
                invader.Transform.Pos += move; 
            }
        }
    }
}
