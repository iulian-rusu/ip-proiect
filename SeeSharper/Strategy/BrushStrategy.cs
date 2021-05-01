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
        public override void MouseStateChanged(int x, int y)
        {
            if (_points == null)
            {
                _points = new List<Point>();
                _points.Add(new Point(x, y));
                _hasDrawn = true;
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
                _hasDrawn = true;
            }

        }
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                for (int i = 0; i < _points.Count - 1; i++)
                {
                    var p1 = new Point((int)(_points[i].X + _thickness / 4), _points[i].Y );
                    var p2 = new Point((int)(_points[i].X - _thickness / 4), _points[i].Y);
                    graphics.DrawLine(new Pen(_color, _thickness), p1, p2);
                    graphics.DrawLine(new Pen(_color, _thickness), _points[i], _points[i+1]);
                }
            }
        }
    }
}
