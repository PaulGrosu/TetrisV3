using System;

namespace Tetris2.Clases
{
    public class Pozitie
    {
        public int Rand { get; set; }
        public int Coloana { get; set; }
        public Pozitie(int rand, int col)
        {
            Rand = rand;
            Coloana = col;
        }


    }
}