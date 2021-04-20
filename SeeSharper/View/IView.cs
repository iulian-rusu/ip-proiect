using Memento;

namespace View
{ 
	public interface IView
	{
		void Run();
		void SetPresenter();
		DrawingMemento GetDrawing();
	}
}
