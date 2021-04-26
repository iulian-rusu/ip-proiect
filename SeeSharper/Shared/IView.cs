/**************************************************************************
 *                                                                        *
 *  File:        View.cs                                                  *
 *  Copyright:   (c) 2021, Beldiman Vladislav                             *
 *  E-mail:      vladislav.beldiman@student.tuiasi.ro                     *
 *  Description: The view interface of the Model-View-Presenter           *
 *               architecture.                                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

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
