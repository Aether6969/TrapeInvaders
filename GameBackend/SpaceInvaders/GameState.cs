namespace TrapeInvaders
{
    public class GameState
    {
        public int Score { get; set; }
        public int Health { get; set; }

        public List<(string, int)> Scores { get; } = new List<(string, int)>();
    }
}
