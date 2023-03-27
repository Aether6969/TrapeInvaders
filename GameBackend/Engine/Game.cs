using System.Timers;

namespace GameBackend
{
    public abstract class Game
    {
        IInputManager _InputManager;
        IRenderTarget _RenderTarget;

        public Game(IInputManager inputManager, IRenderTarget renderTarget)
        {
            _InputManager = inputManager;
            _RenderTarget = renderTarget;
        }

        public void Run()
        {

            while (true)
            {
                for (int x = 0; x < 50; x++)
                {
                    for (int y = 0; y < 100; y++)
                    {
                        Pixel pixel = new Pixel(0, 255, 0) * (x/50d);
                        _RenderTarget[x, y] = pixel;
                    }
                }
                _RenderTarget.Draw();
            }
        }

        private void Update()
        {

        }
    }
}
