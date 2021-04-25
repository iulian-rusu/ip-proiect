using System;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class LineStrategy : TwoPointStrategy
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
            if( _points == null)
            {
                _points = new Point[2];
                _points[0].X = _points[1].X = x;
                _points[0].Y = _points[1].Y = y;
            }
            else
            {
                _done = true;
            }
            
        }

        public override void MouseMoved(int x, int y)
        {
            if (_points != null && ! _done)
            {
                _points[1].X = x;
                _points[1].Y = y;
            }

        }
        private void Draw(object sender, PaintEventArgs e)
        {
      if (_points != null)
      {
        var graphics = e.Graphics;
        graphics.DrawLine(new Pen(_color), _points[0], _points[1]);
      }
        }
    }

}