using Strategy;
using System.Drawing;

namespace Shared
{
    public interface IPresenter
    {
        void SaveDrawing();

        void LoadDrawing(string filename);
        void ChoosePaintingTool(PaintingTool paintingTool, Color selecteColor);
        void MouseMoved(int x, int y);
        void MouseClicked(int x, int y);
        void Undo();
        void Redo();
        void ColorChanged(Color color);
    }
}
