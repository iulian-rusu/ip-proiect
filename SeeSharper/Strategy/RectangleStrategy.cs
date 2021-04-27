/**************************************************************************
 *                                                                        *
 *  File:        RectangleStrategy.cs                                     *
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
    public class RectangleStrategy : TwoPointStrategy
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
                graphics.DrawRectangle(new Pen(_color, _thickness), rect);
                graphics.FillRectangle(new SolidBrush(_fillColor), rect);
            }
        }
    }
}
