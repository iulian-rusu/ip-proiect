using System;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class LineStrategy : TwoPointStrategy
    {
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                graphics.DrawLine(new Pen(_color), _points[0], _points[1]);
            }
        }
    }

}