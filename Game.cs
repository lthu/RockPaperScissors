namespace RockPaperScissors
{
    /// <summary>
    /// Game class where the game logic happens.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Player 1
        /// </summary>
        protected Player p1;
        /// <summary>
        /// Player 2
        /// </summary>
        protected Player p2;
        /// <summary>
        /// Player 1's choice for the round.
        /// </summary>
        private int _player1Choice;
        /// <summary>
        /// Player 2's choice for the round.
        /// </summary>
        private int _player2Choice;
        /// <summary>
        /// Player 1's total score.
        /// </summary>
        private int _player1Score;
        /// <summary>
        /// Player 2's total score.
        /// </summary>
        private int _player2Score;
        /// <summary>
        /// True if game is still running.
        /// </summary>
        private bool _isOn;
        /// <summary>
        /// Number of the current round.
        /// </summary>
        private int _roundNumber = 1;
        /// <summary>
        /// Number of rounds needed to win the game.
        /// </summary>
        private int _roundsToWin;

        /// <summary>
        /// Constructor for the game with custom round amount.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="rounds">Number of rounds needed to win the game.</param>
        public Game(Player player1, Player player2, int rounds)
        {
            this.p1 = player1;
            this.p2 = player2;
            this._roundsToWin = rounds;
        }
        /// <summary>
        /// Constructor for the game with default round amount.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        public Game(Player player1, Player player2)
        {
            this.p1 = player1;
            this.p2 = player2;
            this._roundsToWin = 3;
        }
        /// <summary>
        /// "Intro" looping before the game begins.
        /// </summary>
        public void Intro()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("|      Rock-Paper-Scissors       |");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("|     Player1       Player2      |");
                Console.WriteLine($"|      {p1.GetPlayerName()}   vs.    {p2.GetPlayerName()}         |");
                Console.WriteLine("----------------------------------");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine("++++++++++++++++++++++++++++++++++");
                Console.WriteLine("+      Rock-Paper-Scissors       +");
                Console.WriteLine("+--------------------------------+");
                Console.WriteLine("+     Player1       Player2      +");
                Console.WriteLine($"+      {p1.GetPlayerName()}   vs.    {p2.GetPlayerName()}         +");
                Console.WriteLine("++++++++++++++++++++++++++++++++++");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
        }

        private void PlayOneRound()
        {
            _player1Choice = p1.GetRoll();
            _player2Choice = p2.GetRoll();

            // This check is not perfect and maybe not even necessary?
            // getRoll() should never return a 0 but if it does we ask for input again.
            if (_player1Choice == 0 || _player2Choice == 0) {
                Console.WriteLine("Invalid option");
                PlayOneRound();
            } else
            {
                // Print out the basic information and call the CheckWinner()
                Console.WriteLine($"#{_roundNumber} {(Choices)_player1Choice} vs {(Choices)_player2Choice}");
                CheckWinner();
                Console.WriteLine($"The score is: {p1.GetPlayerName()} [{this._player1Score}] | {p2.GetPlayerName()} [{this._player2Score}] ");
                this._roundNumber++;
            }

        }
        private void CheckWinner()
        {   // Basic checks to see who wins. First we check for tie and then match each player 1 decision
            // against each p2 decision that would make player 1 win. 
            if (this._player1Choice == this._player2Choice)
            {
                Console.WriteLine("It's a tie!");
            } else if ((this._player1Choice == 1 && this._player2Choice == 2) ||
                       (this._player1Choice == 2 && this._player2Choice == 3) ||
                       (this._player1Choice == 3 && this._player2Choice == 1))
            {
                Console.WriteLine($"{p2.GetPlayerName()} wins the round!");
                _player2Score++;
            } else 
            {
                Console.WriteLine($"{p1.GetPlayerName()} wins the round!");
                _player1Score++;
            }
            // Last we check if either player has reached the roundsToWin to win the whole game.
            if (_player1Score == this._roundsToWin || _player2Score == this._roundsToWin)
            {
                var winner = _player1Score == this._roundsToWin ? p1.GetPlayerName() : p2.GetPlayerName();
                Console.WriteLine("Game is over and the winner is " + winner);
                this._isOn = false;
            }
        }
        /// <summary>
        /// Method to start the game. After each round _ison is checked.
        /// </summary>
        public void StartTheGame()
        {
            // Start the game and loop PlayOneRound() until _isOn == false
            this._isOn = true;

            while (GameIsRunning())
            { 
                PlayOneRound();
            }
        }
        /// <summary>
        /// Method to return value of _isOn.
        /// </summary>
        /// <returns>_isOn boolean</returns>
        public bool GameIsRunning()
        {
            return _isOn;
        }
    }
    
}