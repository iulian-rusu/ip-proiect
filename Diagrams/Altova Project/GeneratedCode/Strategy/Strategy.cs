
public abstract class Strategy
{
	private Color color;
	public abstract void Draw();
	internal abstract void MouseMoved(int x, int y);
	internal abstract void MouseClicked(int x, int y);
	internal abstract void IsDone();
	internal abstract void ColorChanged(Color color);
}

