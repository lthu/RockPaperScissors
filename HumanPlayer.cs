namespace RockPaperScissors
{
     /// <summary>
     /// Class for human player
     /// </summary>
    public class HumanPlayer : Player
    {
        /// <summary>
        /// Constructor for human player
        /// </summary>
        /// <param name="n">Name of the player</param>
        public HumanPlayer(string n) : base(n) { }

        /// <summary>
        /// Method to ask user for their decision for current round. 
        /// </summary>
        /// <returns>Integer of user's choice for the round.</returns>
        public override int GetRoll() 
        {
            
            // Ask user for input (either Rock = 1 Paper = 2 or Scissors = 3)
            // Do some checks to verify input and return 1,2,3 if valid input (via PlayerDecision()) or 0 if 
            // input is not valid.
            Console.WriteLine($"{this.GetPlayerName()} please choose:");
            Console.WriteLine("(R)ock / (P)aper / (S)cissors");
            var temp = Console.ReadLine();
            if (temp != null) 
            {   
                var tempChar = char.ToUpper(temp[0]);
                if (tempChar.Equals('R'))
                    return PlayerDecision(1);
                if (tempChar.Equals('P'))
                    return PlayerDecision(2);
                if (tempChar.Equals('S'))
                    return PlayerDecision(3);
                
                // If we don't have either on of the thee (1,2,3) we ask user for input again.
                Console.WriteLine($"{this.GetPlayerName()} Invalid option.");
                GetRoll();
            }  

            // We should never return 0. Only if temp is actually null but we have a check for that in the Game.cs
            return 0;
            
        }
        /// <summary>
        /// Method to print out user's decision for the round.
        /// </summary>
        /// <param name="decision">Integer of user's choice for the round.</param>
        /// <returns></returns>
        private int PlayerDecision(int decision)
        {
            Console.WriteLine($"{this.GetPlayerName()} chose {(Choices)decision}");
            return decision;
        }
    }
}