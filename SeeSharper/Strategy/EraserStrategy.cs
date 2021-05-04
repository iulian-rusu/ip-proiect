/**************************************************************************
 *                                                                        *
 *  File:        EraserStrategy.cs                                        *
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
    public class EraserStrategy : MultiplePointStrategy
    {
        List<Rectangle> _rectangles;
        public override void MouseStateChanged(int x, int y)
        {
            if (_points == null)
            {
                _points = new List<Point>();
                _rectangles = new List<Rectangle>();
                _points.Add(new Point(x, y));
                _rectangles.Add(new Rectangle(x - 3 * (int)_thickness / 2, y - 3 * (int)_thickness / 2, 3 * (int)_thickness, 3 * (int)_thickness));
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
                _rectangles.Add(new Rectangle(x - 3 * (int)_thickness / 2, y - 3 * (int)_thickness / 2, 3 * (int)_thickness, 3 * (int)_thickness));
                _hasDrawn = true;
            }
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (_points != null)
            {
                var graphics = e.Graphics;
                for (int i = 0; i < _points.Count - 1; i++)
                {
                    Point[] points = new Point[4];
                    int width = _points[i + 1].X - _points[i].X;
                    int height = _points[i + 1].Y - _points[i].Y;
                    int size = _rectangles[0].Width;

                    if (width * height <= 0)
                    {
                        points[0] = new Point(_rectangles[i].X, _rectangles[i].Y);
                        points[1] = new Point(_rectangles[i].X + size, _rectangles[i].Y + size);
                        points[3] = new Point(_rectangles[i + 1].X, _rectangles[i + 1].Y);
                        points[2] = new Point(_rectangles[i + 1].X + size, _rectangles[i + 1].Y + size);
                    }
                    else
                    {
                        points[0] = new Point(_rectangles[i].X + size, _rectangles[i].Y);
                        points[1] = new Point(_rectangles[i].X, _rectangles[i].Y + size);
                        points[2] = new Point(_rectangles[i + 1].X, _rectangles[i + 1].Y + size);
                        points[3] = new Point(_rectangles[i + 1].X + size, _rectangles[i + 1].Y);
                    }

                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.FillRectangle(new SolidBrush(Color.White), _rectangles[i]);
                    graphics.FillPolygon(new SolidBrush(Color.White), points);
                }
            }
        }
    }
}
