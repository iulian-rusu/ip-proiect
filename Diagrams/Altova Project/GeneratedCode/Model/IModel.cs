
public interface IModel
{
	void SaveDrawing(DrawingMemento drawingMemento);
	DrawingMemento LoadDrawing(string filename);
	bool HasSaveFileName();
	void SetSaveFileName(string saveFileName);
	void ChoosePaitingTool(PaintingTools paitingTool);
	Strategy MouseMoved(int x, int y);
	Strategy MouseClicked(int x, int y);
	Strategy ColorChanged(Color color);
	DrawingMemento Undo();
	DrawingMemento Redo();
}

