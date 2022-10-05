namespace Snake
{
    public partial class Form1 : Form
    {
        Game Game;

        public Form1()
        {
            InitializeComponent();
            Game = new Game(ref Time, ref Lbpontua��o, ref PnTela);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iniciarJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.StartGame();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Game.Tick();
        }

        private void CLicado(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                Game.Arrow = e.KeyCode;
         
        }
    }
}