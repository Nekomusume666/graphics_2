using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_graphics_1
{
    public class Pikachu
    {
        private Bitmap bmp;
        private PictureBox pictureBox;

        private int xCenter => pictureBox.Width / 2;
        private int yCenter => pictureBox.Height / 2;

        private Point[] body;
        private Point[] head;
        private Point[] tail;

        private Point[] leftEar;
        private Point[] rightEar;

        private Point[] leftLeg;
        private Point[] rightLeg;

        private Point[] leftArm;
        private Point[] rightArm;

        private Point[] mouth;
        private Point[] nos;

        private Point[] rightEye;
        private Point[] leftEye;

        private Point[] leftChick;
        private Point[] rightChick;

        public Pikachu(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            Coordinates();
        }

        private void Coordinates()
        {
            body = new Point[]
            {
                new Point (-30, 10),
                new Point (-30,-50),
                new Point (40,-50),
                new Point (40,10)
            };

            head = new Point[]
            {
                new Point (-40, 80),
                new Point (50,80),
                new Point (50,10),
                new Point (-40,10)
            };

            tail = new Point[]
           {
                new Point(-30,-40),
                new Point(-50,-30),
                new Point(-40,-20),
                new Point(-80,0),
                new Point(-70,20),
                new Point(-30,-20),
                new Point(-40,-30),
                new Point(-30,-30)
           };

            leftEar = new Point[]
           {
                new Point(-30,80),
                new Point(-20,100),
                new Point(-10,80)
           };

            rightEar = new Point[]
           {
                new Point(20,80),
                new Point(30,100),
                new Point(40,80)
           };

            leftLeg = new Point[]
            {
               new Point(-20,-50),
               new Point(-20,-40),
               new Point(0,-40),
               new Point(0,-50)
            };

            rightLeg = new Point[]
            {
                new Point(10,-50),
                new Point(10,-40),
                new Point(30, -40), 
                new Point(30, -50)
            };

            leftArm = new Point[]
            {
                new Point(-30,-20),
                new Point(-30,0),
                new Point(-10,0),
                new Point(-10,-20)
            };
            rightArm = new Point[]
            {
                new Point(20,0),
                new Point(40,0),
                new Point(40,-20),
                new Point(20,-20)
            };

            mouth = new Point[]
            {
                new Point(0,30),
                new Point(10,30),
                new Point(10,20),
                new Point(0,20)
            };

            rightEye = new Point[]
            {
                new Point(20,70),
                new Point(30,70),
                new Point(30,60),
                new Point(20,60)
            };

            leftEye = new Point[]
            {
                new Point(-20,70),
                new Point(-10,70),
                new Point(-10,60),
                new Point(-20,60)
            };

            leftChick = new Point[]
            {
                new Point(-30,50),
                new Point(-10,50),
                new Point(-10,30),
                new Point(-30,30)
            };

            rightChick = new Point[]
            {
                new Point(20,50),
                new Point(40,50),
                new Point(40,30),
                new Point(20,30)
            };

            nos = new Point[]
            {
                new Point(0,50),
                new Point(10,50),
                new Point(10,40),
                new Point(0,40)
            };
        }

        public void Draw()
        {
            ClearCanvas();

            Pen blackPen = new Pen(Color.Black);
            SolidBrush yellowFill = new SolidBrush(Color.Yellow);
            SolidBrush blackFill = new SolidBrush(Color.Black);
            SolidBrush redFill = new SolidBrush(Color.Red);
            SolidBrush pinkFill = new SolidBrush(Color.Pink);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                DrawAndFillPolygons(g, yellowFill, blackPen, body, head, rightEar, leftEar, tail);
                DrawAndFillPolygons(g, blackFill, blackPen, rightEye, leftEye, rightArm, leftArm, nos, 
                                    rightLeg, leftLeg);
                DrawAndFillPolygons(g, pinkFill, blackPen, mouth);
                DrawAndFillPolygons(g, redFill, blackPen, rightChick, leftChick);

            }

            pictureBox.Image = bmp;
        }

        public void Clear()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        public void Rotate(float angleInDegrees)
        {
            ClearCanvas();

            float angleInRadians = angleInDegrees * (float)Math.PI / 180;

            Matrix rotationMatrix = new Matrix();
            rotationMatrix.Rotate(angleInDegrees);

            Pen blackPen = new Pen(Color.Black);
            SolidBrush yellowFill = new SolidBrush(Color.Yellow);
            SolidBrush blackFill = new SolidBrush(Color.Black);

            SolidBrush redFill = new SolidBrush(Color.Red);
            SolidBrush pinkFill = new SolidBrush(Color.Pink);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(rotationMatrix, body, head, leftLeg, rightLeg, mouth, rightEye, leftEye, leftArm, rightArm,
                                    tail, leftEar, rightEar, rightChick, leftChick, nos);

                DrawAndFillPolygons(g, yellowFill, blackPen, body, head, rightEar, leftEar, tail);
                DrawAndFillPolygons(g, blackFill, blackPen, rightEye, leftEye, rightArm, leftArm, nos, 
                                    rightLeg, leftLeg);

                DrawAndFillPolygons(g, pinkFill, blackPen, mouth);
                DrawAndFillPolygons(g, redFill, blackPen, rightChick, leftChick);
            }

            pictureBox.Image = bmp;
        }

        private void ClearCanvas()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        private void DrawAndFillPolygons(Graphics g, Brush fillBrush, Pen drawPen, params Point[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                g.FillPolygon(fillBrush, polygon);
                g.DrawPolygon(drawPen, polygon);
            }
        }

        private void ApplyTransformation(Matrix matrix, params Point[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                matrix.TransformPoints(polygon);
            }
        }

        public void Scale(float scaleFactor)
        {
            ClearCanvas();

            Matrix scaleMatrix = new Matrix();
            scaleMatrix.Scale(scaleFactor, scaleFactor);

            Pen blackPen = new Pen(Color.Black);
            SolidBrush yellowFill = new SolidBrush(Color.Yellow);
            SolidBrush blackFill = new SolidBrush(Color.Black);

            SolidBrush redFill = new SolidBrush(Color.Red);
            SolidBrush pinkFill = new SolidBrush(Color.Pink);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(scaleMatrix, body, head, leftLeg, rightLeg, mouth, rightEye, leftEye, leftArm, rightArm,
                                    tail, leftEar, rightEar, rightChick, leftChick, nos);

                DrawAndFillPolygons(g, yellowFill, blackPen, body, head, rightEar, leftEar, tail);
                DrawAndFillPolygons(g, blackFill, blackPen, rightEye, leftEye, rightArm, leftArm, nos,
                                    rightLeg, leftLeg);

                DrawAndFillPolygons(g, pinkFill, blackPen, mouth);
                DrawAndFillPolygons(g, redFill, blackPen, rightChick, leftChick);
            }

            pictureBox.Image = bmp;
        }

        public void Transfer(int deltaX, int deltaY)
        {
            ClearCanvas();

            Matrix translationMatrix = new Matrix();
            translationMatrix.Translate(deltaX, deltaY);

            Pen blackPen = new Pen(Color.Black);
            SolidBrush yellowFill = new SolidBrush(Color.Yellow);
            SolidBrush blackFill = new SolidBrush(Color.Black);


            SolidBrush redFill = new SolidBrush(Color.Red);
            SolidBrush pinkFill = new SolidBrush(Color.Pink);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(xCenter, yCenter);
                g.ScaleTransform(1, -1);

                ApplyTransformation(translationMatrix, body, head, leftLeg, rightLeg, mouth, rightEye, leftEye, leftArm, rightArm,
                                    tail, leftEar, rightEar, rightChick, leftChick, nos);

                DrawAndFillPolygons(g, yellowFill, blackPen, body, head, rightEar, leftEar, tail);
                DrawAndFillPolygons(g, blackFill, blackPen, rightEye, leftEye, rightArm, leftArm, nos,
                                    rightLeg, leftLeg);

                DrawAndFillPolygons(g, pinkFill, blackPen, mouth);
                DrawAndFillPolygons(g, redFill, blackPen, rightChick, leftChick);
            }

            pictureBox.Image = bmp;
        }

    }
}
