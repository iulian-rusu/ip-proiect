using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public abstract class TwoPointStrategy : Strategy
    {
        protected Point[] _points;

        public override void MouseClicked(int x, int y)
        {
            if (_points == null)
            {
                _points = new Point[2];
                _points[0].X = _points[1].X = x;
                _points[0].Y = _points[1].Y = y;
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
                _points[1].X = x;
                _points[1].Y = y;
            }
        }

        public override void Reset()
        {
            _done = false;
            _points = null;
        }
    }
}
