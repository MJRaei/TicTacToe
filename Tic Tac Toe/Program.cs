﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();


            while (!game.GameFinisher)
            {
                game.BoardGameTable();
                game.GetEntry();

            }
            game.BoardGameTable();
        }
    }

}

