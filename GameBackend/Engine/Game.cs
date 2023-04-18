using System.Text;
using System.Timers;
using TrapeInvaders;

namespace TrapeInvadersEngine
{
    public abstract class Game
    {
        public IInputManager InputManager { get; }
        public IRenderTarget RenderTarget { get; }

        Dictionary<int, IGameObj> _GameObjects;

        bool _Running = false;
        bool _Cancled = false;

        public Game(IInputManager inputManager, IRenderTarget renderTarget)
        {
            InputManager = inputManager;
            RenderTarget = renderTarget;

            _GameObjects = new Dictionary<int, IGameObj>();
        }

        public void Run()
        {
            _Running = true;

            while (!_Cancled)
            {
                for (int y = 0; y < RenderTarget.Height; y++)
                {
                    for (int x = 0; x < RenderTarget.Width; x++)
                    {
                        Vec2 point = new Vec2(x, y);

                        double dist = (point - new Vec2(25, 50)).Len;

                        Pixel pixel = new Pixel(0, 255, 0) * Math.Abs(Math.Cos(((dist)*0.2) + DateTime.Now.Ticks * -0.0000001));
                        RenderTarget[x, y] = pixel;
                    }
                }

                RenderTarget.Draw();
            }

            _Running = true;

            InizializeGameObjects();

            while (!_Cancled)
            {
                //Todo: have timings for draw and update

                UpdateGameObjects();

                DrawGameObjects();

                RenderTarget.Draw();
            }
        }
        public void Cancel() 
        {
            _Cancled = true;

            if (!_Running)
            {
                Log.Warn(new Exception("The game was cancled enven though it never started"));
            }
        }

        public void AddObject(IGameObj gameObj)
        {
            _GameObjects.Add(gameObj.Transform.Id, gameObj);
            gameObj.Inizialize();
        }

        private void InizializeGameObjects()
        {
            foreach (IGameObj gameObj in _GameObjects.Values)
            {
                gameObj.Inizialize();
            }
        }
        private void UpdateGameObjects()
        {
            foreach (IGameObj gameObj in _GameObjects.Values)
            {
                gameObj.Update();
            }
        }
        private void DrawGameObjects()
        {
            foreach (IGameObj gameObj in _GameObjects.Values)
            {
                gameObj.Draw();
            }
        }
    }
}
