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
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Pikachu
    {
        private Bitmap bmp;
        private PictureBox pictureBox;

        //Передние части

        private Point3D[] bodyF;
        private Point3D[] headF;
        private Point3D[] tailF;

        private Point3D[] leftEarF;
        private Point3D[] rightEarF;

        private Point3D[] leftLegF;
        private Point3D[] rightLegF;

        private Point3D[] leftArmF;
        private Point3D[] rightArmF;

        private Point3D[] mouthF;
        private Point3D[] nosF;

        private Point3D[] rightEyeF;
        private Point3D[] leftEyeF;

        private Point3D[] leftChickF;
        private Point3D[] rightChickF;

        //Задние части

        private Point3D[] bodyB;
        private Point3D[] headB;
        private Point3D[] tailB;

        private Point3D[] leftEarB;
        private Point3D[] rightEarB;

        private Point3D[] leftLegB;
        private Point3D[] rightLegB;

        private Point3D[] leftArmB;
        private Point3D[] rightArmB;

        private Point3D[] nosB;

        private Point3D[] rightEyeB;
        private Point3D[] leftEyeB;

        private Point3D[] leftChickB;
        private Point3D[] rightChickB;

        
        ///////////////////


        private Point3D[] zAxisConnectionsFront;
        private Point3D[] zAxisConnectionsBack;

        private Point3D[][] figureFrontArrays;
        private Point3D[][] figureBackArrays;

        private Point3D[][] figureFrontArraysBase;
        private Point3D[][] figureBackArraysBase;
        

        private float alfa = 0;


        public Pikachu(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            Coordinates();

            figureFrontArraysBase = new Point3D[][]
           {
                bodyF, headF, leftLegF, rightLegF, mouthF, rightEyeF, leftEyeF, nosF, rightArmF, leftArmF, leftChickF, rightChickF, 
               leftEarF, rightEarF, tailF
           };

            figureBackArraysBase = new Point3D[][]
            {
                bodyB, headB, leftLegB, rightLegB, mouthF, rightEyeB, leftEyeB, nosB, rightArmB, leftArmB, leftChickB, rightChickB, leftEarB,
                rightEarB, tailB
            };

            figureFrontArrays = CopyArray(figureFrontArraysBase);
            figureBackArrays = CopyArray(figureBackArraysBase);

            // Инициализация начальных координат соединений точек по оси Z
            zAxisConnectionsFront = new Point3D[bodyF.Length + headF.Length + leftLegF.Length + rightLegF.Length + mouthF.Length +
                rightEyeF.Length + leftEyeF.Length + nosF.Length + rightArmF.Length + leftArmF.Length + leftChickF.Length + 
                rightChickF.Length + leftEarF.Length + rightEarF.Length + tailF.Length];
            zAxisConnectionsBack = new Point3D[bodyB.Length + headB.Length + leftLegB.Length + rightLegB.Length + mouthF.Length +
                rightEyeB.Length + leftEyeB.Length + nosB.Length + rightArmB.Length + leftArmB.Length + leftChickB.Length +
                rightChickB.Length + leftEarB.Length + rightEarB.Length + tailB.Length];

            int index = 0;

            for (int i = 0; i < bodyF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(bodyF[i].X, bodyF[i].Y, bodyF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(bodyB[i].X, bodyB[i].Y, bodyB[i].Z);
                index++;
            }

            for (int i = 0; i < headF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(headF[i].X, headF[i].Y, headF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(headB[i].X, headB[i].Y, headB[i].Z);
                index++;
            }

            for (int i = 0; i < leftLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftLegF[i].X, leftLegF[i].Y, leftLegF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftLegB[i].X, leftLegB[i].Y, leftLegB[i].Z);
                index++;
            }

            for (int i = 0; i < rightLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightLegF[i].X, rightLegF[i].Y, rightLegF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightLegB[i].X, rightLegB[i].Y, rightLegB[i].Z);
                index++;
            }

            for (int i = 0; i < mouthF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(mouthF[i].X, mouthF[i].Y, mouthF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(mouthF[i].X, mouthF[i].Y, mouthF[i].Z);
                index++;
            }

            for (int i = 0; i < rightEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightEyeF[i].X, rightEyeF[i].Y, rightEyeF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightEyeB[i].X, rightEyeB[i].Y, rightEyeB[i].Z);
                index++;
            }
            
            for (int i = 0; i < leftEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftEyeF[i].X, leftEyeF[i].Y, leftEyeF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftEyeB[i].X, leftEyeB[i].Y, leftEyeB[i].Z);
                index++;
            }
            
            for (int i = 0; i < nosF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(nosF[i].X, nosF[i].Y, nosF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(nosB[i].X, nosB[i].Y, nosB[i].Z);
                index++;
            }
            
            for (int i = 0; i < rightArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightArmF[i].X, rightArmF[i].Y, rightArmF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightArmB[i].X, rightArmB[i].Y, rightArmB[i].Z);
                index++;
            }
            
            for (int i = 0; i < leftArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftArmF[i].X, leftArmF[i].Y, leftArmF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftArmB[i].X, leftArmB[i].Y, leftArmB[i].Z);
                index++;
            }
            
            for (int i = 0; i < leftChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftChickF[i].X, leftChickF[i].Y, leftChickF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftChickB[i].X, leftChickB[i].Y, leftChickB[i].Z);
                index++;
            }
            
            for (int i = 0; i < rightChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightChickF[i].X, rightChickF[i].Y, rightChickF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightChickB[i].X, rightChickB[i].Y, rightChickB[i].Z);
                index++;
            }
            
            for (int i = 0; i < leftEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(leftEarF[i].X, leftEarF[i].Y, leftEarF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(leftEarB[i].X, leftEarB[i].Y, leftEarB[i].Z);
                index++;
            }
            
            for (int i = 0; i < rightEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(rightEarF[i].X, rightEarF[i].Y, rightEarF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(rightEarB[i].X, rightEarB[i].Y, rightEarB[i].Z);
                index++;
            }
            
            for (int i = 0; i < tailF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(tailF[i].X, tailF[i].Y, tailF[i].Z);
                zAxisConnectionsBack[index] = new Point3D(tailB[i].X, tailB[i].Y, tailB[i].Z);
                index++;
            }

        }

        private void Coordinates()
        {
            //Передние части
            bodyF = new Point3D[]
            {
                new Point3D (-3, 1, 0),
                new Point3D (-3,-5, 0),
                new Point3D (4,-5, 0),
                new Point3D (4,1, 0)
            };

            headF = new Point3D[]
            {
                new Point3D (-4, 8, 1),
                new Point3D (5,8, 1),
                new Point3D (5,1, 1),
                new Point3D (-4,1, 1)
            };

            tailF = new Point3D[]
           {
                new Point3D(-3,-4, -4),
                new Point3D(-5,-3, -4),
                new Point3D(-4,-2, -4),
                new Point3D(-8,0, -4),
                new Point3D(-7,2, -4),
                new Point3D(-3,-2, -4),
                new Point3D(-4,-3, -4),
                new Point3D(-3,-3, -4)
           };

            leftEarF = new Point3D[]
           {
                new Point3D(-3,8, 0),
                new Point3D(-2,10, 0),
                new Point3D(-1,8, 0)
           };

            rightEarF = new Point3D[]
           {
                new Point3D(2,8, 0),
                new Point3D(3,10, 0),
                new Point3D(4,8, 0)
           };

            leftLegF = new Point3D[]
            {
               new Point3D(-2,-5, 2),
               new Point3D(-2,-4, 2),
               new Point3D(0,-4, 2),
               new Point3D(0,-5, 2)
            };

            rightLegF = new Point3D[]
            {
                new Point3D(1,-5, 2),
                new Point3D(1,-4, 2),
                new Point3D(3, -4, 2), 
                new Point3D(3, -5, 2)
            };

            leftArmF = new Point3D[]
            {
                new Point3D(-3,-2, 2),
                new Point3D(-3,0, 2),
                new Point3D(-1,0, 2),
                new Point3D(-1,-2, 2)
            };
            rightArmF = new Point3D[]
            {
                new Point3D(2,0, 2),
                new Point3D(4,0, 2),
                new Point3D(4,-2, 2),
                new Point3D(2,-2, 2)
            };

            mouthF = new Point3D[]
            {
                new Point3D(0,3, 1),
                new Point3D(1,3, 1),
                new Point3D(1,2, 1),
                new Point3D(0,2, 1)
            };

            rightEyeF = new Point3D[]
            {
                new Point3D(2,7, 1.1),
                new Point3D(3,7, 1.1),
                new Point3D(3,6, 1.1),
                new Point3D(2,6, 1.1)
            };

            leftEyeF = new Point3D[]
            {
                new Point3D(-2,7, 1.1),
                new Point3D(-1,7, 1.1),
                new Point3D(-1,6, 1.1),
                new Point3D(-2,6, 1.1)
            };

            leftChickF = new Point3D[]
            {
                new Point3D(-3,5, 1.2),
                new Point3D(-1,5, 1.2),
                new Point3D(-1,3, 1.2),
                new Point3D(-3,3, 1.2)
            };

            rightChickF = new Point3D[]
            {
                new Point3D(2,5, 1.2),
                new Point3D(4,5, 1.2),
                new Point3D(4,3, 1.2),
                new Point3D(2,3, 1.2)
            };

            nosF = new Point3D[]
            {
                new Point3D(0,5, 1.3),
                new Point3D(1,5, 1.3),
                new Point3D(1,4, 1.3),
                new Point3D(0,4, 1.3)
            };

            //Задние части
            bodyB = new Point3D[]
            {
                new Point3D (-3, 1, -4),
                new Point3D (-3,-5, -4),
                new Point3D (4,-5, -4),
                new Point3D (4,1, -4)
            };

            headB = new Point3D[]
            {
                new Point3D (-4, 8, -5),
                new Point3D (5,8, -5),
                new Point3D (5,1, -5),
                new Point3D (-4,1, -5)
            };

            tailB = new Point3D[]
           {
                new Point3D(-3,-4, -5),
                new Point3D(-5,-3, -5),
                new Point3D(-4,-2, -5),
                new Point3D(-8,0, -5),
                new Point3D(-7,2, -5),
                new Point3D(-3,-2, -5),
                new Point3D(-4,-3, -5),
                new Point3D(-3,-3, -5)
           };

            leftEarB = new Point3D[]
           {
                new Point3D(-3,8, -2),
                new Point3D(-2,10, -2),
                new Point3D(-1,8, -2)
           };

            rightEarB = new Point3D[]
           {
                new Point3D(2,8, -2),
                new Point3D(3,10, -2),
                new Point3D(4,8, -2)
           };

            leftLegB = new Point3D[]
            {
               new Point3D(-2,-5, 0),
               new Point3D(-2,-4, 0),
               new Point3D(0,-4, 0),
               new Point3D(0,-5, 0)
            };

            rightLegB = new Point3D[]
            {
                new Point3D(1,-5, 0),
                new Point3D(1,-4, 0),
                new Point3D(3, -4, 0),
                new Point3D(3, -5, 0)
            };

            leftArmB = new Point3D[]
            {
                new Point3D(-3,-2, 0),
                new Point3D(-3,0, 0),
                new Point3D(-1,0, 0),
                new Point3D(-1,-2, 0)
            };
            rightArmB = new Point3D[]
            {
                new Point3D(2,0, 0),
                new Point3D(4,0, 0),
                new Point3D(4,-2, 0),
                new Point3D(2,-2, 0)
            };

            rightEyeB = new Point3D[]
            {
                new Point3D(2,7, 1),
                new Point3D(3,7, 1),
                new Point3D(3,6, 1),
                new Point3D(2,6, 1)
            };

            leftEyeB = new Point3D[]
            {
                new Point3D(-2,7, 1),
                new Point3D(-1,7, 1),
                new Point3D(-1,6, 1),
                new Point3D(-2,6, 1)
            };

            leftChickB = new Point3D[]
            {
                new Point3D(-3,5, 1),
                new Point3D(-1,5, 1),
                new Point3D(-1,3, 1),
                new Point3D(-3,3, 1)
            };

            rightChickB = new Point3D[]
            {
                new Point3D(2,5, 1),
                new Point3D(4,5, 1),
                new Point3D(4,3, 1),
                new Point3D(2,3, 1)
            };

            nosB = new Point3D[]
            {
                new Point3D(0,5, 1),
                new Point3D(1,5, 1),
                new Point3D(1,4, 1),
                new Point3D(0,4, 1)
            };

        }



        public void Draw()
        {
            ClearCanvas();

            MultiplyCoordinatesByCell();

            Pen blackPen = new Pen(Color.Black);
            SolidBrush yellowFill = new SolidBrush(Color.Yellow);
            SolidBrush blackFill = new SolidBrush(Color.Black);
            SolidBrush redFill = new SolidBrush(Color.Red);
            SolidBrush pinkFill = new SolidBrush(Color.Pink);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int centerX = pictureBox.Width / 2;
                int centerY = pictureBox.Height / 2;

                Matrix transformationMatrix = new Matrix();
                transformationMatrix.Translate(centerX, centerY);
                transformationMatrix.Scale(1, -1);


                g.Transform = transformationMatrix;

                DrawAndFillPolygons(g, blackPen, figureFrontArrays);
                DrawAndFillPolygons(g, blackPen, figureBackArrays);


                //DrawAndFillPolygons(g, yellowFill, blackPen, bodyF, headF, rightEarF, leftEarF, tailF,
                //    bodyB, headB, rightEarB, leftEarB, tailB);
                //DrawAndFillPolygons(g, blackFill, blackPen, rightEyeF, leftEyeF, rightArmF, leftArmF, nosF, rightLegF, leftLegF, 
                //    rightEyeB, leftEyeB, rightArmB, leftArmB, nosB, rightLegB, leftLegB);
                //DrawAndFillPolygons(g, pinkFill, blackPen, mouthF);
                //DrawAndFillPolygons(g, redFill, blackPen, rightChickF, leftChickF, rightChickB, leftChickB);

                DrawZAxisConnections(g, blackPen);

            }

            pictureBox.Image = bmp;

            CopyBaseCoordinatesToFigures();
        }

        public void ClearCanvas()
        {
            pictureBox.Image = null;
            bmp = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
        }

        private void DrawAndFillPolygons(Graphics g, Pen drawPen, params Point3D[][] polygons)
        {
            foreach (var polygon in polygons)
            {
                var points2D = new PointF[polygon.Length];
                for (int i = 0; i < polygon.Length; i++)
                {
                    points2D[i] = new PointF((float)polygon[i].X, (float)polygon[i].Y);
                }
                g.DrawPolygon(drawPen, points2D);
            }
        }

        private void DrawZAxisConnections(Graphics g, Pen drawPen)
        {
            for (int i = 0; i < zAxisConnectionsFront.Length; i++)
            {
                g.DrawLine(drawPen, (float)zAxisConnectionsFront[i].X, (float)zAxisConnectionsFront[i].Y,
                    (float)zAxisConnectionsBack[i].X, (float)zAxisConnectionsBack[i].Y);
            }
        }

        public void RotateX(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'X');
            Draw();
        }

        public void RotateY(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Y');
            Draw();
        }

        public void RotateZ(int angleInDegrees)
        {
            ApplyRotationToFigure(angleInDegrees, 'Z');
            Draw();
        }

        private void ApplyRotationToFigure(float angleInDegrees, char axis)
        {
            alfa += angleInDegrees;
            // Преобразование угла из градусов в радианы
            float angleInRadians = (float)(alfa * Math.PI / 180);

            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    float x = (float)figureFrontArraysBase[i][j].X;
                    float y = (float)figureFrontArraysBase[i][j].Y;
                    float z = (float)figureFrontArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(angleInRadians) - z * (float)Math.Sin(angleInRadians);
                        newZ = y * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) + z * (float)Math.Sin(angleInRadians);
                        newZ = -x * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) - y * (float)Math.Sin(angleInRadians);
                        newY = x * (float)Math.Sin(angleInRadians) + y * (float)Math.Cos(angleInRadians);
                        newZ = z;
                    }

                    figureFrontArrays[i][j] = new Point3D(newX, newY, newZ);

                    // Обновление угла в градусах
                    figureFrontArrays[i][j].Z = angleInDegrees;
                }
            }

            // Обновление координат соединений точек по оси Z для фронтальной стороны
            UpdateZAxisConnectionsFront();

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    float x = (float)figureBackArraysBase[i][j].X;
                    float y = (float)figureBackArraysBase[i][j].Y;
                    float z = (float)figureBackArraysBase[i][j].Z;

                    float newX = 0, newY = 0, newZ = 0;

                    if (axis == 'X')
                    {
                        newY = y * (float)Math.Cos(angleInRadians) - z * (float)Math.Sin(angleInRadians);
                        newZ = y * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newX = x;
                    }
                    else if (axis == 'Y')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) + z * (float)Math.Sin(angleInRadians);
                        newZ = -x * (float)Math.Sin(angleInRadians) + z * (float)Math.Cos(angleInRadians);
                        newY = y;
                    }
                    else if (axis == 'Z')
                    {
                        newX = x * (float)Math.Cos(angleInRadians) - y * (float)Math.Sin(angleInRadians);
                        newY = x * (float)Math.Sin(angleInRadians) + y * (float)Math.Cos(angleInRadians);
                        newZ = z;
                    }

                    figureBackArrays[i][j] = new Point3D(newX, newY, newZ);

                    // Обновление угла в градусах
                    figureBackArrays[i][j].Z = angleInDegrees;
                }
            }

            // Обновление координат соединений точек по оси Z для задней стороны
            UpdateZAxisConnectionsBack();
        }

        private void UpdateZAxisConnectionsFront()
        {
            int index = 0;

            for (int i = 0; i < bodyF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[0][i].X, figureFrontArrays[0][i].Y, figureFrontArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[1][i].X, figureFrontArrays[1][i].Y, figureFrontArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[2][i].X, figureFrontArrays[2][i].Y, figureFrontArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[3][i].X, figureFrontArrays[3][i].Y, figureFrontArrays[3][i].Z);
                index++;
            }

            for (int i = 0; i < mouthF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[4][i].X, figureFrontArrays[4][i].Y, figureFrontArrays[4][i].Z);
                index++;
            }

            for (int i = 0; i < rightEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[5][i].X, figureFrontArrays[5][i].Y, figureFrontArrays[5][i].Z);
                index++;
            }

            for (int i = 0; i < leftEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[6][i].X, figureFrontArrays[6][i].Y, figureFrontArrays[6][i].Z);
                index++;
            }

            for (int i = 0; i < nosF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[7][i].X, figureFrontArrays[7][i].Y, figureFrontArrays[7][i].Z);
                index++;
            }

            for (int i = 0; i < rightArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[8][i].X, figureFrontArrays[8][i].Y, figureFrontArrays[8][i].Z);
                index++;
            }

            for (int i = 0; i < leftArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[9][i].X, figureFrontArrays[9][i].Y, figureFrontArrays[9][i].Z);
                index++;
            }

            for (int i = 0; i < leftChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[10][i].X, figureFrontArrays[10][i].Y, figureFrontArrays[10][i].Z);
                index++;
            }

            for (int i = 0; i < rightChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[11][i].X, figureFrontArrays[11][i].Y, figureFrontArrays[11][i].Z);
                index++;
            }

            for (int i = 0; i < leftEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[12][i].X, figureFrontArrays[12][i].Y, figureFrontArrays[12][i].Z);
                index++;
            }

            for (int i = 0; i < rightEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[13][i].X, figureFrontArrays[13][i].Y, figureFrontArrays[13][i].Z);
                index++;
            }

            for (int i = 0; i < tailF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[14][i].X, figureFrontArrays[14][i].Y, figureFrontArrays[14][i].Z);
                index++;
            }
        }

        private void UpdateZAxisConnectionsBack()
        {
            int index = 0;

            for (int i = 0; i < bodyB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[0][i].X, figureBackArrays[0][i].Y, figureBackArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[1][i].X, figureBackArrays[1][i].Y, figureBackArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[2][i].X, figureBackArrays[2][i].Y, figureBackArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[3][i].X, figureBackArrays[3][i].Y, figureBackArrays[3][i].Z);
                index++;
            }

            for (int i = 0; i < mouthF.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[4][i].X, figureBackArrays[4][i].Y, figureBackArrays[4][i].Z);
                index++;
            }


            for (int i = 0; i < rightEyeB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[5][i].X, figureBackArrays[5][i].Y, figureBackArrays[5][i].Z);
                index++;
            }

            for (int i = 0; i < leftEyeB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[6][i].X, figureBackArrays[6][i].Y, figureBackArrays[6][i].Z);
                index++;
            }

            for (int i = 0; i < nosB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[7][i].X, figureBackArrays[7][i].Y, figureBackArrays[7][i].Z);
                index++;
            }

            for (int i = 0; i < rightArmB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[8][i].X, figureBackArrays[8][i].Y, figureBackArrays[8][i].Z);
                index++;
            }

            for (int i = 0; i < leftArmB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[9][i].X, figureBackArrays[9][i].Y, figureBackArrays[9][i].Z);
                index++;
            }

            for (int i = 0; i < leftChickB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[10][i].X, figureBackArrays[10][i].Y, figureBackArrays[10][i].Z);
                index++;
            }

            for (int i = 0; i < rightChickB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[11][i].X, figureBackArrays[11][i].Y, figureBackArrays[11][i].Z);
                index++;
            }

            for (int i = 0; i < leftEarB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[12][i].X, figureBackArrays[12][i].Y, figureBackArrays[12][i].Z);
                index++;
            }

            for (int i = 0; i < rightEarB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[13][i].X, figureBackArrays[13][i].Y, figureBackArrays[13][i].Z);
                index++;
            }

            for (int i = 0; i < tailB.Length; i++)
            {
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[14][i].X, figureBackArrays[14][i].Y, figureBackArrays[14][i].Z);
                index++;
            }

        }

        private void UpdateZAxisConnections()
        {
            int index = 0;

            for (int i = 0; i < bodyF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[0][i].X, figureFrontArrays[0][i].Y, figureFrontArrays[0][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[0][i].X, figureBackArrays[0][i].Y, figureBackArrays[0][i].Z);
                index++;
            }

            for (int i = 0; i < headF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[1][i].X, figureFrontArrays[1][i].Y, figureFrontArrays[1][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[1][i].X, figureBackArrays[1][i].Y, figureBackArrays[1][i].Z);
                index++;
            }

            for (int i = 0; i < leftLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[2][i].X, figureFrontArrays[2][i].Y, figureFrontArrays[2][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[2][i].X, figureBackArrays[2][i].Y, figureBackArrays[2][i].Z);
                index++;
            }

            for (int i = 0; i < rightLegF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[3][i].X, figureFrontArrays[3][i].Y, figureFrontArrays[3][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[3][i].X, figureBackArrays[3][i].Y, figureBackArrays[3][i].Z);
                index++;
            }

            for (int i = 0; i < mouthF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[4][i].X, figureFrontArrays[4][i].Y, figureFrontArrays[4][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[4][i].X, figureBackArrays[4][i].Y, figureBackArrays[4][i].Z);
                index++;
            }

            for (int i = 0; i < rightEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[5][i].X, figureFrontArrays[5][i].Y, figureFrontArrays[5][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[5][i].X, figureBackArrays[5][i].Y, figureBackArrays[5][i].Z);
                index++;
            }

            for (int i = 0; i < leftEyeF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[6][i].X, figureFrontArrays[6][i].Y, figureFrontArrays[6][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[6][i].X, figureBackArrays[6][i].Y, figureBackArrays[6][i].Z);
                index++;
            }

            for (int i = 0; i < nosF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[7][i].X, figureFrontArrays[7][i].Y, figureFrontArrays[7][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[7][i].X, figureBackArrays[7][i].Y, figureBackArrays[7][i].Z);
                index++;
            }

            for (int i = 0; i < rightArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[8][i].X, figureFrontArrays[8][i].Y, figureFrontArrays[8][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[8][i].X, figureBackArrays[8][i].Y, figureBackArrays[8][i].Z);
                index++;
            }

            for (int i = 0; i < leftArmF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[9][i].X, figureFrontArrays[9][i].Y, figureFrontArrays[9][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[9][i].X, figureBackArrays[9][i].Y, figureBackArrays[9][i].Z);
                index++;
            }

            for (int i = 0; i < leftChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[10][i].X, figureFrontArrays[10][i].Y, figureFrontArrays[10][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[10][i].X, figureBackArrays[10][i].Y, figureBackArrays[10][i].Z);
                index++;
            }

            for (int i = 0; i < rightChickF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[11][i].X, figureFrontArrays[11][i].Y, figureFrontArrays[11][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[11][i].X, figureBackArrays[11][i].Y, figureBackArrays[11][i].Z);
                index++;
            }

            for (int i = 0; i < leftEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[12][i].X, figureFrontArrays[12][i].Y, figureFrontArrays[12][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[12][i].X, figureBackArrays[12][i].Y, figureBackArrays[12][i].Z);
                index++;
            }

            for (int i = 0; i < rightEarF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[13][i].X, figureFrontArrays[13][i].Y, figureFrontArrays[13][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[13][i].X, figureBackArrays[13][i].Y, figureBackArrays[13][i].Z);
                index++;
            }

            for (int i = 0; i < tailF.Length; i++)
            {
                zAxisConnectionsFront[index] = new Point3D(figureFrontArrays[14][i].X, figureFrontArrays[14][i].Y, figureFrontArrays[14][i].Z);
                zAxisConnectionsBack[index] = new Point3D(figureBackArrays[14][i].X, figureBackArrays[14][i].Y, figureBackArrays[14][i].Z);
                index++;
            }

        }

        private Point3D[][] CopyArray(Point3D[][] source)
        {
            Point3D[][] copy = new Point3D[source.Length][];

            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = new Point3D[source[i].Length];

                for (int j = 0; j < source[i].Length; j++)
                {
                    copy[i][j] = new Point3D(
                        source[i][j].X,
                        source[i][j].Y,
                        source[i][j].Z
                    );
                }
            }

            return copy;
        }

        private void MultiplyCoordinatesByCell()
        {
            double CELL = 20; // Замените это значение на нужное вам

            // Пройдемся по всем координатам и умножим их на CELL
            foreach (var array in figureFrontArrays)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].X *= CELL;
                    array[i].Y *= CELL;
                    array[i].Z *= CELL;
                }
            }

            foreach (var array in figureBackArrays)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].X *= CELL;
                    array[i].Y *= CELL;
                    array[i].Z *= CELL;
                }
            }

            for (int i = 0; i < zAxisConnectionsFront.Length; i++)
            {
                zAxisConnectionsFront[i].X *= CELL;
                zAxisConnectionsFront[i].Y *= CELL;
                zAxisConnectionsFront[i].Z *= CELL;
            }

            for (int i = 0; i < zAxisConnectionsBack.Length; i++)
            {
                zAxisConnectionsBack[i].X *= CELL;
                zAxisConnectionsBack[i].Y *= CELL;
                zAxisConnectionsBack[i].Z *= CELL;
            }
        }

        private double scale_X = 1;
        private double scale_Y = 1;
        private double scale_Z = 1;

        public void Scale(double scaleX, double scaleY, double scaleZ)
        {
            scale_X *= scaleX;
            scale_Y *= scaleY;
            scale_Z *= scaleZ;

            // Масштабирование фигуры в глобальных координатах
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                ScaleFigure(figureFrontArrays[i], scale_X, scale_Y, scale_Z);
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                ScaleFigure(figureBackArrays[i], scale_X, scale_Y, scale_Z);
            }

            // Масштабирование матрицы соединений
            ScaleMatrix(zAxisConnectionsFront, scale_X, scale_Y, scale_Z);
            ScaleMatrix(zAxisConnectionsBack, scale_X, scale_Y, scale_Z);

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            // Отобразить масштабированную фигуру
            Draw();
        }

        private void ScaleFigure(Point3D[] figure, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i].X *= scaleX;
                figure[i].Y *= scaleY;
                figure[i].Z *= scaleZ;
            }
        }

        private void ScaleMatrix(Point3D[] matrix, double scaleX, double scaleY, double scaleZ)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].X *= scaleX;
                matrix[i].Y *= scaleY;
                matrix[i].Z *= scaleZ;
            }
        }

        public void Move(int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                MoveFigure(figureFrontArrays[i], deltaX, deltaY, deltaZ);
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                MoveFigure(figureBackArrays[i], deltaX, deltaY, deltaZ);
            }

            // Обновление координат соединений точек по оси Z
            UpdateZAxisConnections();

            Draw();
        }

        private void MoveFigure(Point3D[] figure, int deltaX, int deltaY, int deltaZ)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i] = new Point3D(
                    figure[i].X + deltaX,
                    figure[i].Y + deltaY,
                    figure[i].Z + deltaZ
                );
            }
        }




        public void ConvertToCabine()
        {
            alfa += 40;

            ApplyRotationToFigure(alfa, 'Y');

            // Углы поворота
            double theta = Math.PI / 6; // 45 градусов
            double phi = 0; // 63.4 градуса

            // Создаем матрицу проекции Кабине
            Matrix3D cabineProjection = new Matrix3D(new double[,] {
                                        { Math.Cos(theta), Math.Sin(theta) * Math.Sin(phi), 0, 0 },
                                        { 0, Math.Cos(phi), 0, 0 },
                                        { Math.Sin(theta), -Math.Cos(theta) * Math.Sin(phi), 0, 0 },
                                        { 0, 0, 0, 1 }
                                    });

            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    figureFrontArrays[i][j] = cabineProjection.Transform(figureFrontArrays[i][j]);
                }
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    figureBackArrays[i][j] = cabineProjection.Transform(figureBackArrays[i][j]);
                }
            }

            UpdateZAxisConnections();

            Draw();

        }

        private void CopyBaseCoordinatesToFigures()
        {
            for (int i = 0; i < figureFrontArrays.Length; i++)
            {
                for (int j = 0; j < figureFrontArrays[i].Length; j++)
                {
                    figureFrontArrays[i][j] = new Point3D(
                        figureFrontArraysBase[i][j].X,
                        figureFrontArraysBase[i][j].Y,
                        figureFrontArraysBase[i][j].Z
                    );
                }
            }

            for (int i = 0; i < figureBackArrays.Length; i++)
            {
                for (int j = 0; j < figureBackArrays[i].Length; j++)
                {
                    figureBackArrays[i][j] = new Point3D(
                        figureBackArraysBase[i][j].X,
                        figureBackArraysBase[i][j].Y,
                        figureBackArraysBase[i][j].Z
                    );
                }
            }

            // Также обновите координаты соединений по оси Z
            UpdateZAxisConnectionsFront();
            UpdateZAxisConnectionsBack();
        }

    }

    public class Matrix3D
    {
        private double[,] matrix;

        public Matrix3D(double[,] values)
        {
            if (values.GetLength(0) != 4 || values.GetLength(1) != 4)
                throw new ArgumentException("Matrix size must be 4x4.");

            matrix = values;
        }

        public Point3D Transform(Point3D point)
        {
            double x = point.X * matrix[0,0] + point.Y * matrix[0, 1] + point.Z * matrix[0, 2] + matrix[0, 3];
            double y = point.X * matrix[1,0] + point.Y * matrix[1, 1] + point.Z * matrix[1, 2] + matrix[1, 3];
            double z = point.X * matrix[2, 0] + point.Y * matrix[2, 1] + point.Z * matrix[2, 2] + matrix[2, 3];

            return new Point3D(x, y, z);
        }
    }

}
