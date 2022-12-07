namespace RockPaperScissors
{
    /// <summary>
    /// Class for computer player
    /// </summary>
    public class ComputerPlayer : Player
    {
        
        public ComputerPlayer(string n) : base(n) {}

        /// <summary>
        /// Method to randomize computer's decision
        /// </summary>
        /// <returns>Integer valued between 1 and 3</returns>
        public override int GetRoll()
        {
            Random rand = new Random();
            var player2Choice = Convert.ToInt32(rand.NextInt64(1, 4));
            
            System.Threading.Thread.Sleep(1000);
            return player2Choice;
        }
        
    }
    
}