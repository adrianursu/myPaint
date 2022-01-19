using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class MyPaint : Form
    {
        Image bitmap;

        Point startPoint;
        Point finishPoint;

        bool isPenDown;
        bool isFreeDrawActive;
        bool isElipseActive;
        bool isRectangleActive;
        bool isEraserActive;
        bool isCropActive;

        //For Crop
        //int cropX;
        //int cropY;
        //int cropWidth;
        //int cropHeight;
        //int oCropX;
        //int oCropY;

        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;


        public MyPaint()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                pictureBox1.Image = bitmap;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
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
              pictureBox1.Image = bitmap;
            }
        }

        private void btnRotate90degR_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bitmap;
            }
        }

        private void btnRotate90degL_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Image = bitmap;
            }
        }

        private void btnFreeDraw_Click(object sender, EventArgs e)
        {
            isFreeDrawActive = true;
            isRectangleActive = false;
            isElipseActive = false;
            isEraserActive = false;
            isCropActive = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location; 
            isPenDown = true;

            //if (isCropActive)
            //{
            //    Cursor = Cursors.Cross;
            //    cropX = startPoint.X;
            //    cropY = startPoint.Y;
            //    cropPen = new Pen(Color.Black, 1);
            //    cropPen.DashStyle = DashStyle.Dot;
            //}
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            finishPoint = e.Location;
            Graphics graphics = pictureBox1.CreateGraphics();
            float penWidth = (float)trackBar1.Value;

            Pen pen = new Pen(colorDialog1.Color, penWidth);
            Pen eraserPen = new Pen(Color.White, penWidth);

            if (isPenDown && isFreeDrawActive)
            {
                if (startPoint != null)
                {
                    graphics.DrawLine(pen, startPoint, finishPoint);
                }
                startPoint = finishPoint;
            }
            else if (isPenDown && isEraserActive)
            {
                if (startPoint != null)
                {
                    graphics.DrawLine(eraserPen, startPoint, finishPoint);
                }
                startPoint = finishPoint;
            }
            //else if (isPenDown && isCropActive)
            //{
            //    if (pictureBox1.Image == null)
            //        return;
            //    pictureBox1.Refresh();
            //    cropWidth = finishPoint.X - cropX;
            //    cropHeight = finishPoint.Y - cropY;
            //    graphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
            //}
        }
      
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPenDown = false;
            finishPoint = e.Location;

            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(colorDialog1.Color, (float)trackBar1.Value);

            if (isRectangleActive)
            {
                graphics.DrawRectangle(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));

            }
            else if (isElipseActive)
            {
                graphics.DrawEllipse(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));

            }
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            isElipseActive = true;
            isFreeDrawActive = false;
            isRectangleActive = false;
            isEraserActive = false;
            isCropActive = false;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
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

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
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
                Title = "Save an Image File"
            };
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "" && pictureBox1.Image != null)
            {
                System.IO.FileStream file = (System.IO.FileStream)saveFileDialog.OpenFile();
                
                switch(saveFileDialog.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBox1.Image.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                file.Close();
            }
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            isCropActive = true;
            isEraserActive = false;
            isElipseActive = false;
            isFreeDrawActive = false;
            isRectangleActive = false;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoom+=0.02;
            pictureBox1.Width = (int)Math.Round(pictureBox1.Image.Width * zoom);
            pictureBox1.Height = (int)Math.Round(pictureBox1.Image.Height * zoom);
        }
        private double zoom = 1.02;
        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
           
        }



        private void btnFlip180V_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox1.Image = bitmap;
            }
        }
    }
}
