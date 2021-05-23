/**************************************************************************
 *                                                                        *
 *  File:        IModel.cs                                                *
 *  Copyright:   (c) 2021, Baltariu Ionut-Alexandru                       *
 *  E-mail:      ionut-alexandru.baltariu@student.tuiasi.ro               *
 *  Description: Interface for the Model class of the                     *
 *               Model-View-Presenter architecture.c                      *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

namespace Shared
{
    using Memento;
    using Strategy;
    using System.Drawing;

    /// <summary>
    /// Interface for the Model Class of the MVP architecture -
    /// It contains the data, state and logic of the application.
    /// </summary>
    public interface IModel
    {
        void SaveDrawing(DrawingMemento drawingMemento);
        DrawingMemento LoadDrawing(string filename);
        bool HasSaveFileName();
        void SetSaveFileName(string saveFileName);
        Strategy GetPaintingStrategy(PaintingTool paitingTool);
        DrawingMemento Undo();
        DrawingMemento Redo();
        void AddMemento(DrawingMemento memento);
        string GetNextUndoDescription();
        string GetNextRedoDescription();
        void DropMementos();
    }
}
