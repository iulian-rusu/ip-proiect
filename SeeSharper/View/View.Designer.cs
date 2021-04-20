
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.colorGroupBox = new System.Windows.Forms.GroupBox();
      this.editColorButton = new System.Windows.Forms.Button();
      this.colorButton3 = new System.Windows.Forms.Button();
      this.colorButton2 = new System.Windows.Forms.Button();
      this.colorButton1 = new System.Windows.Forms.Button();
      this.toolsAndShapesGroupBox = new System.Windows.Forms.GroupBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.undoGroupBox = new System.Windows.Forms.GroupBox();
      this.undoTextBox = new System.Windows.Forms.TextBox();
      this.undoButton = new System.Windows.Forms.Button();
      this.redoGroupBox = new System.Windows.Forms.GroupBox();
      this.redoTextBox = new System.Windows.Forms.TextBox();
      this.redoButton = new System.Windows.Forms.Button();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.colorDialog = new System.Windows.Forms.ColorDialog();
      this.tableLayoutPanel.SuspendLayout();
      this.colorGroupBox.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.undoGroupBox.SuspendLayout();
      this.redoGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 3;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel.Controls.Add(this.colorGroupBox, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.toolsAndShapesGroupBox, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 2, 0);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 1;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(1584, 100);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // colorGroupBox
      // 
      this.colorGroupBox.Controls.Add(this.editColorButton);
      this.colorGroupBox.Controls.Add(this.colorButton3);
      this.colorGroupBox.Controls.Add(this.colorButton2);
      this.colorGroupBox.Controls.Add(this.colorButton1);
      this.colorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.colorGroupBox.Location = new System.Drawing.Point(531, 3);
      this.colorGroupBox.Name = "colorGroupBox";
      this.colorGroupBox.Size = new System.Drawing.Size(522, 94);
      this.colorGroupBox.TabIndex = 1;
      this.colorGroupBox.TabStop = false;
      this.colorGroupBox.Text = "Color";
      // 
      // editColorButton
      // 
      this.editColorButton.BackgroundImage = global::View.Properties.Resources.EditButtonBackground;
      this.editColorButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.editColorButton.Location = new System.Drawing.Point(444, 16);
      this.editColorButton.Name = "editColorButton";
      this.editColorButton.Size = new System.Drawing.Size(75, 75);
      this.editColorButton.TabIndex = 3;
      this.editColorButton.Text = "Edit Color ";
      this.editColorButton.UseVisualStyleBackColor = true;
      this.editColorButton.Click += new System.EventHandler(this.editColorButton_Click);
      // 
      // colorButton3
      // 
      this.colorButton3.BackColor = System.Drawing.Color.Blue;
      this.colorButton3.Dock = System.Windows.Forms.DockStyle.Left;
      this.colorButton3.Location = new System.Drawing.Point(153, 16);
      this.colorButton3.Name = "colorButton3";
      this.colorButton3.Size = new System.Drawing.Size(75, 75);
      this.colorButton3.TabIndex = 2;
      this.colorButton3.UseVisualStyleBackColor = false;
      this.colorButton3.Click += new System.EventHandler(this.colorButton3_Click);
      // 
      // colorButton2
      // 
      this.colorButton2.BackColor = System.Drawing.Color.Lime;
      this.colorButton2.Dock = System.Windows.Forms.DockStyle.Left;
      this.colorButton2.Location = new System.Drawing.Point(78, 16);
      this.colorButton2.Name = "colorButton2";
      this.colorButton2.Size = new System.Drawing.Size(75, 75);
      this.colorButton2.TabIndex = 1;
      this.colorButton2.UseVisualStyleBackColor = false;
      this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
      // 
      // colorButton1
      // 
      this.colorButton1.BackColor = System.Drawing.Color.Red;
      this.colorButton1.Dock = System.Windows.Forms.DockStyle.Left;
      this.colorButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.colorButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.colorButton1.Location = new System.Drawing.Point(3, 16);
      this.colorButton1.Name = "colorButton1";
      this.colorButton1.Size = new System.Drawing.Size(75, 75);
      this.colorButton1.TabIndex = 0;
      this.colorButton1.UseVisualStyleBackColor = false;
      this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
      // 
      // toolsAndShapesGroupBox
      // 
      this.toolsAndShapesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolsAndShapesGroupBox.Location = new System.Drawing.Point(3, 3);
      this.toolsAndShapesGroupBox.Name = "toolsAndShapesGroupBox";
      this.toolsAndShapesGroupBox.Size = new System.Drawing.Size(522, 94);
      this.toolsAndShapesGroupBox.TabIndex = 0;
      this.toolsAndShapesGroupBox.TabStop = false;
      this.toolsAndShapesGroupBox.Text = "Tools and Shapes";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.undoGroupBox, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.redoGroupBox, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(1059, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 94);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // undoGroupBox
      // 
      this.undoGroupBox.Controls.Add(this.undoTextBox);
      this.undoGroupBox.Controls.Add(this.undoButton);
      this.undoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.undoGroupBox.Location = new System.Drawing.Point(3, 3);
      this.undoGroupBox.Name = "undoGroupBox";
      this.undoGroupBox.Size = new System.Drawing.Size(516, 41);
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
      this.undoTextBox.Size = new System.Drawing.Size(435, 20);
      this.undoTextBox.TabIndex = 0;
      // 
      // undoButton
      // 
      this.undoButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.undoButton.Location = new System.Drawing.Point(438, 16);
      this.undoButton.Name = "undoButton";
      this.undoButton.Size = new System.Drawing.Size(75, 22);
      this.undoButton.TabIndex = 0;
      this.undoButton.Text = "Undo";
      this.undoButton.UseVisualStyleBackColor = true;
      this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
      // 
      // redoGroupBox
      // 
      this.redoGroupBox.Controls.Add(this.redoTextBox);
      this.redoGroupBox.Controls.Add(this.redoButton);
      this.redoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.redoGroupBox.Location = new System.Drawing.Point(3, 50);
      this.redoGroupBox.Name = "redoGroupBox";
      this.redoGroupBox.Size = new System.Drawing.Size(516, 41);
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
      this.redoTextBox.Size = new System.Drawing.Size(435, 20);
      this.redoTextBox.TabIndex = 1;
      // 
      // redoButton
      // 
      this.redoButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.redoButton.Location = new System.Drawing.Point(438, 16);
      this.redoButton.Name = "redoButton";
      this.redoButton.Size = new System.Drawing.Size(75, 22);
      this.redoButton.TabIndex = 0;
      this.redoButton.Text = "Redo";
      this.redoButton.UseVisualStyleBackColor = true;
      this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
      // 
      // pictureBox
      // 
      this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox.Location = new System.Drawing.Point(0, 100);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(1584, 661);
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
      this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      // 
      // View
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1584, 761);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.tableLayoutPanel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "View";
      this.Text = "SeeSharper";
      this.tableLayoutPanel.ResumeLayout(false);
      this.colorGroupBox.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.undoGroupBox.ResumeLayout(false);
      this.undoGroupBox.PerformLayout();
      this.redoGroupBox.ResumeLayout(false);
      this.redoGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.GroupBox colorGroupBox;
    private System.Windows.Forms.GroupBox toolsAndShapesGroupBox;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox undoGroupBox;
    private System.Windows.Forms.TextBox undoTextBox;
    private System.Windows.Forms.Button undoButton;
    private System.Windows.Forms.GroupBox redoGroupBox;
    private System.Windows.Forms.TextBox redoTextBox;
    private System.Windows.Forms.Button redoButton;
    private System.Windows.Forms.ColorDialog colorDialog;
    private System.Windows.Forms.Button colorButton3;
    private System.Windows.Forms.Button colorButton2;
    private System.Windows.Forms.Button colorButton1;
    private System.Windows.Forms.Button editColorButton;
  }
}

