using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Snake
{
    internal class Game
    {
        public Keys Direction { get; set; }
        public Keys Arrow { get; set; }
        private Timer Time { get; set; }
        private Label Lbpontuação { get; set; }
        private Panel PnTela { get; set; }
        private int pontos = 0;
        private Food Food;
        private Snake Snake;
        private Bitmap offScreenBitmap;
        private Graphics bitmapGraph;
        private Graphics screenGraph;

        public Game(ref Timer timer, ref Label label, ref Panel panel)
        {
            PnTela = panel;
            Time = timer;
            Lbpontuação = label;
            offScreenBitmap = new Bitmap(428, 428);
            Snake = new Snake();
            Food = new Food();
            Direction = Keys.Left;
            Arrow = Direction;
        }
        public void StartGame() {
            Snake.Reset();
            Food.Createfood();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            Time.Enabled = true;
        }
        public void Tick()
        {
            if(((Arrow == Keys.Left) && (Direction != Keys.Right)) || ((Arrow == Keys.Right) && (Direction != Keys.Left)) || ((Arrow == Keys.Up) && (Direction != Keys.Down)) || ((Arrow == Keys.Down) && (Direction != Keys.Up)))
            {
                Direction = Arrow;
            }
               
            
                
            
            switch (Direction)
            {
                case Keys.Left:
                    Snake.Left();
                    break;
                case Keys.Right:
                    Snake.Right();
                    break;
                case Keys.Up:
                    Snake.Up();
                    break;
                case Keys.Down:
                    Snake.Down();
                    break;
            }
            bitmapGraph.Clear(Color.White);
            bitmapGraph.DrawImage(Properties.Resources.download,(Food.location.X * 15), (Food.location.Y * 15),15,15);
            bool gameover = false;

            for (int i = 0; i < Snake.Length; i++)
            {
                if(i== 0)
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#000000")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);
                }
                else
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4F4F4F")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);
                }
                if ((Snake.Location[i] == Snake.Location[0]) && (i > 0))
                {
                    gameover = true;
                }
            }
            screenGraph.DrawImage(offScreenBitmap, 0, 0); 

            CheckCollision();
            if (gameover)
            {
                GameOver();
            }
        }
        public void CheckCollision()
        {
        if (Snake.Location[0] == Food.location)
            {
                Snake.Eat();
                Food.Createfood();
                pontos += 9;
                Lbpontuação.Text = "PONTOS:" + pontos;
            }
        }

        public void GameOver()
        {
        Time.Enabled = false;
            bitmapGraph.Dispose(); 
            screenGraph.Dispose();
            Lbpontuação.Text = "PONTOS:";
            MessageBox.Show("Game Over");
        }
    }
}
