namespace Presenter
{
    using Shared;
    using Strategy;
    using System.Drawing;

    public class Presenter : IPresenter
	{
		private IView _view;
		private IModel _model;
		private Strategy _currentStrategy;

		public void MouseMoved(int x, int y)
		{
			// TODO add implementation
		}

		public void LoadHelp()
		{
			// TODO add implementation
		}

        public void Exit()
		{
			// TODO add implementation
		}

        public void SaveDrawing()
		{
			// TODO add implementation
		}

        public void Redo()
		{
			// TODO add implementation
		}

        public void MouseClicked(int x, int y)
		{
			// TODO add implementation
		}

        public void ColorChanged(Color color)
		{
			// TODO add implementation
		}

        public void ChoosePaintingTool(PaintingTool paintingTool)
		{
			// TODO add implementation
		}

        public void Undo()
		{
			// TODO add implementation
		}

        public void LoadDrawing()
		{
			// TODO add implementation
		}
    }
}
