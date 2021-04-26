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
    private Image _drawing;
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
      _drawing = pictureBox.Image;
      _selectedColorButton = colorButton1;
      toolButtons = new Button[]
      {
        brushButton, lineButton, squareButton, rectangleButton,
        circleButton, ellipseButton
      };
      _drawing = new Image();
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
      _drawing = pictureBox.Image;
    }
    public void SetDrawingMemento(DrawingMemento drawingMemento)
    {
      _drawing = drawingMemento.Drawing;
    }
    public DrawingMemento GetDrawingMemento()
    {
      return new DrawingMemento(_drawing);
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
    #endregion
    #region Private Member Functions
    /// <summary>
    /// Sets initial <code>Presenter</code> state.
    /// </summary>
    private void InitPresenter()
    {
      _presenter.ChoosePaintingTool(PaintingTool.Line);
      _presenter.ColorChanged(colorButton1.BackColor);
    }
    //pictureBox.Image = _drawing;
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
      _presenter.ChoosePaintingTool(PaintingTool.Brush);
    }
    private void lineButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(lineButton);
      _presenter.ChoosePaintingTool(PaintingTool.Line);
    }

    private void squareButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(squareButton);
      _presenter.ChoosePaintingTool(PaintingTool.Square);
    }

    private void rectangleButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(rectangleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Rectangle);
    }

    private void circleButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(circleButton);
      _presenter.ChoosePaintingTool(PaintingTool.Circle);
    }

    private void ellipseButton_Click(object sender, EventArgs e)
    {
      updateToolButtons(ellipseButton);
      _presenter.ChoosePaintingTool(PaintingTool.Ellipse);
    }
    private void saveButton_Click(object sender, EventArgs e)
    {
      _presenter.SaveDrawing();
    }

    private void saveAsButton_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException("Save as has no support yet");
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
    #endregion

    private void pictureBox_Paint(object sender, PaintEventArgs e)
    {
      pictureBox.Image = _drawing;
      using (Graphics g = Graphics.FromImage(_drawing))
      {
        g.DrawLine(Pens.Black, new Point(100, 100), new Point(200, 200));
      }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      pictureBox.Refresh();
    }
  }
}
