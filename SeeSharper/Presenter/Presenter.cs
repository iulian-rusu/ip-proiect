namespace Presenter
{
    using Shared;
    using Strategy;
    using System.Drawing;
    using System.Windows.Forms;

    public class Presenter : IPresenter
	{
        #region Private Members
        private IView _view;
		private IModel _model;
		private Strategy _currentStrategy;
        private string _helpString = @"Helpful description.";
        #endregion
        #region Public Member Functions
        public Presenter(IModel model, IView view)
        {
			_model = model;
			_view = view;
        }

		public void MouseMoved(int x, int y)
		{
            _currentStrategy.MouseMoved(x, y);
		}

        public void MouseClicked(int x, int y)
        {
            _currentStrategy.MouseClicked(x, y);
        }

        public void LoadHelp()
		{
            MessageBox.Show(_helpString, "Help");
		}

        public bool Exit()
		{
            DialogResult res = MessageBox.Show("Exit application?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return res == DialogResult.OK;
        }

        public void SaveDrawing()
		{
            var drawingMemento = _view.GetDrawingMemento();
            _model.SaveDrawing(drawingMemento);
		}

        public void Redo()
		{
            var currentMemento = _model.Redo();
            _view.SetDrawingMemento(currentMemento);
		}

        public void Undo()
        {
            var currentMemento = _model.Undo();
            _view.SetDrawingMemento(currentMemento);
        }

        public void ColorChanged(Color color)
		{
            // _model.ColorChanged(color);
		}

        public void ChoosePaintingTool(PaintingTool paintingTool)
		{
            _currentStrategy = _model.GetPaintingStrategy(paintingTool);
		}

        public void LoadDrawing(string filename)
		{
            /*
            TODO: move to view
             
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    _presenter.LoadDrawing(filePath);
                }
            }
            */
            var loadedMemento = _model.LoadDrawing(filename);
            _view.SetDrawingMemento(loadedMemento);
        }
        #endregion
    }
}
