using System.Numerics;
using System.Runtime.CompilerServices;

namespace GameEngine
{
    public abstract class Game
    {
        public IInputManager InputManager { get; }
        public IRenderTarget RenderTarget { get; }

        public long FramesFromStart { get; private set; } = 0;
        public double TicksPerSecond { get; set; } = 30;

        List<GameObj> Inserts = new List<GameObj>();
        Dictionary<int, GameObj> _GameObjects = new Dictionary<int, GameObj>();

        bool _Running = false;
        bool _Cancled = false;

        public Game(IInputManager inputManager, IRenderTarget renderTarget)
        {
            this.InputManager = inputManager;
            this.RenderTarget = renderTarget;
        }

        public void Run()
        {
            while (true)
            {
                for (int x = 0; x < RenderTarget.Size.x; x++)
                {
                    for (int y = 0; y < RenderTarget.Size.y; y++)
                    {
                        double timemod = (Environment.TickCount64 / (double)TimeSpan.TicksPerSecond) * 100000;

                        double len = (new Vec2(x, y) - new Vec2(25, 50)).Mag;

                        RenderTarget[x, y] = 
                            new Pixel(255, 0, 0) * (Math.Abs(Math.Cos((len + timemod) * 1d))) +
                            new Pixel(0, 0, 255) * (Math.Abs(Math.Cos((len + -timemod) * 1d)));
                    }
                }

                RenderTarget.Draw();
            }

            _Running = true;

            InizializeGameObjects();

            long lastUpdate = Environment.TickCount64;
            bool elasped = true; // true if the first frame sould be emidiatly run
            while (!_Cancled)
            {
                long lastFrameTimeDifMs = (Environment.TickCount64 - lastUpdate);

                double TPMS = 1000 / TicksPerSecond;

                if (lastFrameTimeDifMs > TPMS)
                {
                    elasped = true;
                    lastUpdate = Environment.TickCount64;
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
            FramesFromStart++;

            RenderTarget.Clear(Pixel.None);

            AddInserts();

            UpdateGameObjects();

            DrawGameObjects();

            RenderTarget.Draw();
        }

        private void AddInserts()
        {
            for (int i = 0; i < Inserts.Count; i++)
            {
                _GameObjects.Add(Inserts[i].Transform.Id, Inserts[i]);
            }
            Inserts.Clear();
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

        /// <summary>
        /// Runs the inizialize on the gameObj and adds it to the game next frame
        /// </summary>
        /// <param name="gameObj"></param>
        public void Instantiate(GameObj gameObj)
        {
            Inserts.Add(gameObj);
            gameObj.Inizialize();
        }
        /// <summary>
        /// Removes a gameObj from the game emidiatly
        /// </summary>
        /// <param name="gameObj"></param>
        public void RemoveObject(GameObj gameObj)
        {
            _GameObjects.Remove(gameObj.Transform.Id);
        }
        public void ClearScene()
        {
            _GameObjects.Clear();
        }

        public IEnumerable<GameObj> OverLaps(GameObj gameObj)
        {
            foreach (GameObj obj in _GameObjects.Values)
            {
                if (GameObj.Overlaps(gameObj, obj))
                {
                    yield return obj;
                }
            }
        }

        public bool OnecePerFrames(int numFrams)
        {
            return FramesFromStart % numFrams == numFrams - 1;
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
