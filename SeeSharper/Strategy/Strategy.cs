using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public abstract class Strategy
    {
        protected Color _color;
        protected bool _done = false;

        public bool Done
        {
            get { return _done; }
        }

        public void ColorChanged(Color color)
        {
            _color = color;
        }

        public PaintEventHandler GetDraw()
        {
            return new PaintEventHandler(Draw);
        }

        public abstract void MouseClicked(int x, int y);
        public abstract void MouseMoved(int x, int y);
        public abstract void Reset();
        protected abstract void Draw(object sender, PaintEventArgs e);
    }
}