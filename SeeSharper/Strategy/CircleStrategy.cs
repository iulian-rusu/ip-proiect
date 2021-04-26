using System;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class CircleStrategy : TwoPointStrategy
    {
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                int sideLength = Math.Abs(_points[0].X - _points[1].X);
                graphics.DrawEllipse(new Pen(_color), _points[0].X, _points[0].Y, sideLength, sideLength);
            }
        }
    }
}
