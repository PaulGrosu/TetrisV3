using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris2.Clases
{

    public class StareJoc
    {
        private Block ActualBlock;


        //block actual il folosim ca sa il luam pe Actual block , actual block este privat iar blockactualk este public cea ce il va face pe actualblock sa fie dispoinbio la toata lumea

        public Block BlockActual
        {
            get => ActualBlock;
            set
            {
                ActualBlock = value;
                ActualBlock.Reset();
            }

        }
        public Tabla Tabla { get; }
        public CoadaBlock CoadaBlock { get; }
        public bool GameOver { get; private set; }
        public int Punctaj { get; private set; } = 0;
        public StareJoc()
        {
            Tabla = new Tabla(22, 10);
            CoadaBlock = new CoadaBlock();
            BlockActual = CoadaBlock.ReturnSIUpdateBlock();
        }

        private bool BlockIlegal()
        {
            List<Pozitie> pozitie = BlockActual.PozitieTiles().ToList();
            foreach (Pozitie p in pozitie)
            {
                if (!Tabla.EGol(p.Rand, p.Coloana))
                {
                    return false;
                }
            }
            return true;
        }

        public void RotesteBlockCW()
        {
            BlockActual.RotesteCW();
            if (!BlockIlegal())
            {
                BlockActual.RotesteCCW();
            }
        }
        /*public void RotesteBlockCCW() // nu imi trebe sa se roteasca in ambele directii , pot sa scap de ea ( vreau sa rotesc doar de pe tasta arrow up)
        {
            BlockActual.RotesteCCW();
            if (!BlockIlegal())
            {
                BlockActual.RotesteCW();
            }

        }*/
        public void MiscaBlockStanga()
        {
            BlockActual.Move(0, -1);
            if (!BlockIlegal())
            {
                BlockActual.Move(0, 1);
            }
        }
        public void MiscaBlockDreapta()
        {
            BlockActual.Move(0, 1);
            if (!BlockIlegal())
            {
                BlockActual.Move(0, -1);
            }
        }
        public bool EGameOver()
        {
            return !(Tabla.ERandGol(3) && Tabla.ERandGol(4));
        }
        private void PuneBlock()  // pune block infige figura intr-un loc si face sa nu mai poata fi miscata
        {
            foreach (Pozitie p in BlockActual.PozitieTiles())
            {
                Tabla[p.Rand, p.Coloana] = BlockActual.Id;    // salveaza in grid id-ul blockului din care face parte tile-ul
            }
            Punctaj += Tabla.StergeTotRand();
            if (EGameOver())
            {
                GameOver = true;
            }
            else
            {
                BlockActual = CoadaBlock.ReturnSIUpdateBlock();
            }
        }
        public void MiscaBlockJos()
        {
            BlockActual.Move(1, 0); 
            if (!BlockIlegal())
            {
                BlockActual.Move(-1, 0);
                PuneBlock();
            }

        }
    }
}
