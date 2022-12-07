namespace RockPaperScissors
{
    /// <summary>
    /// Abstract class for players.
    /// </summary>
    public abstract class Player
    {
        public string Name { get; set; }

        public Player(string n)
        {
            Name = "NoName";
            if (n.Length > 0)
                Name = n;
        }
        public Player()
        {
            Name = "Noname";
        }
        public abstract int GetRoll();

        public string GetPlayerName()
        {
            return Name;
        }
    }
}