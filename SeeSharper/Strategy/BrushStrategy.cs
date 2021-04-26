/**************************************************************************
 *                                                                        *
 *  File:        BrushStrategy.cs                                         *
 *  Copyright:   (c) 2021, Nistor Paula-Alina                             *
 *  E-mail:      paula-alina.nistor@student.tuiasi.ro                     *
 *  Description:                                                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class BrushStrategy : MultiplePointStrategy
    {
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
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                foreach (var point in _points)
                {
                    var p = new Point(point.X + 10, point.Y + 10);
                    graphics.DrawLine(new Pen(_color), point, p);
                }

            }
        }
    }
}
