
public interface IView : EventDriver
{
	void Run();
	void SetPresenter();
	DrawingMemento GetDrawing();
}

