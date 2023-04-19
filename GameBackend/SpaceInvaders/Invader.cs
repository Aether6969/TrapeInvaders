namespace TrapeInvaders
{
    internal class Invader : GameObj
    {
        public enum InvaderType
        {
            TopBoy = 1,
            MidBoy = 2,
            BottomBoy = 3,
        }
        InvaderType type;

        private Invader(Game game, Transform transform, InvaderType invaderType) 
            : base(game, transform, Textures.GetTextureByInvader(invaderType)) 
        { 
            type = invaderType; 
        }

        public static Invader Create(InvaderType invaderType, Vec2 pos, Game game)
        {
            return new Invader(game, 
                new Transform(pos, new Vec2(5, 5)),
                invaderType);
        }

        public override void Update()
        {
            
        }

    }
}
