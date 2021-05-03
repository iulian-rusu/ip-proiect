/**************************************************************************
 *                                                                        *
 *  File:        ArrowRightStrategy.cs                                    *
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strategy
{
    public class ArrowRightStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw arrow right with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] arrowPoints = new Point[7];

                int bodyWidth = Math.Abs((int)((_points[1].X - _points[0].X) / 2.0));
                int bodyHeight = (int)((2.0 / 3.0) * (_points[1].Y - _points[0].Y));
                int arrowheadMargin = (int)(bodyHeight / 2.0);

                Point startPoint; // lower left corner

                if (_points[1].X - _points[0].X > 0)
                {
                    startPoint = new Point(_points[0].X, _points[0].Y + bodyHeight);
                }
                else
                {
                    startPoint = new Point(_points[1].X, _points[1].Y - arrowheadMargin);
                }

                arrowPoints[0] = startPoint;
                arrowPoints[1] = new Point(startPoint.X, startPoint.Y - bodyHeight);
                arrowPoints[2] = new Point(startPoint.X + bodyWidth, startPoint.Y - bodyHeight);
                arrowPoints[3] = new Point(startPoint.X + bodyWidth, startPoint.Y - bodyHeight - arrowheadMargin);
                arrowPoints[4] = new Point(startPoint.X + 2 * bodyWidth, startPoint.Y - bodyHeight / 2);
                arrowPoints[5] = new Point(startPoint.X + bodyWidth, startPoint.Y + arrowheadMargin);
                arrowPoints[6] = new Point(startPoint.X + bodyWidth, startPoint.Y);

                graphics.FillPolygon(new SolidBrush(_fillColor), arrowPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), arrowPoints);
            }
        }
    }
}
