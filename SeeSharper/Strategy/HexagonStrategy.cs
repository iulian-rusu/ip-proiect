/**************************************************************************
 *                                                                        *
 *  File:        HexagonStrategy.cs                                       *
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
     public class HexagonStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw hexagon with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] hexagonPoints = new Point[6];
                
                int sideLength = (_points[1].Y - _points[0].Y) / 2;
                int width = _points[1].X - _points[0].X;

                hexagonPoints[0] = _points[0];
                hexagonPoints[1] = new Point(_points[1].X, _points[1].Y - sideLength);
                hexagonPoints[2] = _points[1];
                hexagonPoints[3] = new Point(_points[0].X, _points[1].Y + sideLength);
                hexagonPoints[4] = new Point(_points[0].X - width, _points[1].Y);
                hexagonPoints[5] = new Point(_points[0].X - width, _points[1].Y - sideLength);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), hexagonPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), hexagonPoints);
            }
        }
    }
}
