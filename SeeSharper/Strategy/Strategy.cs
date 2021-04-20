using System.Drawing;

namespace Strategy
{
	public abstract class Strategy
	{
		private Color _color;

		public abstract void Draw();
		public abstract void MouseClicked(int x, int y);
        public abstract void IsDone();

        public void ColorChanged(Color color)
        {
            _color = color;
        }

        public void MouseMoved(int x, int y)
        {

        }
    }
}