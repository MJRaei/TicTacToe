using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Game
    {
        public Game() 
        {
            BoardGame = new string[,]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" },
            };
            UserTurn = "O";
            TurnCounter = 10;
            GameFinisher = false;
        }
        private int UserEntry { get; set; }
        public string[,] BoardGame { get; private set; }
        public string UserTurn { get; private set; }
        private int TurnCounter { get; set; }
        public bool GameFinisher { get; private set; }

        public void BoardGameTable()
        {

            Console.WriteLine();
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", BoardGame[0, 0], BoardGame[0, 1], BoardGame[0, 2]);
            Console.WriteLine(" ---   ---   ---");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", BoardGame[1, 0], BoardGame[1, 1], BoardGame[1, 2]);
            Console.WriteLine(" ---   ---   ---");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", BoardGame[2, 0], BoardGame[2, 1], BoardGame[2, 2]);

        }

        public void GetEntry()
        {
            Console.WriteLine("Enter the position: ");
            string input = Console.ReadLine();
            Console.Clear();
            try 
            {
                UserEntry = int.Parse(input);
                TurnIden();
                BoardGameChange();
                CheckWinner(UserTurn);
            } 
            catch 
            {
                Console.WriteLine("Warning: Please enter a number");
            }

            if (UserEntry < 1 || UserEntry > 9) 
            {
                Console.WriteLine("Warning: Please Enter a number between 1 and 9");
                TurnCounter -= 1;
            }

        }

        public void TurnIden()
        {
            UserTurn = TurnCounter % 2 == 0 ? "O" : "X";
        }

        public void CheckEntry(int i, int j, string position)
        {
            if (BoardGame[i, j] == position)
                BoardGame[i, j] = UserTurn;
            else
            {
                TurnCounter -= 1;
                Console.WriteLine("Already taken by {0}! Please try another position.", BoardGame[i, j]);
            }
        }


        public void BoardGameChange()
        {
            switch (UserEntry)
            {
                case 1: CheckEntry(0, 0, "1"); break;
                case 2: CheckEntry(0, 1, "2"); break;
                case 3: CheckEntry(0, 2, "3"); break;
                case 4: CheckEntry(1, 0, "4"); break;
                case 5: CheckEntry(1, 1, "5"); break;
                case 6: CheckEntry(1, 2, "6"); break;
                case 7: CheckEntry(2, 0, "7"); break;
                case 8: CheckEntry(2, 1, "8"); break;
                case 9: CheckEntry(2, 2, "9"); break;
            }
            TurnCounter += 1;
        }

        public void CheckWinner(string userTurn)
        {
            if (Enumerable.Range(0, 3).Any(i => BoardGame[i, 0] == userTurn && BoardGame[i, 1] == userTurn && BoardGame[i, 2] == userTurn) ||
                Enumerable.Range(0, 3).Any(i => BoardGame[0, i] == userTurn && BoardGame[1, i] == userTurn && BoardGame[2, i] == userTurn))
            {
                Console.WriteLine("{0} is the winner", userTurn);
                GameFinisher = true;
            }

            if ((BoardGame[0, 0] == userTurn && BoardGame[1, 1] == userTurn && BoardGame[2, 2] == userTurn) || 
                (BoardGame[0, 2] == userTurn && BoardGame[1, 1] == userTurn && BoardGame[2, 0] == userTurn))
            {
                Console.WriteLine("{0} is the Winner", userTurn);
                GameFinisher = true;

            }
        }

    }
}
