using System;
using System.ComponentModel;

namespace Tetris2.Clases


{
    public class Tabla
    {
        private int[,] grid { get; }
        private int Rand { get; }
        private int Coloana { get; }

        public int this[int r, int c]  //indexer ca sa dea acces usor la matrice
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public Tabla(int rand, int col)   //limitam tabla in functie de randuri si coloane
        {

            Rand = rand;
            Coloana = col;
            grid = new int[rand, col];
        }

        private bool EInauntru(int r, int c) //verifica daca coloanele si randurile sunt inauntru
        {

            return r >= 0 && r < Rand && c >= 0 && c < Coloana  && r < 20;
        }
        internal bool EGol(int r, int c) //verifica daca o celula este goala sau nu
        {
            return EInauntru(r, c) && grid[r, c] == 0;
        }
        private bool ERandPlin(int r)        //verifica daca randul e plin
        {
            for (int c = 0; c < Coloana; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        internal bool ERandGol(int r)     //verifica daca randul e gol
        {
            for (int c = 0; c < Coloana; c++)
            {
                if (grid[r, c] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void StergeRand(int r)  //sterge randu
        {
            for (int c = 0; c < Coloana; c++)
            {
                grid[r, c] = 0;
            }
        }
        private void MutaRandJos(int r, int x)  //pe x il folosesc ca sa stocheze cate randuri au fost sterse si cu ateatea sa mearga in jos
        {
            for (int c = 0; c < Coloana; c++)
            {
                grid[r + x, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        internal int StergeTotRand()
        {
            int Sters = 0;
            for (int r = Rand - 1; r >= 0; r--)
            {
                if (ERandPlin(r))
                {
                    StergeRand(r);
                    Sters++;
                }
                else if (Sters > 0)
                {
                    MutaRandJos(r, Sters);
                }

            }
            return Sters;
        }


    }
}