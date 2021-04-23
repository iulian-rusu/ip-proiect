﻿/**************************************************************************
 *                                                                        *
 *  File:        Model.cs                                                 *
 *  Copyright:   (c) 2021, Baltariu Ionut-Alexandru                       *
 *  E-mail:      ionut-alexandru.baltariu@student.tuiasi.ro               *
 *  Description: The model class of the Model-View-Presenter architecture.*
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


namespace Model
{
    using Shared;
    using Strategy;
    using Memento;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing.Imaging;

    /// <summary>
    /// Model class - contains the data, state and logic of the application.
    /// </summary>
    public class Model : IModel
	{
        #region Private Fields
        private string _saveFileName;
		private UndoStack _undoStack;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the model - initializes the undo stack
        /// </summary>
        public Model()
        {
            _undoStack = new UndoStack();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the strategy for a painting tool
        /// </summary>
        /// <param name="paintingTool">The given painting tool</param>
        /// <returns>The strategy corresponding to the painting tool</returns>
        public Strategy GetPaintingStrategy(PaintingTool paintingTool)
        {
            Strategy strategy = null;

            switch (paintingTool)
            {
                case PaintingTool.Brush:
                    strategy = new BrushStrategy();
                    break;
                case PaintingTool.Line:
                    strategy = new LineStrategy();
                    break;
                case PaintingTool.Circle:
                    strategy = new CircleStrategy();
                    break;
                case PaintingTool.Ellipse:
                    strategy = new ElipseStrategy();
                    break;
                case PaintingTool.Square:
                    strategy = new SquareStrategy();
                    break;
                case PaintingTool.Rectangle:
                    strategy = new RectangleStrategy();
                    break;
                default:
                    MessageBox.Show("Error: Invalid painting tool.");
                    break;
            }

            return strategy;
        }

        /// <summary>
        /// Checks if a file name has been given when saving the drawing.
        /// </summary>
        /// <returns>Boolean value of the stated scenario</returns>
        public bool HasSaveFileName()
        {
            bool hasSaveFileName = false; 

            if(_saveFileName != null)
            {
                hasSaveFileName = true;
            }

            return hasSaveFileName;
        }

        /// <summary>
        /// Loads a drawing from the given path
        /// </summary>
        /// <param name="filename">Drawing path on disk</param>
        /// <returns>The drawing at the given path</returns>
        public DrawingMemento LoadDrawing(string filename)
        { 
            return new DrawingMemento(Image.FromFile(filename));
        }

        /// <summary>
        /// Redoes the last undone action
        /// </summary>
        /// <returns>The drawing with the corresponding content</returns>
        public DrawingMemento Redo()
        {
            return _undoStack.Redo();
        }

        /// <summary>
        /// Saves a drawing at the path mentioned in _saveFileName
        /// </summary>
        /// <param name="drawingMemento">The drawing</param>
        /// <returns>void</returns>
        public void SaveDrawing(DrawingMemento drawingMemento)
        {
            ImageFormat drawingFormat;
            string drawingExtension = Path.GetExtension(_saveFileName);

            switch (drawingExtension)
            {
                case ".png":
                    drawingFormat = ImageFormat.Png;
                    break;
                case ".bmp":
                    drawingFormat = ImageFormat.Bmp;
                    break;
                default:
                    MessageBox.Show("Error: invalid format.");
                    return;
            }

            drawingMemento.Drawing.Save(_saveFileName, drawingFormat);
            _undoStack.Drop();

        }

        /// <summary>
        /// Setter for the drawing file save path
        /// </summary>
        /// <param name="saveFileName">The wished path</param>
        /// <returns>void</returns>
        public void SetSaveFileName(string saveFileName)
        {
            _saveFileName = saveFileName;
        }

        /// <summary>
        /// Undoes the last done action
        /// </summary>
        /// <returns>The drawing with the corresponding content</returns>
        public DrawingMemento Undo()
        {
            return _undoStack.Undo();
        }
        #endregion
    }

}
