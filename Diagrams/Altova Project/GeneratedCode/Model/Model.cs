
public class Model : IModel
{
	private Nullable<string> _saveFileName;
	private UndoStack _undoStack;
	private StrategyHandler _strategyHandler;
	void IModel.SaveDrawing(DrawingMemento drawingMemento)
	{
		// TODO add implementation
	}
	bool IModel.HasSaveFileName()
	{
		// TODO add implementation and return statement
	}
	void IModel.ChoosePaitingTool(PaintingTools paitingTool)
	{
		// TODO add implementation
	}
	DrawingMemento IModel.LoadDrawing(string filename)
	{
		// TODO add implementation and return statement
	}
	void IModel.SetSaveFileName(string saveFileName)
	{
		// TODO add implementation
	}
	Strategy IModel.ColorChanged(Color color)
	{
		// TODO add implementation and return statement
	}
	DrawingMemento IModel.Undo()
	{
		// TODO add implementation and return statement
	}
	Strategy IModel.MouseMoved(int x, int y)
	{
		// TODO add implementation and return statement
	}
	Strategy IModel.MouseClicked(int x, int y)
	{
		// TODO add implementation and return statement
	}
	DrawingMemento IModel.Redo()
	{
		// TODO add implementation and return statement
	}
}

