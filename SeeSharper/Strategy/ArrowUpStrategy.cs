/**************************************************************************
 *                                                                        *
 *  File:        ArrowUpStrategy.cs                                       *
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
    public class ArrowUpStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw arrow up with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] arrowPoints = new Point[7];

                int bodyWidth = (int)((_points[1].X - _points[0].X) / 2.0);
                int bodyHeight = Math.Abs((int)((_points[1].Y - _points[0].Y) / 2.0 ));
                int arrowheadMargin = (int)(bodyWidth / 2.0);

                Point startPoint; // lower left corner

                if (_points[1].Y - _points[0].Y > 0)
                {
                    startPoint = new Point(_points[0].X + arrowheadMargin, _points[0].Y + 2 * bodyHeight);
                }
                else
                {
                    startPoint = new Point(_points[0].X + arrowheadMargin, _points[0].Y);
                }

                arrowPoints[0] = startPoint;
                arrowPoints[1] = new Point(startPoint.X + bodyWidth, startPoint.Y);
                arrowPoints[2] = new Point(startPoint.X + bodyWidth, startPoint.Y - bodyHeight);
                arrowPoints[3] = new Point(startPoint.X + bodyWidth + arrowheadMargin, startPoint.Y - bodyHeight);
                arrowPoints[4] = new Point(startPoint.X + bodyWidth / 2, startPoint.Y - 2 * bodyHeight);
                arrowPoints[5] = new Point(startPoint.X - arrowheadMargin, startPoint.Y - bodyHeight);
                arrowPoints[6] = new Point(startPoint.X, startPoint.Y - bodyHeight);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), arrowPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), arrowPoints);
            }
        }
    }
}
