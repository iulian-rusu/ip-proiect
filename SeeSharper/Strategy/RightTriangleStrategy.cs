/**************************************************************************
 *                                                                        *
 *  File:        RightAngleTriangleStrategy.cs                            *
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

using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public class RightTriangleStrategy : TwoPointStrategy
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
                int diff = _points[1].X - _points[0].X;

                trianglePoints[0] = _points[0];
                trianglePoints[1] = _points[1];
                trianglePoints[2] = new Point(_points[1].X - diff, _points[1].Y);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), trianglePoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), trianglePoints);
            }
        }
    }
}
