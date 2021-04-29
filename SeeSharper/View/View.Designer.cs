
namespace View
{
  partial class View
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
      this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.undoRedoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.undoGroupBox = new System.Windows.Forms.GroupBox();
      this.undoTextBox = new System.Windows.Forms.TextBox();
      this.undoButton = new System.Windows.Forms.Button();
      this.redoGroupBox = new System.Windows.Forms.GroupBox();
      this.redoTextBox = new System.Windows.Forms.TextBox();
      this.redoButton = new System.Windows.Forms.Button();
      this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.toolsAndShapesLabel = new System.Windows.Forms.Label();
      this.saveLoadGroupBox = new System.Windows.Forms.GroupBox();
      this.helpButton = new System.Windows.Forms.Button();
      this.loadButton = new System.Windows.Forms.Button();
      this.saveButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.editColorLabel = new System.Windows.Forms.Label();
      this.borderColorButton = new System.Windows.Forms.Button();
      this.fillColorButton = new System.Windows.Forms.Button();
      this.borderColorLabel = new System.Windows.Forms.Label();
      this.fillColorLabel = new System.Windows.Forms.Label();
      this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
      this.fillCheckBox = new System.Windows.Forms.CheckBox();
      this.thicknessLabel = new System.Windows.Forms.Label();
      this.thicknessTrackBar = new System.Windows.Forms.TrackBar();
      this.colorDialog = new System.Windows.Forms.ColorDialog();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.brushButton = new System.Windows.Forms.Button();
      this.lineButton = new System.Windows.Forms.Button();
      this.squareButton = new System.Windows.Forms.Button();
      this.rectangleButton = new System.Windows.Forms.Button();
      this.circleButton = new System.Windows.Forms.Button();
      this.ellipseButton = new System.Windows.Forms.Button();
      this.polygonButton = new System.Windows.Forms.Button();
      this.textButton = new System.Windows.Forms.Button();
      this.editColorButton = new System.Windows.Forms.Button();
      this.mainTableLayoutPanel.SuspendLayout();
      this.undoRedoTableLayoutPanel.SuspendLayout();
      this.undoGroupBox.SuspendLayout();
      this.redoGroupBox.SuspendLayout();
      this.flowLayoutPanel.SuspendLayout();
      this.saveLoadGroupBox.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.propertiesGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.thicknessTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // mainTableLayoutPanel
      // 
      this.mainTableLayoutPanel.ColumnCount = 5;
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.4F));
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.6F));
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
      this.mainTableLayoutPanel.Controls.Add(this.undoRedoTableLayoutPanel, 3, 0);
      this.mainTableLayoutPanel.Controls.Add(this.flowLayoutPanel, 0, 0);
      this.mainTableLayoutPanel.Controls.Add(this.saveLoadGroupBox, 4, 0);
      this.mainTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 2, 0);
      this.mainTableLayoutPanel.Controls.Add(this.propertiesGroupBox, 1, 0);
      this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
      this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
      this.mainTableLayoutPanel.RowCount = 1;
      this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainTableLayoutPanel.Size = new System.Drawing.Size(1584, 100);
      this.mainTableLayoutPanel.TabIndex = 0;
      // 
      // undoRedoTableLayoutPanel
      // 
      this.undoRedoTableLayoutPanel.ColumnCount = 1;
      this.undoRedoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.undoRedoTableLayoutPanel.Controls.Add(this.undoGroupBox, 0, 0);
      this.undoRedoTableLayoutPanel.Controls.Add(this.redoGroupBox, 0, 1);
      this.undoRedoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.undoRedoTableLayoutPanel.Location = new System.Drawing.Point(1047, 3);
      this.undoRedoTableLayoutPanel.Name = "undoRedoTableLayoutPanel";
      this.undoRedoTableLayoutPanel.RowCount = 2;
      this.undoRedoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.undoRedoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.undoRedoTableLayoutPanel.Size = new System.Drawing.Size(469, 94);
      this.undoRedoTableLayoutPanel.TabIndex = 2;
      // 
      // undoGroupBox
      // 
      this.undoGroupBox.Controls.Add(this.undoTextBox);
      this.undoGroupBox.Controls.Add(this.undoButton);
      this.undoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.undoGroupBox.Location = new System.Drawing.Point(3, 3);
      this.undoGroupBox.Name = "undoGroupBox";
      this.undoGroupBox.Size = new System.Drawing.Size(463, 41);
      this.undoGroupBox.TabIndex = 0;
      this.undoGroupBox.TabStop = false;
      this.undoGroupBox.Text = "Undo";
      // 
      // undoTextBox
      // 
      this.undoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.undoTextBox.Location = new System.Drawing.Point(3, 16);
      this.undoTextBox.Name = "undoTextBox";
      this.undoTextBox.ReadOnly = true;
      this.undoTextBox.Size = new System.Drawing.Size(382, 20);
      this.undoTextBox.TabIndex = 0;
      // 
      // undoButton
      // 
      this.undoButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.undoButton.Enabled = false;
      this.undoButton.Location = new System.Drawing.Point(385, 16);
      this.undoButton.Name = "undoButton";
      this.undoButton.Size = new System.Drawing.Size(75, 22);
      this.undoButton.TabIndex = 0;
      this.undoButton.Text = "Undo";
      this.undoButton.UseVisualStyleBackColor = true;
      this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
      // 
      // redoGroupBox
      // 
      this.redoGroupBox.Controls.Add(this.redoTextBox);
      this.redoGroupBox.Controls.Add(this.redoButton);
      this.redoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.redoGroupBox.Location = new System.Drawing.Point(3, 50);
      this.redoGroupBox.Name = "redoGroupBox";
      this.redoGroupBox.Size = new System.Drawing.Size(463, 41);
      this.redoGroupBox.TabIndex = 1;
      this.redoGroupBox.TabStop = false;
      this.redoGroupBox.Text = "Redo";
      // 
      // redoTextBox
      // 
      this.redoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.redoTextBox.Location = new System.Drawing.Point(3, 16);
      this.redoTextBox.Name = "redoTextBox";
      this.redoTextBox.ReadOnly = true;
      this.redoTextBox.Size = new System.Drawing.Size(382, 20);
      this.redoTextBox.TabIndex = 1;
      // 
      // redoButton
      // 
      this.redoButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.redoButton.Enabled = false;
      this.redoButton.Location = new System.Drawing.Point(385, 16);
      this.redoButton.Name = "redoButton";
      this.redoButton.Size = new System.Drawing.Size(75, 22);
      this.redoButton.TabIndex = 0;
      this.redoButton.Text = "Redo";
      this.redoButton.UseVisualStyleBackColor = true;
      this.redoButton.Click += new System.EventHandler(this.RedoButton_Click);
      // 
      // flowLayoutPanel
      // 
      this.flowLayoutPanel.Controls.Add(this.toolsAndShapesLabel);
      this.flowLayoutPanel.Controls.Add(this.brushButton);
      this.flowLayoutPanel.Controls.Add(this.lineButton);
      this.flowLayoutPanel.Controls.Add(this.squareButton);
      this.flowLayoutPanel.Controls.Add(this.rectangleButton);
      this.flowLayoutPanel.Controls.Add(this.circleButton);
      this.flowLayoutPanel.Controls.Add(this.ellipseButton);
      this.flowLayoutPanel.Controls.Add(this.polygonButton);
      this.flowLayoutPanel.Controls.Add(this.textButton);
      this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel.Name = "flowLayoutPanel";
      this.flowLayoutPanel.Size = new System.Drawing.Size(627, 94);
      this.flowLayoutPanel.TabIndex = 0;
      // 
      // toolsAndShapesLabel
      // 
      this.toolsAndShapesLabel.AutoSize = true;
      this.toolsAndShapesLabel.Location = new System.Drawing.Point(3, 0);
      this.toolsAndShapesLabel.Name = "toolsAndShapesLabel";
      this.toolsAndShapesLabel.Size = new System.Drawing.Size(93, 13);
      this.toolsAndShapesLabel.TabIndex = 6;
      this.toolsAndShapesLabel.Text = "Tools and Shapes";
      // 
      // saveLoadGroupBox
      // 
      this.saveLoadGroupBox.Controls.Add(this.helpButton);
      this.saveLoadGroupBox.Controls.Add(this.loadButton);
      this.saveLoadGroupBox.Controls.Add(this.saveButton);
      this.saveLoadGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
      this.saveLoadGroupBox.Location = new System.Drawing.Point(1522, 3);
      this.saveLoadGroupBox.Name = "saveLoadGroupBox";
      this.saveLoadGroupBox.Size = new System.Drawing.Size(59, 94);
      this.saveLoadGroupBox.TabIndex = 3;
      this.saveLoadGroupBox.TabStop = false;
      this.saveLoadGroupBox.Text = "File";
      // 
      // helpButton
      // 
      this.helpButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpButton.Location = new System.Drawing.Point(3, 62);
      this.helpButton.Name = "helpButton";
      this.helpButton.Size = new System.Drawing.Size(53, 23);
      this.helpButton.TabIndex = 3;
      this.helpButton.Text = "Help";
      this.helpButton.UseVisualStyleBackColor = true;
      this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // loadButton
      // 
      this.loadButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.loadButton.Location = new System.Drawing.Point(3, 39);
      this.loadButton.Name = "loadButton";
      this.loadButton.Size = new System.Drawing.Size(53, 23);
      this.loadButton.TabIndex = 2;
      this.loadButton.Text = "Load";
      this.loadButton.UseVisualStyleBackColor = true;
      this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
      // 
      // saveButton
      // 
      this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
      this.saveButton.Location = new System.Drawing.Point(3, 16);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(53, 23);
      this.saveButton.TabIndex = 0;
      this.saveButton.Text = "Save";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.Controls.Add(this.editColorLabel, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.borderColorButton, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.fillColorButton, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.editColorButton, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.borderColorLabel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.fillColorLabel, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(800, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.02128F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.97872F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 94);
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // editColorLabel
      // 
      this.editColorLabel.AutoSize = true;
      this.editColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editColorLabel.Location = new System.Drawing.Point(163, 0);
      this.editColorLabel.Name = "editColorLabel";
      this.editColorLabel.Size = new System.Drawing.Size(75, 16);
      this.editColorLabel.TabIndex = 6;
      this.editColorLabel.Text = "Edit Color";
      this.editColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // borderColorButton
      // 
      this.borderColorButton.BackColor = System.Drawing.Color.Lime;
      this.borderColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.borderColorButton.Location = new System.Drawing.Point(3, 19);
      this.borderColorButton.Name = "borderColorButton";
      this.borderColorButton.Size = new System.Drawing.Size(74, 72);
      this.borderColorButton.TabIndex = 1;
      this.borderColorButton.UseVisualStyleBackColor = false;
      this.borderColorButton.Click += new System.EventHandler(this.BorderColorButton_Click);
      // 
      // fillColorButton
      // 
      this.fillColorButton.BackColor = System.Drawing.Color.Red;
      this.fillColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fillColorButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.fillColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.fillColorButton.Location = new System.Drawing.Point(83, 19);
      this.fillColorButton.Name = "fillColorButton";
      this.fillColorButton.Size = new System.Drawing.Size(74, 72);
      this.fillColorButton.TabIndex = 0;
      this.fillColorButton.UseVisualStyleBackColor = false;
      this.fillColorButton.Click += new System.EventHandler(this.FillColorButton_Click);
      // 
      // borderColorLabel
      // 
      this.borderColorLabel.AutoSize = true;
      this.borderColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.borderColorLabel.Location = new System.Drawing.Point(3, 0);
      this.borderColorLabel.Name = "borderColorLabel";
      this.borderColorLabel.Size = new System.Drawing.Size(74, 16);
      this.borderColorLabel.TabIndex = 4;
      this.borderColorLabel.Text = "Border Color";
      this.borderColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // fillColorLabel
      // 
      this.fillColorLabel.AutoSize = true;
      this.fillColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fillColorLabel.Location = new System.Drawing.Point(83, 0);
      this.fillColorLabel.Name = "fillColorLabel";
      this.fillColorLabel.Size = new System.Drawing.Size(74, 16);
      this.fillColorLabel.TabIndex = 5;
      this.fillColorLabel.Text = "Fill Color";
      this.fillColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // propertiesGroupBox
      // 
      this.propertiesGroupBox.Controls.Add(this.fillCheckBox);
      this.propertiesGroupBox.Controls.Add(this.thicknessLabel);
      this.propertiesGroupBox.Controls.Add(this.thicknessTrackBar);
      this.propertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertiesGroupBox.Location = new System.Drawing.Point(636, 3);
      this.propertiesGroupBox.Name = "propertiesGroupBox";
      this.propertiesGroupBox.Size = new System.Drawing.Size(158, 94);
      this.propertiesGroupBox.TabIndex = 5;
      this.propertiesGroupBox.TabStop = false;
      // 
      // fillCheckBox
      // 
      this.fillCheckBox.AutoSize = true;
      this.fillCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.fillCheckBox.Location = new System.Drawing.Point(3, 74);
      this.fillCheckBox.Name = "fillCheckBox";
      this.fillCheckBox.Size = new System.Drawing.Size(152, 17);
      this.fillCheckBox.TabIndex = 9;
      this.fillCheckBox.Text = "Fill";
      this.fillCheckBox.UseVisualStyleBackColor = true;
      this.fillCheckBox.CheckedChanged += new System.EventHandler(this.FillCheckBox_CheckedChanged);
      // 
      // thicknessLabel
      // 
      this.thicknessLabel.AutoSize = true;
      this.thicknessLabel.Dock = System.Windows.Forms.DockStyle.Top;
      this.thicknessLabel.Location = new System.Drawing.Point(3, 16);
      this.thicknessLabel.Name = "thicknessLabel";
      this.thicknessLabel.Size = new System.Drawing.Size(56, 13);
      this.thicknessLabel.TabIndex = 8;
      this.thicknessLabel.Text = "Thickness";
      this.thicknessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // thicknessTrackBar
      // 
      this.thicknessTrackBar.Location = new System.Drawing.Point(0, 32);
      this.thicknessTrackBar.Minimum = 1;
      this.thicknessTrackBar.Name = "thicknessTrackBar";
      this.thicknessTrackBar.Size = new System.Drawing.Size(158, 45);
      this.thicknessTrackBar.TabIndex = 5;
      this.thicknessTrackBar.Value = 1;
      this.thicknessTrackBar.Scroll += new System.EventHandler(this.ThicknessTrackBar_Scroll);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 10;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.Color.White;
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Image = global::View.Properties.Resources.Background;
      this.pictureBox.Location = new System.Drawing.Point(0, 100);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(1584, 661);
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
      this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
      this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
      // 
      // brushButton
      // 
      this.brushButton.BackgroundImage = global::View.Properties.Resources.BrushButtonBackground;
      this.brushButton.Location = new System.Drawing.Point(102, 3);
      this.brushButton.Name = "brushButton";
      this.brushButton.Size = new System.Drawing.Size(32, 32);
      this.brushButton.TabIndex = 0;
      this.brushButton.UseVisualStyleBackColor = true;
      this.brushButton.Click += new System.EventHandler(this.BrushButton_Click);
      // 
      // lineButton
      // 
      this.lineButton.BackgroundImage = global::View.Properties.Resources.LineButtonBackground;
      this.lineButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.lineButton.Location = new System.Drawing.Point(140, 3);
      this.lineButton.Name = "lineButton";
      this.lineButton.Size = new System.Drawing.Size(32, 32);
      this.lineButton.TabIndex = 1;
      this.lineButton.UseVisualStyleBackColor = true;
      this.lineButton.Click += new System.EventHandler(this.LineButton_Click);
      // 
      // squareButton
      // 
      this.squareButton.BackgroundImage = global::View.Properties.Resources.SquareButtonBackground;
      this.squareButton.Location = new System.Drawing.Point(178, 3);
      this.squareButton.Name = "squareButton";
      this.squareButton.Size = new System.Drawing.Size(32, 32);
      this.squareButton.TabIndex = 2;
      this.squareButton.UseVisualStyleBackColor = true;
      this.squareButton.Click += new System.EventHandler(this.SquareButton_Click);
      // 
      // rectangleButton
      // 
      this.rectangleButton.BackgroundImage = global::View.Properties.Resources.RectangleButtonBackground;
      this.rectangleButton.Location = new System.Drawing.Point(216, 3);
      this.rectangleButton.Name = "rectangleButton";
      this.rectangleButton.Size = new System.Drawing.Size(32, 32);
      this.rectangleButton.TabIndex = 3;
      this.rectangleButton.UseVisualStyleBackColor = true;
      this.rectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
      // 
      // circleButton
      // 
      this.circleButton.BackgroundImage = global::View.Properties.Resources.CircleButtonBackground;
      this.circleButton.Location = new System.Drawing.Point(254, 3);
      this.circleButton.Name = "circleButton";
      this.circleButton.Size = new System.Drawing.Size(32, 32);
      this.circleButton.TabIndex = 4;
      this.circleButton.UseVisualStyleBackColor = true;
      this.circleButton.Click += new System.EventHandler(this.CircleButton_Click);
      // 
      // ellipseButton
      // 
      this.ellipseButton.BackgroundImage = global::View.Properties.Resources.EllipseButtonBackground;
      this.ellipseButton.Location = new System.Drawing.Point(292, 3);
      this.ellipseButton.Name = "ellipseButton";
      this.ellipseButton.Size = new System.Drawing.Size(32, 32);
      this.ellipseButton.TabIndex = 5;
      this.ellipseButton.UseVisualStyleBackColor = true;
      this.ellipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
      // 
      // polygonButton
      // 
      this.polygonButton.BackgroundImage = global::View.Properties.Resources.PolygonButtonBackground;
      this.polygonButton.Location = new System.Drawing.Point(330, 3);
      this.polygonButton.Name = "polygonButton";
      this.polygonButton.Size = new System.Drawing.Size(32, 32);
      this.polygonButton.TabIndex = 7;
      this.polygonButton.UseVisualStyleBackColor = true;
      this.polygonButton.Click += new System.EventHandler(this.PolygonButton_Click);
      // 
      // textButton
      // 
      this.textButton.BackgroundImage = global::View.Properties.Resources.TextButtonBackground;
      this.textButton.Location = new System.Drawing.Point(368, 3);
      this.textButton.Name = "textButton";
      this.textButton.Size = new System.Drawing.Size(32, 32);
      this.textButton.TabIndex = 8;
      this.textButton.UseVisualStyleBackColor = true;
      this.textButton.Click += new System.EventHandler(this.TextButton_Click);
      // 
      // editColorButton
      // 
      this.editColorButton.BackgroundImage = global::View.Properties.Resources.EditButtonBackground;
      this.editColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editColorButton.Location = new System.Drawing.Point(163, 19);
      this.editColorButton.Name = "editColorButton";
      this.editColorButton.Size = new System.Drawing.Size(75, 72);
      this.editColorButton.TabIndex = 3;
      this.editColorButton.UseVisualStyleBackColor = true;
      this.editColorButton.Click += new System.EventHandler(this.EditColorButton_Click);
      // 
      // View
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1584, 761);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.mainTableLayoutPanel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "View";
      this.Text = "SeeSharper";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.View_FormClosing);
      this.mainTableLayoutPanel.ResumeLayout(false);
      this.undoRedoTableLayoutPanel.ResumeLayout(false);
      this.undoGroupBox.ResumeLayout(false);
      this.undoGroupBox.PerformLayout();
      this.redoGroupBox.ResumeLayout(false);
      this.redoGroupBox.PerformLayout();
      this.flowLayoutPanel.ResumeLayout(false);
      this.flowLayoutPanel.PerformLayout();
      this.saveLoadGroupBox.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.propertiesGroupBox.ResumeLayout(false);
      this.propertiesGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.thicknessTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.TableLayoutPanel undoRedoTableLayoutPanel;
    private System.Windows.Forms.GroupBox undoGroupBox;
    private System.Windows.Forms.TextBox undoTextBox;
    private System.Windows.Forms.Button undoButton;
    private System.Windows.Forms.GroupBox redoGroupBox;
    private System.Windows.Forms.TextBox redoTextBox;
    private System.Windows.Forms.Button redoButton;
    private System.Windows.Forms.ColorDialog colorDialog;
    private System.Windows.Forms.Button borderColorButton;
    private System.Windows.Forms.Button fillColorButton;
    private System.Windows.Forms.Button editColorButton;
    private System.Windows.Forms.Button squareButton;
    private System.Windows.Forms.Button lineButton;
    private System.Windows.Forms.Button brushButton;
    private System.Windows.Forms.Button ellipseButton;
    private System.Windows.Forms.Button circleButton;
    private System.Windows.Forms.Button rectangleButton;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    private System.Windows.Forms.Label toolsAndShapesLabel;
    private System.Windows.Forms.GroupBox saveLoadGroupBox;
    private System.Windows.Forms.Button loadButton;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Button helpButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label editColorLabel;
    private System.Windows.Forms.Label borderColorLabel;
    private System.Windows.Forms.Label fillColorLabel;
    private System.Windows.Forms.GroupBox propertiesGroupBox;
    private System.Windows.Forms.CheckBox fillCheckBox;
    private System.Windows.Forms.Label thicknessLabel;
    private System.Windows.Forms.TrackBar thicknessTrackBar;
    private System.Windows.Forms.Button polygonButton;
    private System.Windows.Forms.Button textButton;
  }
}

