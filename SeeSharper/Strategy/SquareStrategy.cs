using System.Windows.Forms;
using System;
using System.Drawing;

namespace Strategy
{
    public class SquareStrategy : TwoPointStrategy
    {
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                int width = Math.Abs(_points[1].X - _points[0].X);
                int startX = Math.Min(_points[1].X, _points[0].X);
                int startY = Math.Min(_points[1].Y, _points[0].Y);
                var rect = new Rectangle(startX, startY, width, width);
                graphics.DrawRectangle(new Pen(_color), rect);
            }
        }
    }
}
