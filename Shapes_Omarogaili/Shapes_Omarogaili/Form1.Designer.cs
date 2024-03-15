namespace Shapes_Omarogaili
{
    partial class ShapesDrawForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Circle = new Button();
            picBox = new PictureBox();
            btn_Square = new Button();
            btn_Triangle = new Button();
            btn_Refresh = new Button();
            btn_Undo = new Button();
            colorDialog = new ColorDialog();
            btn_Save = new Button();
            saveAs_photo = new CheckBox();
            saveAs_file = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // btn_Circle
            // 
            btn_Circle.Location = new Point(12, 71);
            btn_Circle.Name = "btn_Circle";
            btn_Circle.Size = new Size(75, 42);
            btn_Circle.TabIndex = 0;
            btn_Circle.Text = "Circle";
            btn_Circle.UseVisualStyleBackColor = true;
            btn_Circle.Click += btn_Circle_Click;
            // 
            // picBox
            // 
            picBox.Location = new Point(12, 119);
            picBox.Name = "picBox";
            picBox.Size = new Size(659, 294);
            picBox.TabIndex = 1;
            picBox.TabStop = false;
            picBox.Click += picBox_Click;
            picBox.Paint += picBox_Paint;
            // 
            // btn_Square
            // 
            btn_Square.Location = new Point(118, 71);
            btn_Square.Name = "btn_Square";
            btn_Square.Size = new Size(75, 42);
            btn_Square.TabIndex = 3;
            btn_Square.Text = "Square";
            btn_Square.UseVisualStyleBackColor = true;
            btn_Square.Click += btn_Square_Click;
            // 
            // btn_Triangle
            // 
            btn_Triangle.Location = new Point(223, 71);
            btn_Triangle.Name = "btn_Triangle";
            btn_Triangle.Size = new Size(75, 42);
            btn_Triangle.TabIndex = 4;
            btn_Triangle.Text = "Triangle";
            btn_Triangle.UseVisualStyleBackColor = true;
            btn_Triangle.Click += btn_Triangle_Click;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(12, 447);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 42);
            btn_Refresh.TabIndex = 5;
            btn_Refresh.Text = "Refresh";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // btn_Undo
            // 
            btn_Undo.Location = new Point(118, 447);
            btn_Undo.Name = "btn_Undo";
            btn_Undo.Size = new Size(75, 42);
            btn_Undo.TabIndex = 6;
            btn_Undo.Text = "Ångra";
            btn_Undo.UseVisualStyleBackColor = true;
            btn_Undo.Click += btn_Undo_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(223, 447);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 42);
            btn_Save.TabIndex = 7;
            btn_Save.Text = "Spara";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // saveAs_photo
            // 
            saveAs_photo.AutoSize = true;
            saveAs_photo.Location = new Point(333, 447);
            saveAs_photo.Name = "saveAs_photo";
            saveAs_photo.Size = new Size(46, 19);
            saveAs_photo.TabIndex = 8;
            saveAs_photo.Text = "Bild";
            saveAs_photo.UseVisualStyleBackColor = true;
            // 
            // saveAs_file
            // 
            saveAs_file.AutoSize = true;
            saveAs_file.Location = new Point(333, 472);
            saveAs_file.Name = "saveAs_file";
            saveAs_file.Size = new Size(38, 19);
            saveAs_file.TabIndex = 9;
            saveAs_file.Text = "Fil";
            saveAs_file.UseVisualStyleBackColor = true;
            // 
            // ShapesDrawForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 535);
            Controls.Add(saveAs_file);
            Controls.Add(saveAs_photo);
            Controls.Add(btn_Save);
            Controls.Add(btn_Undo);
            Controls.Add(btn_Refresh);
            Controls.Add(btn_Triangle);
            Controls.Add(btn_Square);
            Controls.Add(picBox);
            Controls.Add(btn_Circle);
            Name = "ShapesDrawForm";
            Text = "ShapesDrawForm";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Circle;
        private PictureBox picBox;
        private Button btn_Square;
        private Button btn_Triangle;
        private Button btn_Refresh;
        private Button btn_Undo;
        private ColorDialog colorDialog;
        private Button btn_Save;
        private CheckBox saveAs_photo;
        private CheckBox saveAs_file;
    }
}
