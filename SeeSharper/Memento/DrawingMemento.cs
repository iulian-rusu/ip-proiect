/**************************************************************************
 *                                                                        *
 *  File:        DrawingMemento.cs                                        *
 *  Copyright:   (c) 2021, Baltariu Ionut-Alexandru                       *
 *  E-mail:      ionut-alexandru.baltariu@student.tuiasi.ro               *
 *  Description: Wrapper for an image/drawing used for selecting          *
 *   drawings at different states in the undo/redo process                *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


using System.Drawing;

namespace Memento
{
    /// <summary>
    /// Drawing memento - wrapper for an Image object
    /// </summary>
    public class DrawingMemento
	{
        #region Fields
        private Image _drawing;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the DrawingMemento - initializes the image
        /// </summary>
        /// <param name="drawing">Image/drawing to be wrapped</param>
        public DrawingMemento(Image drawing)
		{
            _drawing = drawing;
		}
        #endregion

        #region Properties
        /// <summary>
        /// Property used to access the Image
        /// </summary>
        public Image Drawing
		{
			get { return _drawing; }
		}
        #endregion
    }
}