using System;
using System.Timers;
using TrapeInvaders;

namespace TrapeInvaders
{
    public abstract class Game
    {
        public IInputManager InputManager { get; }
        public IRenderTarget RenderTarget { get; }

        Dictionary<int, GameObj> _GameObjects;

        bool _Running = false;
        bool _Cancled = false;

        public Game(IInputManager inputManager, IRenderTarget renderTarget)
        {
            InputManager = inputManager;
            RenderTarget = renderTarget;

            _GameObjects = new Dictionary<int, GameObj>();
        }

        public void Run()
        {
            _Running = true;

            InizializeGameObjects();

            const double TPS = 10;
            long lastUpdate = DateTime.Now.Ticks;
            bool elasped = false;
            while (!_Cancled)
            {
                if ((DateTime.Now.Ticks - lastUpdate) / TimeSpan.TicksPerMillisecond > 1000 / TPS)
                {
                    elasped = true;
                    lastUpdate = DateTime.Now.Ticks;
                }
                if (elasped)
                {
                    elasped = false;
                    UpdateGame();
                }
            }
        }

        private void UpdateGame()
        {
            RenderTarget.Clear(Pixel.None);

            UpdateGameObjects();

            DrawGameObjects();

            RenderTarget.Draw();
        }

        public void Cancel() 
        {
            _Cancled = true;

            if (!_Running)
            {
                Log.Warn(new Exception("The game was cancled even though it never started"));
            }
        }

        public void AddObjectToScene(GameObj gameObj)
        {
            _GameObjects.Add(gameObj.Transform.Id, gameObj);
        }
        public void Instantiate(GameObj gameObj)
        {
            AddObjectToScene(gameObj);
            gameObj.Inizialize();
        }

        private void InizializeGameObjects()
        {
            foreach (GameObj gameObj in _GameObjects.Values)
            {
                gameObj.Inizialize();
            }
        }
        private void UpdateGameObjects()
        {
            foreach (GameObj gameObj in _GameObjects.Values)
            {
                gameObj.Update();
            }
        }
        private void DrawGameObjects()
        {
            foreach (GameObj gameObj in _GameObjects.Values)
            {
                gameObj.Draw();
            }
        }
    }
}
