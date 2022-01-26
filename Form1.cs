using System;
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

        Point currentPoint;
        Point previousPoint;

        Action? action;
        bool isPenDown;
  
        public MyPaint()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            pictureBox.Image = bitmap;
            action = null;
        }

        private void MyPaint_Load(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            g.Dispose();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
            openFileDialog.Dispose();
        }

        private void NewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            action = null;
           
            bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Brush brush = new SolidBrush(Color.White);
            graphics.FillRectangle(brush, 0, 0, pictureBox.ClientSize.Width, pictureBox.Image.Height);
            graphics.Dispose();
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPG (.*jpg *jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png",
                Title = "Save an Image File",
                RestoreDirectory = true
            };

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

        private void BtnFreeDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            action = Action.FreeDraw;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.Refresh();
            currentPoint = e.Location;
            isPenDown = true;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
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
                    case Action.Rectangle:
                    case Action.Crop:
                        DrawRectanglePreview(e.Location); break;
                    case Action.Elipse: DrawElipsePreview(e.Location); break;
                }
                graphics.Dispose();
            }
        }
        private void DrawLine(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, currentPoint, previousPoint);
            currentPoint = previousPoint;
            pictureBox.Refresh();
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

        private void DrawElipsePreview(Point point)
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
            Pen pen = new Pen(Color.Black, trackBar1.Value);
            pen.DashStyle = DashStyle.DashDotDot;
            return pen;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.Refresh();
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

                case Action.Crop: CropImage(); break;
            }

            pen.Dispose();
            graphics.Dispose();
            pictureBox.Refresh();
        }

        private void CropImage()
        {
            Cursor = Cursors.Default;

            if (previousPoint.X == 0 && previousPoint.Y == 0)
            {
                return;
            }

            Rectangle rectangle = new Rectangle(
                Math.Min(currentPoint.X, previousPoint.X),
                Math.Min(currentPoint.Y, previousPoint.Y),
                Math.Abs(previousPoint.X - currentPoint.X),
                Math.Abs(previousPoint.Y - currentPoint.Y)
            );

            Bitmap croppedBitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics graphics = Graphics.FromImage(croppedBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            graphics.DrawImage(bitmap, 0, 0, rectangle, GraphicsUnit.Pixel);
            pictureBox.Image = croppedBitmap;
            pictureBox.Width = croppedBitmap.Width;
            pictureBox.Height = croppedBitmap.Height;
            bitmap = croppedBitmap;
            graphics.Dispose();
            action = null;
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            action = Action.Elipse;
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            action = Action.Rectangle;
        }

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _ = colorDialog1.Color;
            }
        }

        private void BtnErase_Click(object sender, EventArgs e)
        {
            action = Action.Eraser;
        }

        private void BtnCrop_Click(object sender, EventArgs e)
        {
            action = Action.Crop;
            previousPoint = new Point();
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Size size = new Size((int)Math.Round(pictureBox.Image.Width * 1.05), (int)Math.Round(pictureBox.Image.Height * 1.05));
                pictureBox.Image = new Bitmap(bitmap, size);
                bitmap = (Bitmap)pictureBox.Image;
            }
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Size size = new Size((int)Math.Round(pictureBox.Image.Width * 0.9), (int)Math.Round(pictureBox.Image.Height * 0.9));
                pictureBox.Image = new Bitmap(bitmap, size);
                bitmap = (Bitmap)pictureBox.Image;
            }
        }

        private void BtnFlip180V_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox.Image = bitmap;
            }
        }
        private void BtnFlip180H_Click(object sender, EventArgs e)
        {

            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox.Image = bitmap;
            }
        }

        private void BtnRotate90degR_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Image = bitmap;
            }
        }

        private void BtnRotate90degL_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox.Image = bitmap;
            }
        }
    }
}
