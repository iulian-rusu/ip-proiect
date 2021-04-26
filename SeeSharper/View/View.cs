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
      _selectedColorButton = colorButton1;
      toolButtons = new Button[]
      {
        brushButton, lineButton, squareButton, rectangleButton,
        circleButton, ellipseButton
      };
    }
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
      return new DrawingMemento(pictureBox.Image);
    }
    public void ChangeCurrentHandler(Strategy strategy)
    {
      RemoveCurrentHandler();
      AddHandler(strategy);
    }
    public void AddHandler(Strategy strategy)
    {
      _currentAddedPaintHandler = strategy.GetDraw();
      pictureBox.Paint += _currentAddedPaintHandler;
    }
    public void RemoveCurrentHandler()
    {
      pictureBox.Paint -= _currentAddedPaintHandler;
    }
    public string GetSaveFileName()
    {
      return "img.png";
    }
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
      _presenter.ChoosePaintingTool(PaintingTool.Line, colorButton1.BackColor);
      _presenter.ColorChanged(colorButton1.BackColor);
    }
    private void colorButton1_Click(object sender, EventArgs e)
    {
      colorButton1.FlatStyle = FlatStyle.Popup;
      colorButton2.FlatStyle = FlatStyle.Standard;
      colorButton3.FlatStyle = FlatStyle.Standard;
      _selectedColorButton = colorButton1;
      _presenter.ColorChanged(_selectedColorButton.BackColor);
    }

    private void colorButton2_Click(object sender, EventArgs e)
    {
      colorButton1.FlatStyle = FlatStyle.Standard;
      colorButton2.FlatStyle = FlatStyle.Popup;
      colorButton3.FlatStyle = FlatStyle.Standard;
      _selectedColorButton = colorButton2;
      _presenter.ColorChanged(_selectedColorButton.BackColor);
    }

    private void colorButton3_Click(object sender, EventArgs e)
    {
      colorButton1.FlatStyle = FlatStyle.Standard;
      colorButton2.FlatStyle = FlatStyle.Standard;
      colorButton3.FlatStyle = FlatStyle.Popup;
      _selectedColorButton = colorButton3;
      _presenter.ColorChanged(_selectedColorButton.BackColor);
    }

    private void editColorButton_Click(object sender, EventArgs e)
    {
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;

      Color color = colorDialog.Color;
      _selectedColorButton.BackColor = color;
      _presenter.ColorChanged(color);
    }

    private void pictureBox_MouseClick(object sender, MouseEventArgs e)
    {
      _presenter.MouseClicked(e.X, e.Y);
    }

    private void pictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      _presenter.MouseMoved(e.X, e.Y);
    }

    private void redoButton_Click(object sender, EventArgs e)
    {
      _presenter.Redo();
    }

    private void undoButton_Click(object sender, EventArgs e)
    {
      _presenter.Undo();
    }
    /// <summary>
    /// Highlights the currently selected tool button by giving it a different
    /// flat style from the others.
    /// </summary>
    /// <param name="selected">Button to highlight</param>
    private void updateToolButtons(Button selected)
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
    private void brushButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(brushButton);
      _presenter.ChoosePaintingTool(PaintingTool.Brush, _selectedColorButton.BackColor);
    }
    private void lineButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(lineButton);
      _presenter.ChoosePaintingTool(PaintingTool.Line, _selectedColorButton.BackColor);
    }

    private void squareButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(squareButton);
      _presenter.ChoosePaintingTool(PaintingTool.Square, _selectedColorButton.BackColor);
    }

    private void rectangleButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(rectangleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Rectangle, _selectedColorButton.BackColor);
    }

    private void circleButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(circleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Circle, _selectedColorButton.BackColor);
    }

    private void ellipseButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(ellipseButton);
      _presenter.ChoosePaintingTool(PaintingTool.Ellipse, _selectedColorButton.BackColor);
    }
    private void saveButton_Click(object sender, EventArgs e)
    {
      _presenter.SaveDrawing();
    }
    private void loadButton_Click(object sender, EventArgs e)
    {
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
    private void timer_Tick(object sender, EventArgs e)
    {
      pictureBox.Refresh();
    }
    /// <summary>
    /// Called to show a help box for the user
    /// </summary>
    public void LoadHelp()
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
    #endregion
  }
}
