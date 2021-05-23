/**************************************************************************
 *                                                                        *
 *  File:        SquareStrategy.cs                                        *
 *  Copyright:   (c) 2021, Rusu Iulian                                    *
 *  E-mail:      iulian.rusu2@student.tuiasi.ro                           *
 *  Description: Strategy class for square shape                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Windows.Forms;
using System;
using System.Drawing;

namespace Strategy
{
    /// <summary>
    /// Implements the square drawing strategy
    /// </summary>
    public class SquareStrategy : TwoPointStrategy
    {
        #region Protected Methods
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

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillRectangle(new SolidBrush(_fillColor), rect);
                graphics.DrawRectangle(new Pen(_color, _thickness), rect);
            }
        }
        #endregion

        #region Public Methods
        public override string GetDescription()
        {
            if (!_hasDrawn)
            {
                return "Nothing drawn";
            }

            if (_points != null)
            {
                return $"Draw square with center ({_points[0].X}, {_points[0].Y}) and corner ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }
        #endregion
    }
}