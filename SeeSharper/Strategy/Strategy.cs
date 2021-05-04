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
    /// <summary>
    /// Base class for each shape strategy.
    /// </summary>
    public abstract class Strategy
    {
        #region Protected Fields
        protected Color _color;
        protected Color _fillColor;
        protected float _thickness;
        protected bool _done = false;
        protected bool _hasDrawn = false;
        #endregion

        #region Properties
        /// <summary>
        /// Property that access done flag
        /// </summary>
        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        /// <summary>
        /// Property that check if the shape was drawn
        /// </summary>
        public bool HasDrawn
        {
            get { return _hasDrawn; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Change shape border color
        /// </summary>
        /// <param name="color">New color</param>
        public void ColorChanged(Color color)
        {
            _color = color;
        }

        /// <summary>
        /// Change shape border thickness
        /// </summary>
        /// <param name="thickness">New thickness</param>
        public void ThicknessChanged(float thickness)
        {
            _thickness = thickness;
        }

        /// <summary>
        /// Change shape fill color
        /// </summary>
        /// <param name="color">New fill color</param>
        public void FillColorChanged(Color color)
        {
            _fillColor = color;
        }

        /// <summary>
        /// Method that returns the event handler for draw method
        /// </summary>
        /// <returns>Draw method paint event handler</returns>
        public PaintEventHandler GetDraw()
        {
            return new PaintEventHandler(Draw);
        }

        /// <summary>
        /// Change coordinates on mouse state changed
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public abstract void MouseStateChanged(int x, int y);

        /// <summary>
        /// Change coordinates on mouse moved
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public abstract void MouseMoved(int x, int y);

        /// <summary>
        /// Reset attributes to default values
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Method that draws the figure on screen
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Paint event arguments</param>
        protected abstract void Draw(object sender, PaintEventArgs e);

        /// <summary>
        /// Method to find out what object was drawn and what its position was
        /// </summary>
        /// <returns>A string with information about the position of the shape</returns>
        public abstract string GetDescription();
        #endregion
    }
}