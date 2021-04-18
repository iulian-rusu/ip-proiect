
public class Form : IView
{
	private Image _drawing;
	private IView _view;
	private PaintEventHandler _currentAddedPaintHandler;
	private IPresenter _presenter;
	public void SetDrawingMemento(DrawingMemento drawingMemento)
	{
		// TODO add implementation
	}
	public DrawingMemento GetDrawingMemento()
	{
		// TODO add implementation and return statement
	}
	public void ChangeCurrentHandler(Strategy strategy)
	{
		// TODO add implementation
	}
	public void AddHandler(Strategy strategy)
	{
		// TODO add implementation
	}
	public void RemoveCurrentHandler()
	{
		// TODO add implementation
	}
	public void CaptureDrawingState()
	{
		// TODO add implementation
	}
	private void MouseMoved(EventArgs e)
	{
		// TODO add implementation
	}
}

