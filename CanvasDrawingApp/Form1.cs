using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CanvasDrawingApp
{
    public partial class Form1 : Form
    {
        private ArrayList listOfPoints;
        private bool pencilDown;

        public Form1()
        {
            InitializeComponent();
            listOfPoints = new ArrayList();
            pencilDown = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            listOfPoints.Add(point);
            pencilDown = true;
            toolStripStatusLabel1.Text = "MouseDown";
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pencilDown = false;
            toolStripStatusLabel1.Text = "MouseUp";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Point currentPoint = new Point(e.X, e.Y);
            Pen pencil = new Pen(Color.FromArgb(45, 170, 250), 2); // Change pencil color and thickness

            if (pencilDown)
            {
                toolStripStatusLabel1.Text = "MouseMove";
                if (listOfPoints.Count > 1)
                {
                    Point previousPoint = (Point)listOfPoints[listOfPoints.Count - 1];
                    g.DrawLine(pencil, previousPoint, currentPoint);
                }
                listOfPoints.Add(currentPoint);
            }
        }
    }
}
