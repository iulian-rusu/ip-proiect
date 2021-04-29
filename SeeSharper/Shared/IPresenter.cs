/**************************************************************************
 *                                                                        *
 *  File:        IPresenter.cs                                            *
 *  Copyright:   (c) 2021, Rusu Iulian                                    *
 *  E-mail:      iulian.rusu@student.tuiasi.ro                            *
 *  Description: The presenter interface for the Model-View-Presenter     *
 *               architecture.                                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


using Strategy;
using System.Drawing;

namespace Shared
{
    /// <summary>
    /// IPresenter - defines an interface for interacting with any presenter implementation
    /// </summary>
    public interface IPresenter
    {
        void SaveDrawing();
        void LoadDrawing(string filename);
        void ChoosePaintingTool(PaintingTool paintingTool, Color borderColor, Color fillColor);
        void MouseMoved(int x, int y);
        void MouseStateChanged(int x, int y);
        void Undo();
        void Redo();
        void ColorChanged(Color color);
        void FillColorChanged(Color color);
        void ThicknessChanged(float thickness);
        string GetCurrentStrategyDescription();
    }
}
