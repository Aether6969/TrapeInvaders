using TrapeInvaders.Games;

namespace TrapeInvaders
{
    public sealed class SpaceInvaders : Game
    {
        public SpaceInvaders(IInputManager inputManager, IRenderTarget renderTarget) : 
            base(inputManager, renderTarget)
        {
            AddObjectToScene(
                Player.Create(
                    new Vec2(22, 4),
                    this));

            AddInvadersToScene();
        }

        private void AddInvadersToScene()
        {
            for (int row = 0; row < 5; row++)
            {
                if (row == 1)
                {
                    int y = (5 - row) * 7 + 2;

                    for (int col = 0; col < 7; col++)
                    {
                        AddObjectToScene(
                            Invader.Create(
                                Invader.InvaderType.TopBoy,
                                new Vec2((col + 1) * 6 - 2, y),
                            this));
                    }
                }
            }
        }
    }
}
