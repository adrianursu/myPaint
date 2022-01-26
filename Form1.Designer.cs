namespace MyPaint
{
    partial class MyPaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPaint));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFlip180V = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnRotate90degL = new System.Windows.Forms.Button();
            this.btnRotate90degR = new System.Windows.Forms.Button();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.btnFreeDraw = new System.Windows.Forms.Button();
            this.btnFlip180H = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Upload";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1326, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.newToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.saveToolStripMenuItem.Text = "Save As...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(269, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(215, 29);
            this.helpToolStripMenuItem.Text = "Instructions and Credits";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sidebarPanel.Controls.Add(this.label9);
            this.sidebarPanel.Controls.Add(this.label8);
            this.sidebarPanel.Controls.Add(this.label7);
            this.sidebarPanel.Controls.Add(this.label6);
            this.sidebarPanel.Controls.Add(this.label5);
            this.sidebarPanel.Controls.Add(this.label4);
            this.sidebarPanel.Controls.Add(this.label3);
            this.sidebarPanel.Controls.Add(this.label2);
            this.sidebarPanel.Controls.Add(this.label1);
            this.sidebarPanel.Controls.Add(this.btnFlip180V);
            this.sidebarPanel.Controls.Add(this.btnZoomOut);
            this.sidebarPanel.Controls.Add(this.btnZoomIn);
            this.sidebarPanel.Controls.Add(this.btnCrop);
            this.sidebarPanel.Controls.Add(this.trackBar1);
            this.sidebarPanel.Controls.Add(this.btnErase);
            this.sidebarPanel.Controls.Add(this.btnRectangle);
            this.sidebarPanel.Controls.Add(this.btnEllipse);
            this.sidebarPanel.Controls.Add(this.btnRotate90degL);
            this.sidebarPanel.Controls.Add(this.btnRotate90degR);
            this.sidebarPanel.Controls.Add(this.btnChooseColor);
            this.sidebarPanel.Controls.Add(this.btnFreeDraw);
            this.sidebarPanel.Controls.Add(this.btnFlip180H);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 33);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(209, 845);
            this.sidebarPanel.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Color Picker";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Shapes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Eraser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 643);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Zoom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 729);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Crop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Thickness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Rotate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Flip";
            // 
            // btnFlip180V
            // 
            this.btnFlip180V.Image = global::MyPaint.Properties.Resources.icons8_flip_vertical_30;
            this.btnFlip180V.Location = new System.Drawing.Point(114, 558);
            this.btnFlip180V.Name = "btnFlip180V";
            this.btnFlip180V.Size = new System.Drawing.Size(60, 60);
            this.btnFlip180V.TabIndex = 11;
            this.btnFlip180V.UseVisualStyleBackColor = true;
            this.btnFlip180V.Click += new System.EventHandler(this.BtnFlip180V_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::MyPaint.Properties.Resources.icons8_zoom_out_30;
            this.btnZoomOut.Location = new System.Drawing.Point(114, 666);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(60, 60);
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::MyPaint.Properties.Resources.icons8_zoom_in_30;
            this.btnZoomIn.Location = new System.Drawing.Point(18, 666);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(60, 60);
            this.btnZoomIn.TabIndex = 9;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Image = global::MyPaint.Properties.Resources.icons8_crop_30;
            this.btnCrop.Location = new System.Drawing.Point(63, 752);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(60, 60);
            this.btnCrop.TabIndex = 6;
            this.btnCrop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.BtnCrop_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(47, 348);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(92, 69);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Tag = "";
            // 
            // btnErase
            // 
            this.btnErase.Image = global::MyPaint.Properties.Resources.icons8_eraser_32;
            this.btnErase.Location = new System.Drawing.Point(63, 232);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(60, 60);
            this.btnErase.TabIndex = 7;
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.BtnErase_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.BackColor = System.Drawing.SystemColors.Menu;
            this.btnRectangle.Image = global::MyPaint.Properties.Resources.icons8_rectangle_30;
            this.btnRectangle.Location = new System.Drawing.Point(114, 135);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(60, 60);
            this.btnRectangle.TabIndex = 6;
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.BtnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.BackColor = System.Drawing.SystemColors.Menu;
            this.btnEllipse.Image = global::MyPaint.Properties.Resources.icons8_ellipse_30;
            this.btnEllipse.Location = new System.Drawing.Point(18, 135);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(60, 60);
            this.btnEllipse.TabIndex = 5;
            this.btnEllipse.UseVisualStyleBackColor = false;
            this.btnEllipse.Click += new System.EventHandler(this.BtnEllipse_Click);
            // 
            // btnRotate90degL
            // 
            this.btnRotate90degL.Image = global::MyPaint.Properties.Resources.icons8_rotate_left_24;
            this.btnRotate90degL.Location = new System.Drawing.Point(114, 443);
            this.btnRotate90degL.Name = "btnRotate90degL";
            this.btnRotate90degL.Size = new System.Drawing.Size(60, 60);
            this.btnRotate90degL.TabIndex = 4;
            this.btnRotate90degL.UseVisualStyleBackColor = true;
            this.btnRotate90degL.Click += new System.EventHandler(this.BtnRotate90degL_Click);
            // 
            // btnRotate90degR
            // 
            this.btnRotate90degR.Image = global::MyPaint.Properties.Resources.icons8_rotate_right_24;
            this.btnRotate90degR.Location = new System.Drawing.Point(18, 443);
            this.btnRotate90degR.Name = "btnRotate90degR";
            this.btnRotate90degR.Size = new System.Drawing.Size(60, 60);
            this.btnRotate90degR.TabIndex = 3;
            this.btnRotate90degR.UseVisualStyleBackColor = true;
            this.btnRotate90degR.Click += new System.EventHandler(this.BtnRotate90degR_Click);
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.BackColor = System.Drawing.SystemColors.Menu;
            this.btnChooseColor.Image = global::MyPaint.Properties.Resources.icons8_color_wheel_48;
            this.btnChooseColor.Location = new System.Drawing.Point(114, 36);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(60, 60);
            this.btnChooseColor.TabIndex = 2;
            this.btnChooseColor.UseVisualStyleBackColor = false;
            this.btnChooseColor.Click += new System.EventHandler(this.BtnChooseColor_Click);
            // 
            // btnFreeDraw
            // 
            this.btnFreeDraw.BackColor = System.Drawing.SystemColors.Menu;
            this.btnFreeDraw.Image = global::MyPaint.Properties.Resources.icons8_pen_32;
            this.btnFreeDraw.Location = new System.Drawing.Point(18, 36);
            this.btnFreeDraw.Name = "btnFreeDraw";
            this.btnFreeDraw.Size = new System.Drawing.Size(60, 60);
            this.btnFreeDraw.TabIndex = 1;
            this.btnFreeDraw.UseVisualStyleBackColor = false;
            this.btnFreeDraw.Click += new System.EventHandler(this.BtnFreeDraw_Click);
            // 
            // btnFlip180H
            // 
            this.btnFlip180H.Image = global::MyPaint.Properties.Resources.icons8_flip_horizontal_30;
            this.btnFlip180H.Location = new System.Drawing.Point(18, 558);
            this.btnFlip180H.Name = "btnFlip180H";
            this.btnFlip180H.Size = new System.Drawing.Size(60, 60);
            this.btnFlip180H.TabIndex = 0;
            this.btnFlip180H.UseVisualStyleBackColor = true;
            this.btnFlip180H.Click += new System.EventHandler(this.BtnFlip180H_Click);
            // 
            // picturePanel
            // 
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Controls.Add(this.pictureBox);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(0, 0);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(1326, 878);
            this.picturePanel.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(215, 33);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1099, 842);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 878);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picturePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1341, 916);
            this.Name = "MyPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyPaint";
            this.Load += new System.EventHandler(this.MyPaint_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnFlip180H;
        private System.Windows.Forms.Button btnFreeDraw;
        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnRotate90degL;
        private System.Windows.Forms.Button btnRotate90degR;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnFlip180V;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

