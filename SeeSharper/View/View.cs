/**************************************************************************
 *                                                                        *
 *  File:        View.cs                                                  *
 *  Copyright:   (c) 2021, Beldiman Vladislav                             *
 *  E-mail:      vladislav.beldiman@student.tuiasi.ro                     *
 *  Description: The view implementation of the Model-View-Presenter      *
 *               architecture.                                            *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Memento;
using Shared;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
  using Strategy;
  /// <summary>
  /// View component of the MVP architecture.
  /// </summary>
  public partial class View : Form, IView
  {
    #region Private Members
    private IPresenter _presenter;
    /// <summary>
    /// Holds a reference to the <code>PaintEvent</code> that is draw on top of
    /// the <code>Image</code> so that it can be removed from the pictureBox-es Paint Event.
    /// </summary>
    private PaintEventHandler _currentAddedPaintHandler = null;
    private Button _selectedColorButton;
    /// <summary>
    /// Holds references to toolButtons to make selected highlighting
    /// algorithm easier to implement
    /// </summary>
    private readonly Button[] toolButtons;
    #endregion
    #region Public Member Functions
    public View()
    {
      InitializeComponent();
      _selectedColorButton = borderColorButton;
      toolButtons = new Button[]
      {
        brushButton, lineButton, squareButton, rectangleButton,
        circleButton, ellipseButton
      };
    }
    /// <summary>
    /// Set presenter and send it initial tool
    /// </summary>
    /// <param name="presenter">Presenter associated with this View</param>
    public void SetPresenter(IPresenter presenter)
    {
      _presenter = presenter;
      InitPresenter();
    }
    /// <summary>
    /// Merges the currentPaintEvent modifications into the Image
    /// </summary>
    public void CaptureDrawingState()
    {
      using (Graphics g = Graphics.FromImage(pictureBox.Image))
      {
        _currentAddedPaintHandler((object)this, new PaintEventArgs(g, new Rectangle(new Point(0, 0), pictureBox.Size)));
      }
    }
    /// <summary>
    /// Changes the current image
    /// </summary>
    /// <param name="drawingMemento">New encapsulated image</param>
    public void SetDrawingMemento(DrawingMemento drawingMemento)
    {
      pictureBox.Image = drawingMemento.Drawing;
    }
    /// <summary>
    /// Encapsulates and returns the current image state of the picturebox
    /// </summary>
    /// <returns>Encapsulated image</returns>
    public DrawingMemento GetDrawingMemento()
    {
      var description = _presenter.GetCurrentStrategyDescription();
      return new DrawingMemento((Image)pictureBox.Image.Clone(), description);
    }
    /// <summary>
    /// Removes the old AddedPaintHandler to the pictureBox.Paint event and adds
    /// the one encapsulated in the strategy.
    /// </summary>
    /// <param name="strategy">New strategy encapsulating a PaintHandler</param>
    public void ChangeCurrentHandler(Strategy strategy)
    {
      pictureBox.Paint -= _currentAddedPaintHandler;
      _currentAddedPaintHandler = strategy.GetDraw();
      pictureBox.Paint += _currentAddedPaintHandler;
    }
    /// <summary>
    /// Display dialog box and return chosen file
    /// </summary>
    /// <returns></returns>
    public string GetSaveFileName()
    {
      using (var saveFileDialog = new SaveFileDialog())
      {
        saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          return saveFileDialog.FileName;
        }
        else
        {
          return "";
        }
      }
    }
    /// <summary>
    /// Set description in undo text box
    /// </summary>
    /// <param name="description">Next undoable action</param>
    public void SetUndo(string description)
    {
      undoTextBox.Text = description;
      if (description == "")
      {
        undoButton.Enabled = false;
      }
      else
      {
        undoButton.Enabled = true;
      }
    }
    /// <summary>
    /// Set description in redo text box
    /// </summary>
    /// <param name="description">Next redoable action</param>
    public void SetRedo(string description)
    {
      redoTextBox.Text = description;
      if (description == "")
      {
        redoButton.Enabled = false;
      }
      else
      {
        redoButton.Enabled = true;
      }
    }
    #endregion
    #region Private Member Functions
    /// <summary>
    /// Sets initial <code>Presenter</code> state.
    /// </summary>
    private void InitPresenter()
    {
      _presenter.ChoosePaintingTool(PaintingTool.Line, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void BorderColorButton_Click(object sender, EventArgs e)
    {
      fillColorButton.FlatStyle = FlatStyle.Standard;
      borderColorButton.FlatStyle = FlatStyle.Popup;
      _selectedColorButton = borderColorButton;
    }

    private void FillColorButton_Click(object sender, EventArgs e)
    {
      fillColorButton.FlatStyle = FlatStyle.Popup;
      borderColorButton.FlatStyle = FlatStyle.Standard;
      _selectedColorButton = fillColorButton;
    }
    private void EditColorButton_Click(object sender, EventArgs e)
    {

    }

    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      _presenter.MouseMoved(e.X, e.Y);
    }

    private void PictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      _presenter.MouseStateChanged(e.X, e.Y);
    }

    private void PictureBox_MouseUp(object sender, MouseEventArgs e)
    {
      _presenter.MouseStateChanged(e.X, e.Y);
    }

    private void RedoButton_Click(object sender, EventArgs e)
    {
      _presenter.Redo();
    }

    private void UndoButton_Click(object sender, EventArgs e)
    {
      _presenter.Undo();
    }
    /// <summary>
    /// Highlights the currently selected tool button by giving it a different
    /// flat style from the others.
    /// </summary>
    /// <param name="selected">Button to highlight</param>
    private void UpdateToolButtons(Button selected)
    {
      foreach (var button in toolButtons)
      {
        if (button == selected)
        {
          button.FlatStyle = FlatStyle.Popup;
        }
        else
        {
          button.FlatStyle = FlatStyle.Standard;
        }
      }
    }
    private void BrushButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(brushButton);
      _presenter.ChoosePaintingTool(PaintingTool.Brush, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void LineButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(lineButton);
      _presenter.ChoosePaintingTool(PaintingTool.Line, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void SquareButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(squareButton);
      _presenter.ChoosePaintingTool(PaintingTool.Square, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void RectangleButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(rectangleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Rectangle, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void CircleButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(circleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Circle, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void EllipseButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(ellipseButton);
      _presenter.ChoosePaintingTool(PaintingTool.Ellipse, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void TextButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(textButton);
      _presenter.ChoosePaintingTool(PaintingTool.Text, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }

    private void PolygonButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(polygonButton);
      _presenter.ChoosePaintingTool(PaintingTool.Polygon, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void SaveButton_Click(object sender, EventArgs e)
    {
      _presenter.SaveDrawing();
    }
    private void LoadButton_Click(object sender, EventArgs e)
    {

    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      pictureBox.Refresh();
    }
    private void HelpButton_Click(object sender, EventArgs e)
    {
      // TODO LOAD HELP.CHM
      MessageBox.Show("Help", "Help");
    }
    /// <summary>
    /// Called to show a dialog box for exit confirmation
    /// </summary>
    private void View_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        DialogResult res = MessageBox.Show("Exit application?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (res != DialogResult.OK)
        {
          e.Cancel = true;
        }
      }
    }
    private void FillCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _presenter.FillColorChanged(GetFillColor());
    }
    private Color GetFillColor()
    {
      if (fillCheckBox.Checked)
      {
        return fillColorButton.BackColor;
      }
      else
      {
        return Color.Transparent;
      }
    }

    private void ThicknessTrackBar_Scroll(object sender, EventArgs e)
    {
      _presenter.ThicknessChanged(thicknessTrackBar.Value);
    }
    #endregion
  }
}
