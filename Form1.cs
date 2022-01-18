﻿using System;
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

        bool isPenDown;
        bool isFreeDrawActive = false;
        bool isElipseActive = false;
        bool isRectangleActive = false;
        bool isEraserActive = false;


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
            isEraserActive = false;
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

        private void button6_Click(object sender, EventArgs e)
        {
            isElipseActive = true;
            isFreeDrawActive = false;
            isRectangleActive = false;
            isEraserActive = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isRectangleActive = true;
            isElipseActive = false;
            isFreeDrawActive = false;
            isEraserActive = false;
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
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            isEraserActive = true;
            isElipseActive = false;
            isFreeDrawActive = false;
            isRectangleActive = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JPG (.*jpg *jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png",
                Title = "Save an Image File"
            };
            saveFileDialog.ShowDialog();

            if(saveFileDialog.FileName != "")
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
    }
}
