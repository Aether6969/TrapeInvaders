namespace GameEngine
{
    public abstract class Game
    {
        public IInputManager InputManager { get; }
        public IRenderTarget RenderTarget { get; }

        public long FramesFromStart { get; private set; } = 0;
        public double TicksPerSecond { get; set; } = 30;

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
            //while (true)
            //{
            //    for (int x = 0; x < RenderTarget.Size.x; x++)
            //    {
            //        for (int y = 0; y < RenderTarget.Size.y; y++)
            //        {
            //            double timeMod = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) * 0.01;

            //            double dist = (new Vec2(x, y) - new Vec2(25, 50)).Len;

            //            Pixel pix = 
            //                new Pixel(255, 0, 0) * (Math.Abs(Math.Cos((dist + timeMod) * 0.2d))) +
            //                new Pixel(0, 0, 255) * (Math.Abs(Math.Sin((dist + timeMod) * 0.2d)));

            //            RenderTarget[x, y] = pix;
            //        }
            //    }

            //    RenderTarget.Draw();
            //}


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
        public void RemoveObject(GameObj gameObj)
        {
            _GameObjects.Remove(gameObj.Transform.Id);
        }
        public void ClearScene()
        {
            _GameObjects.Clear();
        }

        public List<GameObj> OverLaps(GameObj gameObj)
        {
            List<GameObj> overlaping = new List<GameObj>();
            foreach (GameObj obj in _GameObjects.Values)
            {
                if (GameObj.Overlaps(gameObj, obj))
                {
                    overlaping.Add(obj);
                }
            }
            return overlaping; 
        }

        public bool OnecePerFrames(int numFrams)
        {
            return FramesFromStart % numFrams == numFrams - 1 ? true : false;
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
