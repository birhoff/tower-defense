using System.Drawing;
using System.Windows.Forms;

namespace TowerDefense.Engine
{
    public class Device
    {
        private readonly PictureBox _pictureBox;
        private readonly Graphics _graphics;
        private readonly Input _input;

        public Device(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _graphics = _pictureBox.CreateGraphics();
            _input = new Input();
        }

        public Size ClientSize
        {
            get { return new Size(_pictureBox.Width - 1, _pictureBox.Height - 1); }
        }

        public Graphics Graphics
        {
            get { return _graphics; }
        }

        public Input Input
        {
            get { return _input; }
        }
    }
}