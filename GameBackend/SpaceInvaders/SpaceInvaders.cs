using TrapeInvaders.Games;

namespace TrapeInvaders
{
    public sealed class SpaceInvaders : Game
    {
        internal GameState GameState { get; } = new GameState();
        public SpaceInvaders(IInputManager inputManager, IRenderTarget renderTarget) : 
            base(inputManager, renderTarget)
        {
            AddObjectToScene(
                Player.Create(
                    new Vec2(22, 88),
                    this));

            AddInvadersToScene();
        }

        private void AddInvadersToScene()
        {
            InvaderGroupe groupe = new InvaderGroupe(this);
            AddObjectToScene(groupe);

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    int x = (col + 1) * 7 - 5;
                    int y = row * 7;

                    if (row is 4)
                    {
                        AddObjectToScene(
                        Invader.Create(
                            Invader.InvaderType.TopBoy,
                            groupe,
                            new Vec2(x, y),
                        this));
                    }
                    if (row is 2 or 3)
                    {
                        AddObjectToScene(
                        Invader.Create(
                            Invader.InvaderType.MidBoy,
                            groupe,
                            new Vec2(x, y),
                        this));
                    }
                    if (row is 0 or 1)
                    {
                        AddObjectToScene(
                        Invader.Create(
                            Invader.InvaderType.BottomBoy,
                            groupe,
                            new Vec2(x, y),
                        this));
                    }
                }
            }
        }
    }
}
