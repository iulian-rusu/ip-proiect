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
            
        }

        public override void MouseMoved(int x, int y)
        {
            
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            Tuple<Point, Point> points;
            Color color;
            points = new Tuple<Point, Point>(new Point(100, 100), new Point(300, 300));
            color = Color.Red;
            var graphics = e.Graphics;
            graphics.DrawLine(new Pen(color), points.Item1, points.Item2);
        }
    }

}