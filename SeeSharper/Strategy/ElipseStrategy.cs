/**************************************************************************
 *                                                                        *
 *  File:        ElipseStrategy.cs                                        *
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
    public class ElipseStrategy : TwoPointStrategy
    {
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                int width = Math.Abs(_points[1].X - _points[0].X);
                int height = Math.Abs(_points[1].Y - _points[0].Y);
                int startX = Math.Min(_points[1].X, _points[0].X);
                int startY = Math.Min(_points[1].Y, _points[0].Y);
                var rect = new Rectangle(startX, startY, width, height);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillEllipse(new SolidBrush(_fillColor), rect);
                graphics.DrawEllipse(new Pen(_color, _thickness), rect);
            }
        }
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw ellipse from ({_points[0].X}, {_points[0].Y}) to ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }
    }
}