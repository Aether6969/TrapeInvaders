namespace TrapeInvaders
{
    internal class GameState
    {
        public int Score { get; set; }

        public List<(string, int)> Scores { get; } = new List<(string, int)>();



    }
}
