/**************************************************************************
 *                                                                        *
 *  File:        PentagonStrategy.cs                                      *
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
    public class PentagonStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw pentagon with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] pentagonPoints = new Point[5];

                int width = _points[1].X - _points[0].X;
                int height = Math.Abs(_points[1].Y - _points[0].Y);

                Point startPoint;

                if (_points[1].Y - _points[0].Y > 0)
                {
                    startPoint = new Point(_points[0].X, _points[0].Y + height / 3); // left corner
                    pentagonPoints[0] = startPoint;
                    pentagonPoints[1] = new Point(startPoint.X + width / 2, startPoint.Y - height / 3);
                    pentagonPoints[2] = new Point(startPoint.X + width, startPoint.Y);
                    pentagonPoints[3] = new Point(startPoint.X + width - width / 5, (int)(startPoint.Y + 2.0 / 3.0 * height));
                    pentagonPoints[4] = new Point(startPoint.X + width / 5, (int)(startPoint.Y + 2.0 / 3.0 * height));
                }
                else
                {
                    startPoint = new Point(_points[0].X + width / 5, _points[0].Y); // lower left corner
                    pentagonPoints[0] = startPoint;
                    pentagonPoints[1] = new Point(startPoint.X + width - 2 * width / 5, startPoint.Y);
                    pentagonPoints[2] = new Point(startPoint.X + width - width / 5, (int)(startPoint.Y - 2.0 / 3.0 * height));
                    pentagonPoints[3] = new Point(startPoint.X + width / 2 - width / 5, startPoint.Y - height);
                    pentagonPoints[4] = new Point(startPoint.X - width / 5, (int)(startPoint.Y - 2.0 / 3.0 * height));
                }

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), pentagonPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), pentagonPoints);
            }
        }
    }
}
