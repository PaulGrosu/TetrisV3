using System.Drawing;
using System;
using System.Security.Policy;
using System.Windows.Forms;
using Tetris2.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Tetris2
{
   
    public partial class Form1 : Form
    {
       // private Tabla instantaTabla;
        private Timer MyTimer;
        private StareJoc stareJoc;
        private PictureBox[,] Matrice = new PictureBox[20, 10];
        public Form1()
        {
            InitializeComponent();
            Initializator();
            InitTile();
            //InitGrid();
            // IniitializeTable();
            UpdateGrid();
            //SpawnBlock(); 
          //  instantaTabla = new Tabla(22,10);
        }


        private void InitTile()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matrice[i, j] = new PictureBox(); //matricea este componenta vizuala 
                    Matrice[i, j].Size = new Size(20, 20);

                    tableLayoutPanel.Controls.Add(Matrice[i, j]);
                }
            }
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matrice[i, j].SizeMode = PictureBoxSizeMode.Zoom; //strecth tileuri invizibile
                    Matrice[i, j].ImageLocation = ConverterImagineTile(stareJoc.Tabla[i, j]); // punea in coordonate imaginea luata de la tile-uri



                }

            }
            foreach (Pozitie pozitie in stareJoc.BlockActual.PozitieTiles())   // deseneaza blokul actual pe ecran ( blokul actual nu face parte din tabla pana cand nu iese din controlul userului)
            {
                Matrice[pozitie.Rand, pozitie.Coloana].SizeMode = PictureBoxSizeMode.Zoom;
                Matrice[pozitie.Rand, pozitie.Coloana].ImageLocation = ConverterImagineTile(stareJoc.BlockActual.Id);
            }


            TextPunctaj.Text = stareJoc.Punctaj.ToString();
            if (stareJoc.GameOver == true)
            {
                Over.Visible = true;
                MyTimer.Enabled = false;
            }
            NextBlock.ImageLocation = ConverterImagine(stareJoc.CoadaBlock.UrmatorulBlock.Id);


        }

        private void Initializator()
        {
            stareJoc = new StareJoc();
            MyTimer = new Timer();
            MyTimer.Interval = 500; // 45 mins
            MyTimer.Tick += new EventHandler(Timer_Tick);
            MyTimer.Start();
            NextBlock.ImageLocation = ConverterImagine(stareJoc.BlockActual.Id);
        }
        private string ConverterImagine(int Id)
        {
            if (Id == 1)
            {
                return "../../Assets/Block-I.jpg";
            }
            else if (Id == 2)
            {
                return "../../Assets/Block-J.jpg";
            }
            else if (Id == 3)
            {
                return "../../Assets/Block-L.jpg";

            }
            else if (Id == 4)
            {
                return "../../Assets/Block-Cub.jpg";
            }
            else if (Id == 5)
            {
                return "../../Assets/Block-S.jpg";

            }
            else if (Id == 6)
            {
                return "../../Assets/Block-T.jpg";
            }
            else
            {
                return "../../Assets/Block-Z.jpg";
            }

        }

        private string ConverterImagineTile(int Id)
        {
            if (Id == 1)
            {
                return "../../Assets/Tile-I.jpg";
            }
            else if (Id == 2)
            {
                return "../../Assets/Tile-J.jpg";
            }
            else if (Id == 3)
            {
                return "../../Assets/Tile-L.jpg";

            }
            else if (Id == 4)
            {
                return "../../Assets/Tile-Cub.jpg";
            }
            else if (Id == 5)
            {
                return "../../Assets/Tile-S.jpg";

            }
            else if (Id == 6)
            {
                return "../../Assets/Tile-T.jpg";
            }
            else if (Id == 7)
            {
                return "../../Assets/Tile-Z.jpg";
            }

            else
            { return "../../Assets/TileEmpty.png"; }

        }



        /*private void NextBlock_Click(object sender, EventArgs e)
        {
            stareJoc.BlockActual = new CoadaBlock().ReturnSIUpdateBlock();
            NextBlock.ImageLocation = ConverterImagine(stareJoc.BlockActual.Id);
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            stareJoc.MiscaBlockJos();
            UpdateGrid();

        }

        private void Form1_KeyLeft(object sender, KeyEventArgs e)
        {
            stareJoc.MiscaBlockStanga();
            UpdateGrid();
        }

        private void Form1_KeyRight(object sender, KeyEventArgs e)
        {
            stareJoc.MiscaBlockDreapta();
            UpdateGrid();
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            stareJoc.RotesteBlockCW();
            UpdateGrid();
        }

        private void Form1_KeyManager(object sender, KeyEventArgs e)
        {
           // var form = sender as Control;    debug test
            switch (e.KeyCode)     
            {
                case Keys.Down:
                    Form1_KeyDown(sender, e);
                    break;
                case Keys.Up:
                    Form1_KeyUp(sender, e);
                    break;
                case Keys.Left:
                    Form1_KeyLeft(sender, e);
                    break;
                case Keys.Right:
                    Form1_KeyRight(sender, e);
                    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Form1_KeyDown(sender, null);
            
       }

    }
}
