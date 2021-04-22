using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
  /* Exemplu de implementare al functiilor legate de desen
  class Strat
  {
    private Tuple<Point, Point> points;
    Color color;
    public Strat()
    {
      points = new Tuple<Point, Point>(new Point(100, 100), new Point(300, 300));
      color = Color.Red;
    }
    private void Draw(object sender, PaintEventArgs e)
    {
      var graphics = e.Graphics;
      graphics.DrawLine(new Pen(color), points.Item1, points.Item2);
    }
    public PaintEventHandler GetDraw()
    {
      return new PaintEventHandler(Draw);
    }
  }
   */
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