
public interface IModel
{
	void SaveDrawing(DrawingMemento drawingMemento);
	DrawingMemento LoadDrawing(string filename);
	bool HasSaveFileName();
	void SetSaveFileName(string saveFileName);
	Strategy GetPaintingStrategy(PaintingTool paitingTool);
	Strategy ColorChanged(Color color);
	DrawingMemento Undo();
	DrawingMemento Redo();
}

