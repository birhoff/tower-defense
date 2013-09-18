using System.Drawing;

namespace TowerDefense.Engine.UI
{
    public class Button : Control
    {
        private Size _buttonSize = new Size(100, 30);

        public string Text;

        public Button(string text, Point position)
        {
            Position = position;
            Text = text;
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

        }
    }
}
