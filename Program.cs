namespace RockPaperScissors {

    /// <summary>
    /// Test
    /// </summary>
    class Program 
    {

        static void Main()
        {

            // We can make to computer players play eachother or have user play against computer 
            // (or have two human player face eachother as well)
            // -> just uncomment line below
            //
            // ComputerPlayer p1 = new ComputerPlayer("PC");
            HumanPlayer p1 = new HumanPlayer("Seppo");
            ComputerPlayer p2 = new ComputerPlayer("AI");


            // We also can initiate the game with amount of round wins it takes to win the whole game
            Game rps = new Game(p1, p2, 4);
            rps.Intro();
            rps.StartTheGame();
            

            
            
        }
    }
}