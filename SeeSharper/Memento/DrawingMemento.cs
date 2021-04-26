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
        private string _description;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the DrawingMemento - initializes the image
        /// </summary>
        /// <param name="drawing">Image/drawing to be wrapped</param>
        /// <param name="drawing">The description of that image</param>
        public DrawingMemento(Image drawing, string description)
		{
            _drawing = drawing;
            _description = description;
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

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        #endregion
    }
}