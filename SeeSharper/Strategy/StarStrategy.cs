/**************************************************************************
 *                                                                        *
 *  File:        StarStrategy.cs                                          *
 *  Copyright:   (c) 2021, Nistor Paula-Alina                             *
 *  E-mail:      paula-alina.nistor@student.tuiasi.ro                     *
 *  Description: Strategy class for star shape                            *
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
    /// <summary>
    /// Implements the star drawing strategy
    /// </summary>
    public class StarStrategy : TwoPointStrategy
    {
        #region Protected Methods

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;

                float width = _points[1].X - _points[0].X;
                double ang36 = Math.PI / 5.0;
                double ang72 = 2.0 * ang36;
                float sin36 = (float)Math.Sin(ang36);
                float sin72 = (float)Math.Sin(ang72);
                float cos36 = (float)Math.Cos(ang36);
                float cos72 = (float)Math.Cos(ang72);
                float outerRadius = width;
                float innerRadius = (float)(width / 2.0);

                PointF center = _points[0];
                PointF[] starPoints = new PointF[10];

                starPoints[0] = new PointF(center.X, center.Y - outerRadius);
                starPoints[1] = new PointF(center.X + innerRadius * sin36, center.Y - innerRadius * cos36);
                starPoints[2] = new PointF(center.X + outerRadius * sin72, center.Y - outerRadius * cos72);
                starPoints[3] = new PointF(center.X + innerRadius * sin72, center.Y + innerRadius * cos72);
                starPoints[4] = new PointF(center.X + outerRadius * sin36, center.Y + outerRadius * cos36);
                starPoints[5] = new PointF(center.X, center.Y + innerRadius);
                starPoints[6] = new PointF(2 * center.X - starPoints[4].X, starPoints[4].Y);
                starPoints[7] = new PointF(2 * center.X - starPoints[3].X, starPoints[3].Y);
                starPoints[8] = new PointF(2 * center.X - starPoints[2].X, starPoints[2].Y);
                starPoints[9] = new PointF(2 * center.X - starPoints[1].X, starPoints[1].Y);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPolygon(new SolidBrush(_fillColor), starPoints);
                graphics.DrawPolygon(new Pen(_color, _thickness), starPoints);
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
                return $"Draw star with corner ({_points[0].X}, {_points[0].Y}) and ({_points[1].X}, {_points[1].Y})";
            }
            return "Something wrong";
        }
        #endregion
    }
}
