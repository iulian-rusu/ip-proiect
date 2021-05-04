/**************************************************************************
 *                                                                        *
 *  File:        RhombStrategy.cs                                         *
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
    public class RhombStrategy : TwoPointStrategy
    {
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw rhomb with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                Point[] rhombPoints = new Point[4];
                int width = _points[1].X - _points[0].X;
                int height = _points[1].Y - _points[0].Y;

                rhombPoints[0] = new Point(_points[0].X + width / 2, _points[0].Y);
                rhombPoints[1] = new Point(_points[0].X + width, _points[0].Y + height / 2);
                rhombPoints[2] = new Point(_points[0].X + width / 2, _points[0].Y + height);
                rhombPoints[3] = new Point(_points[0].X, _points[0].Y + height / 2);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), rhombPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), rhombPoints);
            }
        }
    }
}
