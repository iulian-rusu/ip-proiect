/**************************************************************************
 *                                                                        *
 *  File:        Presenter.cs                                             *
 *  Copyright:   (c) 2021, Rusu Iulian                                    *
 *  E-mail:      iulian.rusu@student.tuiasi.ro                            *
 *  Description: The presenter implementation of the Model-View-Presenter *
 *               architecture.                                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


namespace Presenter
{
    using Shared;
    using Strategy;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Presenter class - manages the presentation logic of the application
    /// </summary>
    public class Presenter : IPresenter
    {
        #region Private Members
        private IView _view;
        private IModel _model;
        private Strategy _currentStrategy = new LineStrategy();
        private bool _isMousePressed = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the Presenter class
        /// </summary>
        /// <param name="model">The model of the MVP architecture</param>
        /// <param name="view">The view of the MVP architecture</param>
        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;
        }
        #endregion

        #region Public Member Functions
        /// <summary>
        /// Called to notify of a mouse move event
        /// </summary>
        /// <param name="x">The x coordinate of the mouse cursor</param>
        /// <param name="y">The y coordinate of the mouse cursor</param>
        public void MouseMoved(int x, int y)
        {
            if (_isMousePressed)
            {
                _currentStrategy.MouseMoved(x, y);
                _view.ChangeCurrentHandler(_currentStrategy);
            }
        }

        /// <summary>
        /// Called when the mouse button changes its state to DOWN or UP
        /// </summary>
        /// <param name="x">The x coordinate of the mouse cursor</param>
        /// <param name="y">The y coordinate of the mouse cursor</param>
        public void MouseStateChanged(int x, int y)
        {
            _isMousePressed = !_isMousePressed;
            if (_currentStrategy.Done)
            {
                CaptureAndAddMemento();
                _currentStrategy.Reset();
            }
            _currentStrategy.MouseStateChanged(x, y);
            _view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Saves the current state of the View drawing to the model
        /// </summary>
        public void SaveDrawing()
        {
            if (!_model.HasSaveFileName())
            {
                string filename = _view.GetSaveFileName();

                if (!IsValidFileName(filename))
                {
                    return;
                }

                _model.SetSaveFileName(filename);
            }
            _view.CaptureDrawingState();
            var drawingMemento = _view.GetDrawingMemento();
            _model.DropMementos();
            _model.SaveDrawing(drawingMemento);
            UpdateUndoRedoInView();
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Sets the state of the View drawing to revert the last "Undo" operation
        /// </summary>
        public void Redo()
        {
            var currentMemento = _model.Redo();
            _view.SetDrawingMemento(currentMemento);
            UpdateUndoRedoInView();
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Sets the state of the View drawing to revert the last recorded change
        /// </summary>
        public void Undo()
        {
            var currentMemento = _model.Undo();
            _view.SetDrawingMemento(currentMemento);
            UpdateUndoRedoInView();
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Applies the new color to the current drawing strategy
        /// </summary>
        /// <param name="color">The new color</param>
        public void ColorChanged(Color color)
        {
            _currentStrategy.ColorChanged(color);
            _view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Applies the new fill color to the current drawing strategy
        /// </summary>
        /// <param name="color">The new color</param>
        public void FillColorChanged(Color color)
        {
            _currentStrategy.FillColorChanged(color);
            _view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Changes the thickness of the current tool
        /// </summary>
        /// <param name="thickness">The new thickness</param>
        public void ThicknessChanged(float thickness)
        {
            _currentStrategy.ThicknessChanged(thickness);
            _view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Updates the current strategy to match the selected tool
        /// </summary>
        /// <param name="paintingTool">The new selected painting tool</param>
        /// <param name="borderColor">The color of the border of the painting tool</param>
        /// <param name="fillColor">The fill color of the painting tool</param>
        public void ChoosePaintingTool(PaintingTool paintingTool, Color borderColor, Color fillColor)
        {
            if (_currentStrategy.Done)
            {
                CaptureAndAddMemento();
            }

            var newStrategy = _model.GetPaintingStrategy(paintingTool);
            _view.ChangeCurrentHandler(newStrategy);
            _currentStrategy = newStrategy;
            ColorChanged(borderColor);
            FillColorChanged(fillColor);
        }

        /// <summary>
        /// Sets the View drawing to the one loaded in the model
        /// </summary>
        /// <param name="filename">The path to the file on the disk</param>
        public void LoadDrawing(string filename)
        {
            var loadedMemento = _model.LoadDrawing(filename);
            _model.AddMemento(loadedMemento);
            UpdateUndoRedoInView();
            _view.SetDrawingMemento(loadedMemento);
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Returns a description for the last change made by the selected tool
        /// </summary>
        /// <returns>A string that describes the changes made by the tool</returns>
        public string GetCurrentStrategyDescription()
        {
            return _currentStrategy.GetDescription();
        }
        #endregion
        #region Private Member Functions
        private bool IsValidFileName(string filename)
        {
            string extension = Path.GetExtension(filename);
            return extension == ".bmp" || extension == ".png";
        }
        private void UpdateUndoRedoInView()
        {
            var newUndoDescription = _model.GetNextUndoDescription();
            _view.SetUndo(newUndoDescription);
            var newRedoDescription = _model.GetNextRedoDescription();
            _view.SetRedo(newRedoDescription);
        }

        private void CaptureAndAddMemento()
        {
            if(_currentStrategy.HasDrawn)
            {
                _view.CaptureDrawingState();
                _model.AddMemento(_view.GetDrawingMemento());
                UpdateUndoRedoInView();
            }
        }
        #endregion
    }
}
