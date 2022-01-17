using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class MyPaint : Form
    {
        Bitmap bitmap;

        Point startPoint;
        Point finishPoint;
        Rectangle rect;

        bool isPenDown;
        bool isFreeDrawActive = false;
        bool isElipseActive = false;
        bool isRectangleActive = false;


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
            
            openFileDialog.ShowDialog();

            bitmap = (Bitmap) Bitmap.FromFile(openFileDialog.FileName);
            pictureBox1.Image = bitmap;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
              bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
              pictureBox1.Image = bitmap;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bitmap;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Image = bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isFreeDrawActive = true;
            isRectangleActive = false;
            isElipseActive = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location; 
            isPenDown = true;

            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            finishPoint = e.Location;
            Graphics graphics = pictureBox1.CreateGraphics();

            Pen pen = new Pen(colorDialog1.Color);


            if (isPenDown && isFreeDrawActive)
            {
                if (startPoint != null)
                {
                    graphics.DrawLine(pen, startPoint, finishPoint);
                }
                startPoint = finishPoint;
            }
          //else if (isRectangleActive && isPenDown)
          //{
          //   graphics.DrawRectangle(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));
          //  }
        }
      
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPenDown = false;
            finishPoint = e.Location;

            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(colorDialog1.Color);

            if (isRectangleActive)
            {
                graphics.DrawRectangle(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));

            }
            else if (isElipseActive)
            {
                graphics.DrawEllipse(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isElipseActive = true;
            isFreeDrawActive = false;
            isRectangleActive = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isRectangleActive = true;
            isElipseActive = false;
            isFreeDrawActive = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // pictureBox1.Invalidate();   
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(colorDialog1.Color);

            //if (isRectangleActive)
            //{
             //   e.Graphics.DrawRectangle(pen, Math.Min(startPoint.X, finishPoint.X), Math.Min(startPoint.Y, finishPoint.Y), Math.Abs(finishPoint.X - startPoint.X), Math.Abs(finishPoint.Y - startPoint.Y));
           // }
        }
    }
}
