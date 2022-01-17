using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class MyPaint : Form
    {
        Bitmap bitmap;

        Point lastPoint;
        bool isPenDown;

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
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
              bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
              pictureBox1.Image = bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location; 
            isPenDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Point point = e.Location;
            Pen pen = new Pen(Color.Red);

            if (isPenDown)
            {
                if (lastPoint != null)
                {
                    graphics.DrawLine(pen, lastPoint, point);
                }
                lastPoint = point;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPenDown = false;
        }
    }
}
