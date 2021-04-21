using Strategy;
using System.Drawing;

namespace Shared
{
    public interface IPresenter
    {
        void SaveDrawing();
        bool Exit();
        void LoadDrawing(string filename);
        void ChoosePaintingTool(PaintingTool paintingTool);
        void MouseMoved(int x, int y);
        void MouseClicked(int x, int y);
        void Undo();
        void Redo();
        void LoadHelp();
        void ColorChanged(Color color);
    }
}
