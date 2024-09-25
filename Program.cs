namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The loop goes on as long as the player wants to play.
            bool play = true;
            while (play)
            {
                //Calling method "PlayGame".
                PlayGame();

                /* Checking to see whether the player wants to play again or not. A switch to 
                 * handle the answer. */
                Console.Write("\nVill du spela igen? j/n: ");
                string playAgain = Console.ReadLine().ToUpper();

                switch (playAgain)
                {
                    case "J":
                        Console.Clear();
                        break;
                    case "N":
                        Console.WriteLine("\nTack för den här gången!");
                        play = false;
                        break;
                    default:
                        Console.WriteLine("\nOkänt svarsalternativ. Programmet stängs ner.");
                        play = false;
                        break;
                }
            }
        }

        /*                   --------------PLAY GAME----------------
        This method gives the user five tries on guessing a random number. The user gets to choose 
        the maximun value. The program directs the users' guesses with 'too high' or 'too low' and 
        prints the number if the user runs out of guesses. */

        static void PlayGame()
        {
            Console.Write("Välkommen till NumbersGaaaaaaame!\n\nBörja med att välja hur svårt " +
                "spelet ska vara...\n\nDu får 5 försök att gissa ett tal mellan 1 och - ja vadå?: ");
            
            // Fetching the maximun value and safing up for a useful number.
            int difficulty;
            while (!int.TryParse(Console.ReadLine(), out difficulty))
            {
                Console.WriteLine("Det var ingen siffra. Försök igen!");
            }
            if (difficulty <= 0)
            {
                Console.WriteLine("Näää, det blir för könstigt att spela med den siffran. Nu blir " +
                    "det 20 istället!");
                difficulty = 20;
            }
            Console.WriteLine($"\nOK! En siffra mellan 1 och {difficulty} - here we gooooo!\n");

            // Initiating the random number.
            Random rnd = new Random();
            int rndNumber = rnd.Next(1, difficulty + 1);

            /* A for loop that compares the guess to the random number. Each wrong guess 
             * adds one to a counter. If the counter reaches 4 (5 guesses) the game ends. 
             * It is important to write the if/if else in a correct order!*/
            int guess;
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Det var ingen siffra. Försök igen!");
                }
                if (guess == rndNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\nWohoo! Du klarade det på {i + 1} försök!");
                    Console.ResetColor();
                    break;
                }
                else if (counter == 4)
                {
                    Console.WriteLine($"\nTyvärr lyckades du inte gissa talet på fem " +
                        $"försök. Talet var {rndNumber}.");
                }
                else if (guess == rndNumber + 1)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt. Men det bränns!");
                    counter++;
                }
                else if (guess > rndNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                    counter++;
                }
                else if (guess == rndNumber - 1)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt. Men det bränns!");
                    counter++;
                }
                else if (guess < rndNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                    counter++;
                }
            }
        }
    }
}
