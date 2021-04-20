using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
	public abstract class Strategy
	{
		private Color _color;

    private void Draw(object sender, PaintEventArgs e)
    {
      // implement in subclasses and delete from this
    }
    public PaintEventHandler GetDraw()
    {
      return new PaintEventHandler(Draw);
      // implement in subclasses and make abstract
    }
		public abstract void MouseClicked(int x, int y);
    public abstract void IsDone();

    public void ColorChanged(Color color)
    {
        _color = color;
    }

    public void MouseMoved(int x, int y)
    {
      // implement in subclasses and make abstract
    }
  }
}