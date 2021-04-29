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
        /// Called to notify of a mouse click event
        /// </summary>
        /// <param name="x">The x coordinate of the mouse cursor</param>
        /// <param name="y">The y coordinate of the mouse cursor</param>
        public void MouseClicked(int x, int y)
        {
            //if (_currentStrategy.Done)
            //{
            //    _view.CaptureDrawingState();
            //    _model.AddMemento(_view.GetDrawingMemento());
            //    _currentStrategy.Reset();
            //}
            //_currentStrategy.MouseClicked(x, y);
            //_view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Called to notify of a mouse move event
        /// </summary>
        /// <param name="x">The x coordinate of the mouse cursor</param>
        /// <param name="y">The y coordinate of the mouse cursor</param>
        public void MouseMoved(int x, int y)
        {
            if(_isMousePressed)
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
                _view.CaptureDrawingState();
                _model.AddMemento(_view.GetDrawingMemento());
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
            if(!_model.HasSaveFileName())
            {
                _model.SetSaveFileName(_view.GetSaveFileName());
            }
            _view.CaptureDrawingState();
            var drawingMemento = _view.GetDrawingMemento();
            _model.SaveDrawing(drawingMemento);
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Sets the state of the View drawing to revert the last "Undo" operation
        /// </summary>
        public void Redo()
        {
            var currentMemento = _model.Redo();
            _view.SetDrawingMemento(currentMemento);
            _currentStrategy.Reset();
        }

        /// <summary>
        /// Sets the state of the View drawing to revert the last recorded change
        /// </summary>
        public void Undo()
        {
            var currentMemento = _model.Undo();
            _view.SetDrawingMemento(currentMemento);
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
            _currentStrategy.ChangeFillColor(color);
            _view.ChangeCurrentHandler(_currentStrategy);
        }

        /// <summary>
        /// Updates the current strategy to match the selected tool
        /// </summary>
        /// <param name="paintingTool">The new selected painting tool</param>
        /// <param name="selectedColor">The color of the painting tool</param>
        public void ChoosePaintingTool(PaintingTool paintingTool, Color selectedColor)
        {
            if (_currentStrategy.Done)
            {
                _view.CaptureDrawingState();
                var memento = _view.GetDrawingMemento();
                _model.AddMemento(memento);
            }

            var newStrategy = _model.GetPaintingStrategy(paintingTool);
            _view.ChangeCurrentHandler(newStrategy);
            _currentStrategy = newStrategy;
            ColorChanged(selectedColor);
        }

        /// <summary>
        /// Sets the View drawing to the one loaded in the model
        /// </summary>
        /// <param name="filename">The path to the file on the disk</param>
        public void LoadDrawing(string filename)
        {
            var loadedMemento = _model.LoadDrawing(filename);
            _view.SetDrawingMemento(loadedMemento);
            _currentStrategy.Reset();
        }
        #endregion
    }
}
