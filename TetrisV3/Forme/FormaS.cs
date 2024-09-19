using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris2.Clases
{
    public class FormaS : Block
    {
     /*   public readonly Pozitie[][] tiles = new Pozitie[][]
            {
                new Pozitie[]{ new Pozitie(1,0),new Pozitie(1,1),new Pozitie(0,1), new Pozitie(0,2)},
                new Pozitie[]{ new Pozitie(0,1),new Pozitie(1,1), new Pozitie(1,2),new Pozitie(2,2)},
                new Pozitie[]{new Pozitie(2,0),new Pozitie(2,1), new Pozitie(1,1),new Pozitie(1,2)},
                new Pozitie[]{new Pozitie(0,0),new Pozitie(1,0),new Pozitie(1,1),new Pozitie(2,1)}
            };*/
        public override int Id => 5;
        protected override Pozitie StartOffset => new Pozitie(0, 3);
        protected override Pozitie[][] Tiles { get; } = new Pozitie[][]
        {

                new Pozitie[]{ new Pozitie(1,0),new Pozitie(1,1),new Pozitie(0,1), new Pozitie(0,2)},
                new Pozitie[]{ new Pozitie(0,1),new Pozitie(1,1), new Pozitie(1,2),new Pozitie(2,2)},
                new Pozitie[]{new Pozitie(2,0),new Pozitie(2,1), new Pozitie(1,1),new Pozitie(1,2)},
                new Pozitie[]{new Pozitie(0,0),new Pozitie(1,0),new Pozitie(1,1),new Pozitie(2,1)}

        };

    }
}
