/**************************************************************************
 *                                                                        *
 *  File:        CircleStrategy.cs                                        *
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
    public class CircleStrategy : TwoPointStrategy
    {
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;

                int midX = _points[0].X;
                int midY = _points[0].Y;

                int width = Math.Abs(_points[1].X - midX);
                int height = Math.Abs(_points[1].Y - midY);
                int dim = Math.Max(width, height);

                int startX = midX - dim;
                int startY = midY - dim;

                var rect = new Rectangle(startX, startY, 2 * dim, 2 * dim);
                graphics.DrawEllipse(new Pen(_color, _thickness), rect);
                graphics.FillEllipse(new SolidBrush(_fillColor), rect);
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
                return $"Draw circle with center ({_points[0].X}, {_points[0].Y}) and point ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }
    }
}