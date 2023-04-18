using System.Diagnostics;

namespace TrapeInvadersEngine
{
    internal static class Assert
    {
        [Conditional("DEBUG")]
        public static void True(bool contract)
        {
            if (!contract)
            {
                throw new Exception();
            }
        }
        [Conditional("DEBUG")]
        public static void False(bool contract)
        {
            if (contract)
            {
                throw new Exception();
            }
        }

        [Conditional("DEBUG")]
        public static void Positive(Vec2 val)
        {
            if (val.x < 0 || val.y < 0)
            {
                throw new Exception();
            }
        }
        [Conditional("DEBUG")]
        public static void Positive(int val)
        {
            if (val < 0)
            {
                throw new Exception();
            }
        }

        [Conditional("DEBUG")]
        public static void NotNull(object? obj)
        {
            if (obj is null)
            {
                throw new Exception();
            }
        }
    }
}
