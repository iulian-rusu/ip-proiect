namespace Model
{
    using Shared;
    using System.Collections.Generic;
    using Strategy;
    using Memento;
    using System.Drawing;

    public class Model : IModel
	{
		private string _saveFileName;
		private UndoStack _undoStack;
		private Dictionary<PaintingTool, Strategy> _strategies;

        public Strategy ColorChanged(Color color)
        {
            throw new System.NotImplementedException();
        }

        public Strategy GetPaintingStrategy(PaintingTool paitingTool)
        {
            throw new System.NotImplementedException();
        }

        public bool HasSaveFileName()
        {
            throw new System.NotImplementedException();
        }

        public DrawingMemento LoadDrawing(string filename)
        {
            throw new System.NotImplementedException();
        }

        public DrawingMemento Redo()
        {
            throw new System.NotImplementedException();
        }

        public void SaveDrawing(DrawingMemento drawingMemento)
        {
            throw new System.NotImplementedException();
        }

        public void SetSaveFileName(string saveFileName)
        {
            throw new System.NotImplementedException();
        }

        public DrawingMemento Undo()
        {
            throw new System.NotImplementedException();
        }
    }

}
