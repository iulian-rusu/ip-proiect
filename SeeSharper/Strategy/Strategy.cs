/**************************************************************************
 *                                                                        *
 *  File:        Strategy.cs                                              *
 *  Copyright:   (c) 2021, Nistor Paula-Alina                             *
 *  E-mail:      paula-alina.nistor@student.tuiasi.ro                     *
 *  Description: Strategy for drawing figures                             *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public abstract class Strategy
    {
        protected Color _color;
        protected Color _fillColor;
        protected float _thickness;
        protected bool _done = false;

        public bool Done
        {
            get { return _done; }
        }

        public void ColorChanged(Color color)
        {
            _color = color;
        }

        public void ChangeThickness(float thickness)
        {
            _thickness = thickness;
        }

        public void ChangeFillColor(Color color)
        {
            _fillColor = color;
        }

        public PaintEventHandler GetDraw()
        {
            return new PaintEventHandler(Draw);
        }

        public abstract void MouseClicked(int x, int y);
        public abstract void MouseMoved(int x, int y);
        public abstract void Reset();
        protected abstract void Draw(object sender, PaintEventArgs e);
        public abstract string GetDescription();
    }
}