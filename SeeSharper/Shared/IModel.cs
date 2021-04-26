namespace Shared
{
    using Memento;
    using Strategy;
    using System.Drawing;

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
    }
}
