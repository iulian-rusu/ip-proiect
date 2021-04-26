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
                graphics.DrawEllipse(new Pen(_color), rect);
            }
        }
    }
}