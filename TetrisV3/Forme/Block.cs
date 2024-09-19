using System.Collections.Generic;

namespace Tetris2.Clases
{
    public abstract class Block
    {
        protected abstract Pozitie[][] Tiles { get; }  //matrice care contine pozitiile tile-urilor 
        protected abstract Pozitie StartOffset { get; } //offset care decide unde apare blokul in grid
        public abstract int Id { get; } // id pentru a diferentia blokurile

        private int StareRotire; // stokare la rotirea curenta 
        private Pozitie offset;  //stokare la offsetul curent 
        public Block()
        {
            offset = new Pozitie(StartOffset.Rand, StartOffset.Coloana); // setam offsetul sa primeasca valoarea lui StartOffset
        }
        public IEnumerable<Pozitie> PozitieTiles()            //IEnumerable il folosim ca sa putem folosi yield return                                       
        {
            foreach (Pozitie p in Tiles[StareRotire])         //pentru fiecare pozitie p din Tiles 
            {
                yield return new Pozitie(p.Rand + offset.Rand, p.Coloana + offset.Coloana);      // returneaza valoarea si continua executia
            }

        }
        public void RotesteCW()                                         //roteste blokul in sensul ceasului
        {
            if (StareRotire == 0)                                       //daca starea de rotire stokata este 0
            {
                StareRotire = Tiles.Length - 1;                        //cand o sa se scada din 0 valoarea se va transfomra in 3 
                
            }
            else
            {
                StareRotire--;                                         //decrementeaza starea rotire
            }
        }
        public void RotesteCCW()                          //roteste blokul in sensul opus ceasului
        {
            if (StareRotire == 3)       // incepe de la pozitia 3 si dupa ce face ++ o sa o ia de la inceput (de la 0) creind un loop
            {
                StareRotire = 0;       //stare rotire este 0

            }
            else
            {
                StareRotire++;         // incrementare stare rotire
            }
        }
        public void Move(int rand, int col)            //misca blokul
        {
            offset.Rand += rand;                     //offset rand se va aduna cu rand apoi va primi valoarea data
            offset.Coloana += col;                   //offset coloana se va aduna cu rand apoi va primi valoarea data
        }
        public void Reset()
        {
            StareRotire = 0;                             // setare StaRerotire la momentul initial
            offset.Rand = StartOffset.Rand;              //setare StareRotire.rand la momentul initial
            offset.Coloana = StartOffset.Coloana;        //setare StareRotire.coloana la meomentul initial
        }


    }
}
