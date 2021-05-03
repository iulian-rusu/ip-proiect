/**************************************************************************
 *                                                                        *
 *  File:        HeartStrategy.cs                                         *
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Strategy
{
    public class HeartStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw hearth with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Pen pen = new Pen(_color, _thickness);

                int width = Math.Abs(_points[1].X - _points[0].X);
                int height = Math.Abs(_points[1].Y - _points[0].Y);

                var rect1 = new Rectangle(_points[0].X, _points[0].Y, width / 2 + 1, height / 2 + 1);
                var rect2 = new Rectangle((_points[0].X + width / 2), _points[0].Y, width / 2 + 1, height / 2 + 1);

                float startAngle = -180F;
                float sweepAngle = 180F;

                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddArc(rect1, startAngle, sweepAngle);
                graphicsPath.AddArc(rect2, startAngle, sweepAngle);
                graphicsPath.AddLine(new Point(_points[0].X, _points[0].Y + height / 4), new Point(width / 2 + _points[0].X, _points[0].Y + height));
                graphicsPath.AddLine(new Point(_points[0].X + width, _points[0].Y + height / 4), new Point(width / 2 + _points[0].X, _points[0].Y + height));
                graphicsPath.CloseFigure();
                // graphicsPath.AddBezier(new Point(_points[0].X, _points[0].Y + height / 4), new Point(_points[0].X + width / 10, _points[0].Y + height / 4 * 3), new Point(_points[0].X + width / 10 * 4, _points[0].Y + height), new Point(width / 2 + _points[0].X, _points[0].Y + height));
                // graphicsPath.AddBezier(new Point(_points[0].X + width, _points[0].Y + height / 4), new Point(_points[0].X + width - width / 10, _points[0].Y + height / 4 * 3), new Point(_points[0].X + width - width / 10 * 4, _points[0].Y + height), new Point(width / 2 + _points[0].X, _points[0].Y + height));
                graphics.FillPath(new SolidBrush(_fillColor), graphicsPath);
                graphics.DrawPath(pen, graphicsPath);
            }
        }
    }
}
