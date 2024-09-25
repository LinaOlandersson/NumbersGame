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
                /* Declaring the needed variables for the method and producing
                 * a random number.*/

                Random rnd = new Random();
                int rndNumber = rnd.Next(1, 21);

                //Calling method "PlayGame".
                PlayGame(rndNumber);

                /* Checking to see whether the player wants to play again or not. A switch to 
                 * handle the answer. */
                Console.WriteLine("\nVill du spela igen? j/n:");
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
        This method gives the user five tries on guessing a random number. The program directs
        the user with 'too high' or 'too low' ands prints the number if the user runs out of
        guesses. */

        static void PlayGame(int rndNumber)
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. " +
                "Kan du gissa vilket? Du får fem försök.");
            int guess;
            int counter = 0;

            /* A for loop that compares the guess to the random number. Each wrong guess 
             * adds one to a counter. If the counter reaches 4 (5 guesses) the game ends. */
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
