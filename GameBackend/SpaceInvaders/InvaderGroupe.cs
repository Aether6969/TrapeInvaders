namespace TrapeInvaders
{
    internal class InvaderGroupe : GameObj
    {
        public List<Invader> invaders = new List<Invader>();

        public bool MovingRight = true;
        public int FramesBeforeMove = 12;

        public InvaderGroupe(Game game) 
            : base(game, new Transform(), null)
        {
        }

        public override void Update()
        {
            return;
            if (Game.FramesFromStart % 12 != 6)
            {
                return;
            }

            Vec2 move = new Vec2();

            if (invaders.Max((v) => v.Transform.Pos.x) + 5 > 50)
            {
                move.y = 1;
                MovingRight = false;
            }
            else if (invaders.Min((v) => v.Transform.Pos.x) < 0)
            {
                move.y = 1;
                MovingRight = true;
            }

            move.x = MovingRight ? 1 : -1;

            foreach (Invader invader in invaders)
            {
                invader.Transform.Pos += move; 
            }

            
        }
    }
}
