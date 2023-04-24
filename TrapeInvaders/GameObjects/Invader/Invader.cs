using GameEngine;

namespace TrapeInvaders
{
    internal sealed class Invader : GameObj
    {
        public enum InvaderType
        {
            TopBoy = 1,
            MidBoy = 2,
            BottomBoy = 3,
        }
        InvaderType type;

        public InvaderGroupe groupe;

        private Invader(Game game, Transform transform, InvaderGroupe groupe, InvaderType invaderType) 
            : base(game, transform, Textures.GetTextureByInvader(invaderType)) 
        { 
            this.type = invaderType; 
            this.groupe = groupe;
            groupe.Invaders.Add(this);
        }

        public static Invader Create(InvaderType invaderType, InvaderGroupe groupe, Vec2 pos, Game game)
        {
            return new Invader(
                game, 
                new Transform(pos, new Vec2(5, 5)),
                groupe,
                invaderType);
        }

        public void Destroy()
        {
            Game.RemoveObject(this);
            groupe.Invaders.Remove(this);
        }
    }
}
