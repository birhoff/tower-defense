using System;
using System.Windows.Forms;
using TowerDefense.Engine;
using Game = TowerDefense.TDGame.TDGame;

namespace TowerDefense
{
    public partial class Form1 : Form
    {
        private GameLoop _mainGameLoop;
        private Game _myGame;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _myGame = new Game();
            _mainGameLoop = new GameLoop(_myGame, this.pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainGameLoop.Start();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _mainGameLoop.Game.Device.Input.Mouse.IsMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mainGameLoop.Game.Device.Input.Mouse.IsMouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _mainGameLoop.Game.Device.Input.Mouse.Position = e.Location;
        }
    }
}
