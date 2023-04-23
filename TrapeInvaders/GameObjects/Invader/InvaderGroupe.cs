using GameEngine;

namespace TrapeInvaders
{
    internal class InvaderGroupe : GameObj
    {
        public List<Invader> invaders = new List<Invader>();

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

            Vec2 move = new Vec2();
            if (invaders.Max((v) => v.Transform.Pos.x) + 5 > 49)
            {
                MovingRight = false;
                _Colided = true;
            }
            else if (invaders.Min((v) => v.Transform.Pos.x) < 1)
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

            foreach (Invader invader in invaders)
            {
                invader.Transform.Pos += move; 
            }

            
        }
    }
}
