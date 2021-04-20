using Memento;

namespace Shared
{
    public interface IView
    {
        void Run();
        void SetPresenter();
        DrawingMemento GetDrawingMemento();
    }
}
