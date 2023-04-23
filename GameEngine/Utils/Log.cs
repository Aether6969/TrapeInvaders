namespace GameEngine
{
    public static class Log
    {
        private enum Platform
        {
            None = 0,
            RasPi = 1,
            WinF = 2,
            Other = 3,
        }
        private static Platform _Platform;

        private static string _WinPath = Path.Combine(Environment.CurrentDirectory, "Log.txt");
        public static string WinPath => _Platform != Platform.RasPi ?
            _WinPath :
            throw new InvalidOperationException($"Expected platform to not be Unix recived {_Platform}");

        static Log()
        {
            _Platform = Environment.OSVersion.Platform switch
            {
                PlatformID.Unix => Platform.RasPi,
                PlatformID.Win32NT => Platform.WinF,
                PlatformID.Other => Platform.Other,
                _ => Platform.None,
            };
        }

        private static Exception? TryPLWinF(string message)
        {
            try
            {
                File.AppendAllText(WinPath, $"{message}{Environment.NewLine}");
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        public static void Msg(string message)
        {
            if (_Platform == Platform.RasPi)
            {
                Console.WriteLine(message);
            }
            else
            {
                Exception? exception = TryPLWinF(message);

                if (exception != null) throw exception;
            }
        }
        public static void Warn(Exception e)
        {
            if (_Platform == Platform.RasPi)
            {
                Console.WriteLine(e.ToString());
            }
            else
            {
                Exception? exception = TryPLWinF(e.ToString());

                if (exception != null) throw exception;
            }
        }
        public static void Exception(Exception e)
        {
            if (_Platform == Platform.RasPi)
            {
                Console.WriteLine(e.ToString());
            }
            else
            {
                Exception? exception = TryPLWinF(e.ToString());

                if (exception != null) throw exception;

                throw e;
            }
        }
    }
}
