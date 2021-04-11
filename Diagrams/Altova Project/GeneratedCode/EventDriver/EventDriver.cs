
public interface EventDriver
{
	void SaveDrawing();
	void Exit();
	void LoadDrawing();
	void ChoosePaintingTool(PaintingTools paintingTool);
	void MouseMoved(int x, int y);
	void MouseClicked(int x, int y);
	void Undo();
	void Redo();
	void LoadHelp();
	void ColorChanged(Color color);
}

