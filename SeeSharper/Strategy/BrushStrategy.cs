using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class BrushStrategy : MultiplePointStrategy
    {
    public override PaintEventHandler GetDraw()
    {
      return new PaintEventHandler(Draw);
    }

    public override void IsDone()
    {
      throw new System.NotImplementedException();
    }

    public override void MouseClicked(int x, int y)
    {
      if (_points == null)
      {
        _points = new List<Point>();
        _points.Add(new Point(x, y));
      }
      else
      {
        _done = true;
      }

    }

    public override void MouseMoved(int x, int y)
    {
      if (_points != null && !_done)
      {
        _points.Add(new Point(x, y));
      }

    }
    private void Draw(object sender, PaintEventArgs e)
    {
      if (_points != null)
      {
        var graphics = e.Graphics;
        foreach (var point in _points) {
          var p = new Point(point.X, point.Y);
          graphics.DrawLine(new Pen(_color), point, p);
        }
        
      }
    }
  }
}

