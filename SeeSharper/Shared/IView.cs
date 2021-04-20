using Memento;

namespace Shared
{
  using Strategy;
  public interface IView
  {
    void SetPresenter(IPresenter presenter);
    void CaptureDrawingState();
    void SetDrawingMemento(DrawingMemento drawingMemento);
    DrawingMemento GetDrawingMemento();
    void ChangeCurrentHandler(Strategy strategy);
    void AddHandler(Strategy strategy);
    void RemoveCurrentHandler();
  }
}
