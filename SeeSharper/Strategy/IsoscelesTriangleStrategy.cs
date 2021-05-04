/**************************************************************************
 *                                                                        *
 *  File:        IsoscelesTriangleStrategy.cs                             *
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
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class IsoscelesTriangleStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw triangle with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] trianglePoints = new Point[3];
                int height = Math.Abs(_points[1].Y - _points[0].Y);
                int width = _points[1].X - _points[0].X;

                Point startPoint; // left corner
                
                if (_points[1].Y - _points[0].Y > 0)
                {
                    startPoint = new Point(_points[0].X, _points[0].Y + height);
                }
                else
                {
                    startPoint = _points[0];
                }

                trianglePoints[0] = startPoint;
                trianglePoints[1] = new Point(startPoint.X + width, startPoint.Y);
                trianglePoints[2] = new Point(startPoint.X + width / 2, startPoint.Y - height);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), trianglePoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), trianglePoints);
            }
        }
    }
}
