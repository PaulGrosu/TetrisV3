namespace Tetris2.Clases
{
    public class FormaPatrat : Block
    {
        /*private readonly Pozitie[][] tiles = new Pozitie[][]
        {
            new Pozitie[]{ new Pozitie(0,0) , new Pozitie(0,1),new Pozitie(1,0),new Pozitie(1,1)}
        };*/
        public override int Id => 4;
        protected override Pozitie StartOffset => new Pozitie(0, 4);
        protected override Pozitie[][] Tiles { get; } = new Pozitie[][]
        {
        new Pozitie[]{ new Pozitie(0,0) , new Pozitie(0,1),new Pozitie(1,0),new Pozitie(1,1)}
        };

    }
}
