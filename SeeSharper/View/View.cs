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
    /// Maximum width of the <code>pictureBox</code> and the contained image.
    /// </summary>
    private readonly int _maxWidth;
    /// <summary>
    /// Maximum height of the <code>pictureBox</code> and the contained image.
    /// </summary>
    private readonly int _maxHeight;
    /// <summary>
    /// Is true if this is currently displaying a dialog.
    /// 
    /// This fixes a Windows/C# in which a mouse event is sent to the form on
    /// dialog double click.
    /// </summary>
    private bool _displayingDialog = false;
    /// <summary>
    /// Holds a reference to the <code>PaintEvent</code> that is draw on top of
    /// the <code>Image</code> so that it can be removed from the pictureBox-es Paint Event.
    /// </summary>
    private PaintEventHandler _currentAddedPaintHandler = null;
    /// <summary>
    /// Holds a reference to the color button currently affected by color editing.
    /// </summary>
    private Button _selectedColorButton;
    /// <summary>
    /// Holds references to toolButtons to make selected highlighting
    /// algorithm easier to implement
    /// </summary>
    private readonly Button[] _toolButtons;
    #endregion
    #region Public Member Functions
    public View()
    {
      InitializeComponent();
      _maxWidth = pictureBox.Width;
      _maxHeight = pictureBox.Height;
      _selectedColorButton = borderColorButton;
      _toolButtons = new Button[]
      {
        eraserButton, brushButton, lineButton, circleButton, ellipseButton,
        rightTriangleButton, isoscelesTriangleButton, squareButton, 
        rectangleButton, rhombButton, pentagonButton, hexagonButton, 
        starButton, heartButton, arrowLeftButton, arrowRightButton, 
        arrowUpButton, arrowDownButton, textButton
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
      var newImage = (Image)drawingMemento.Drawing.Clone();
      var width = newImage.Width;
      if (width > _maxWidth)
      {
        width = _maxWidth;
      }
      var height = newImage.Height;
      if (height > _maxHeight)
      {
        height = _maxHeight;
      }
      pictureBox.Image = new Bitmap(width, height);
      // Copy the new image and crop if excedes _maxWidth or _maxHeight
      using (Graphics g = Graphics.FromImage(pictureBox.Image))
      {
        g.DrawImage(newImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
      }
      pictureBox.SetBounds(pictureBox.Bounds.X, pictureBox.Bounds.Y, width, height);
    }
    /// <summary>
    /// Encapsulates and returns the current image state of the picturebox
    /// </summary>
    /// <returns>Encapsulated image</returns>
    public DrawingMemento GetDrawingMemento()
    {
      string description = "";
      if (_presenter != null)
      {
        description = _presenter.GetCurrentStrategyDescription();
      }
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
      _displayingDialog = true;
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
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      Color color = colorDialog.Color;
      _selectedColorButton.BackColor = color;
      if (_selectedColorButton == borderColorButton)
      {
        _presenter.ColorChanged(color);
      }
      else
      {
        _presenter.FillColorChanged(color);
      }
    }
    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (_displayingDialog)
        return;
      _presenter.MouseMoved(e.X, e.Y);
    }
    private void PictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      if (_displayingDialog)
      {
        _displayingDialog = false;
      }
      _presenter.MouseStateChanged(e.X, e.Y);
    }
    private void PictureBox_MouseUp(object sender, MouseEventArgs e)
    {
      if (_displayingDialog)
        return;
      _presenter.MouseStateChanged(e.X, e.Y);
    }
    private void RedoButton_Click(object sender, EventArgs e)
    {
      Redo();
    }
    private void Redo()
    {
      _presenter.Redo();
    }
    private void UndoButton_Click(object sender, EventArgs e)
    {
      Undo();
    }
    private void Undo()
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
      foreach (var button in _toolButtons)
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
    private void StarButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(starButton);
      _presenter.ChoosePaintingTool(PaintingTool.Star, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void EraserButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(eraserButton);
      _presenter.ChoosePaintingTool(PaintingTool.Eraser, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void HeartButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(heartButton);
      _presenter.ChoosePaintingTool(PaintingTool.Heart, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void ArrowLeftButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(arrowLeftButton);
      _presenter.ChoosePaintingTool(PaintingTool.ArrowLeft, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void ArrowRightButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(arrowRightButton);
      _presenter.ChoosePaintingTool(PaintingTool.ArrowRight, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void ArrowUpButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(arrowUpButton);
      _presenter.ChoosePaintingTool(PaintingTool.ArrowUp, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void ArrowDownButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(arrowDownButton);
      _presenter.ChoosePaintingTool(PaintingTool.ArrowDown, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void PentagonButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(pentagonButton);
      _presenter.ChoosePaintingTool(PaintingTool.Pentagon, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void HexagonButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(hexagonButton);
      _presenter.ChoosePaintingTool(PaintingTool.Hexagon, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void RhombButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(rhombButton);
      _presenter.ChoosePaintingTool(PaintingTool.Rhomb, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void RightTriangleButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(rightTriangleButton);
      _presenter.ChoosePaintingTool(PaintingTool.RightTriangle, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void IsoscelesTriangleButton_Click(object sender, EventArgs e)
    {
      UpdateToolButtons(isoscelesTriangleButton);
      _presenter.ChoosePaintingTool(PaintingTool.IsoscelesTriangle, borderColorButton.BackColor, GetFillColor(), thicknessTrackBar.Value);
    }
    private void SaveButton_Click(object sender, EventArgs e)
    {
      SaveDrawing();
    }
    private void SaveDrawing()
    {
      try
      {
        _presenter.SaveDrawing();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void LoadButton_Click(object sender, EventArgs e)
    {
      LoadDrawing();
    }
    private void LoadDrawing()
    {
      try
      {
        _displayingDialog = true;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
          openFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
          openFileDialog.FilterIndex = 2;
          openFileDialog.RestoreDirectory = true;

          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            string filePath = openFileDialog.FileName;
            _presenter.LoadDrawing(filePath);
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Invalid save file name. More information:\n" + ex.Message);
      }
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      pictureBox.Refresh();
    }
    private void HelpButton_Click(object sender, EventArgs e)
    {
      ShowHelp();
    }
    private void ShowHelp()
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
        DialogResult res = MessageBox.Show("Save before exiting?", "Application Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        if (res == DialogResult.Yes)
        {
          SaveDrawing();
        }
        else if (res != DialogResult.No)
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
    private void View_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.H && e.Control)
      {
        ShowHelp();
      }
      else if (e.KeyCode == Keys.S && e.Control)
      {
        SaveDrawing();
      }
      else if (e.KeyCode == Keys.L && e.Control)
      {
        LoadDrawing();
      }
      else if (e.KeyCode == Keys.Z && e.Control)
      {
        Undo();
      }
      else if (e.KeyCode == Keys.Y && e.Control)
      {
        Redo();
      }
    }
    #endregion
  }
}
