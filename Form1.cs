using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class MyPaint : Form
    {
        Bitmap bitmap;


        Action? action;

        Point currentPoint;
        Point previousPoint;

        bool isPenDown;
        bool isFreeDrawActive;
        bool isElipseActive;
        bool isRectangleActive;
        bool isEraserActive;
        bool isCropActive;

        public Pen pen;

        public MyPaint()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            pictureBox.Image = bitmap;
            action = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                AddExtension = true,
                Multiselect = false,
                InitialDirectory = "C://Desktop",
                Title = "Select file to be upload",
                Filter = "JPG (.*jpg *jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                pictureBox.Image = bitmap;
                pictureBox.Refresh();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
            else
            {
                this.Refresh();
            }
        }

        private void btnFlip180_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox.Image = bitmap;
            }
        }

        private void btnRotate90degR_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Image = bitmap;
            }
        }

        private void btnRotate90degL_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox.Image = bitmap;
            }
        }

        private void btnFreeDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            action = Action.FreeDraw;
            isFreeDrawActive = true;
            isRectangleActive = false;
            isElipseActive = false;
            isEraserActive = false;
            isCropActive = false;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            currentPoint = e.Location;
            isPenDown = true;


            pictureBox.Refresh();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPenDown)
            {
                previousPoint = e.Location;

                Graphics graphics = Graphics.FromImage(pictureBox.Image);
                float penWidth = (float)trackBar1.Value;

                switch (action)
                {
                    case Action.FreeDraw: DrawLine(graphics, new Pen(colorDialog1.Color, penWidth)); break;
                    case Action.Eraser: DrawLine(graphics, new Pen(Color.White, penWidth)); break;
                    case Action.Rectangle: DrawRectanglePreview(e.Location); break;
                    case Action.Elipse: DrawElipsisPreview(e.Location); break;
                }
            }
        }

        private void DrawRectanglePreview(Point point)
        {
            pictureBox.Refresh();
            pictureBox.CreateGraphics().DrawRectangle(
                GetPreviewPen(),
                Math.Min(currentPoint.X, previousPoint.X),
                Math.Min(currentPoint.Y, previousPoint.Y),
                Math.Abs(previousPoint.X - currentPoint.X),
                Math.Abs(previousPoint.Y - currentPoint.Y)
            );
        }

        private void DrawElipsisPreview(Point point)
        {
            pictureBox.Refresh();
            pictureBox.CreateGraphics().DrawEllipse(
                GetPreviewPen(),
                Math.Min(currentPoint.X, previousPoint.X),
                Math.Min(currentPoint.Y, previousPoint.Y),
                Math.Abs(previousPoint.X - currentPoint.X),
                Math.Abs(previousPoint.Y - currentPoint.Y)
            );
        }

        private Pen GetPreviewPen()
        {
            pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.DashDotDot;
            return pen;
        }

        private void DrawLine(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, currentPoint, previousPoint);
            currentPoint = previousPoint;
            pictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isPenDown = false;

            Graphics graphics = Graphics.FromImage(pictureBox.Image);
            Pen pen = new Pen(colorDialog1.Color, (float)trackBar1.Value);

            switch (action)
            {
                case Action.Rectangle:
                    graphics.DrawRectangle(
                        pen,
                        Math.Min(currentPoint.X, previousPoint.X),
                        Math.Min(currentPoint.Y, previousPoint.Y),
                        Math.Abs(previousPoint.X - currentPoint.X),
                        Math.Abs(previousPoint.Y - currentPoint.Y)
                    );
                    break;

                case Action.Elipse:
                    graphics.DrawEllipse(
                        pen,
                        Math.Min(currentPoint.X, previousPoint.X),
                        Math.Min(currentPoint.Y, previousPoint.Y),
                        Math.Abs(previousPoint.X - currentPoint.X),
                        Math.Abs(previousPoint.Y - currentPoint.Y)
                    );
                    break;
            }

            pictureBox.Refresh();
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            action = Action.Elipse;
            isElipseActive = true;
            isFreeDrawActive = false;
            isRectangleActive = false;
            isEraserActive = false;
            isCropActive = false;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            action = Action.Rectangle;
            isRectangleActive = true;
            isElipseActive = false;
            isFreeDrawActive = false;
            isEraserActive = false;
            isCropActive = false;
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            action = Action.Eraser;
            isEraserActive = true;
            isElipseActive = false;
            isFreeDrawActive = false;
            isRectangleActive = false;
            isCropActive = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPG (.*jpg *jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png",
                Title = "Save an Image File",
                RestoreDirectory = true
            };
            //saveFileDialog.ShowDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream file = (FileStream)saveFileDialog.OpenFile();

                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        pictureBox.Image = null;
                        pictureBox.Image = bitmap;
                        pictureBox.Image.Save(file, ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBox.Image.Save(file, ImageFormat.Png);
                        break;
                }
                file.Close();
            }
        }

        private void BtnCrop_Click(object sender, EventArgs e)
        {
            isCropActive = true;
            isEraserActive = false;
            isElipseActive = false;
            isFreeDrawActive = false;
            isRectangleActive = false;
        }

        private double zoom = 1.02;
        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                zoom *= 1.05;
                pictureBox.Width = (int)Math.Round(pictureBox.Image.Width * zoom);
                pictureBox.Height = (int)Math.Round(pictureBox.Image.Height * zoom);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                zoom /= 1.05;
                pictureBox.Width = (int)Math.Round(pictureBox.Image.Width * zoom);
                pictureBox.Height = (int)Math.Round(pictureBox.Image.Height * zoom);
            }
        }

        void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //    if (pictureBox.Image != null)
            //    {
            //        if (e.Delta > 0)
            //        {
            //            zoom *= 1.03;
            //        }
            //        else
            //        {
            //            if (zoom != 1.0)
            //            {
            //                zoom /= 1.03;
            //            }
            //        }
            //        pictureBox.Width = (int)Math.Round(pictureBox.Image.Width * zoom);
            //        pictureBox.Height = (int)Math.Round(pictureBox.Image.Height * zoom);
            //    }

        }

        private void btnFlip180V_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox.Image = bitmap;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
