/**************************************************************************
 *                                                                        *
 *  File:        BrushStrategy.cs                                         *
 *  Copyright:   (c) 2021, Nistor Paula-Alina                             *
 *  E-mail:      paula-alina.nistor@student.tuiasi.ro                     *
 *  Description: Strategy class for brush                                 *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    /// <summary>
    /// Implements brush strategy
    /// </summary>
    public class BrushStrategy : MultiplePointStrategy
    {
        #region Private Fields
        private List<Rectangle> _rectangles;
        #endregion

        #region Protected Methods
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                for (int i = 0; i < _points.Count - 1; i++)
                {
                    Point[] polygonPoints = new Point[4];
                    int width = _points[i + 1].X - _points[i].X;
                    int height = _points[i + 1].Y - _points[i].Y;
                    int size = _rectangles[0].Width;

                    if (width * height <= 0)
                    {
                        polygonPoints[0] = new Point(_rectangles[i].X, _rectangles[i].Y);
                        polygonPoints[1] = new Point(_rectangles[i].X + size, _rectangles[i].Y + size);
                        polygonPoints[3] = new Point(_rectangles[i + 1].X, _rectangles[i + 1].Y);
                        polygonPoints[2] = new Point(_rectangles[i + 1].X + size, _rectangles[i + 1].Y + size);
                    }
                    else
                    {
                        polygonPoints[0] = new Point(_rectangles[i].X + size, _rectangles[i].Y);
                        polygonPoints[1] = new Point(_rectangles[i].X, _rectangles[i].Y + size);
                        polygonPoints[2] = new Point(_rectangles[i + 1].X, _rectangles[i + 1].Y + size);
                        polygonPoints[3] = new Point(_rectangles[i + 1].X + size, _rectangles[i + 1].Y);
                    }

                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.FillRectangle(new SolidBrush(_color), _rectangles[i]);
                    graphics.FillPolygon(new SolidBrush(_color), polygonPoints);
                }
            }
        }
        #endregion

        #region Public Methods
        public override void MouseStateChanged(int x, int y)
        {
            if (_points == null)
            {
                _points = new List<Point>();
                _rectangles = new List<Rectangle>();
                _points.Add(new Point(x, y));
                _rectangles.Add(new Rectangle(x - (int)_thickness / 2, y - (int)_thickness / 2, (int)_thickness, (int)_thickness));
                _hasDrawn = true;
            }
            else
            {
                _done = true;
            }
        }

        public override void MouseMoved(int x, int y)
        {
            if (_points != null && !_done)
            {
                _points.Add(new Point(x, y));
                _rectangles.Add(new Rectangle(x - (int)_thickness / 2, y - (int)_thickness / 2, (int)_thickness, (int)_thickness));
                _hasDrawn = true;
            }
        }
        #endregion
    }
}
