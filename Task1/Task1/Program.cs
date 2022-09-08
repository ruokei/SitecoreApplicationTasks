using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
public abstract class Shape
    {
        public abstract void move(double moveX, double moveY);
        public abstract void rotate(double rotateDegree, double originX, double originY);
        public abstract void toString();
    }

    public class Point : Shape
    {
        //Starting coordinates P(x,y)
        public double currentX, currentY;

        public Point(double x, double y)
        {
            this.currentX = x;
            this.currentY = y;
        }

        public override void move(double moveX, double moveY)
        {
            //Moving the object by x or y axis
            //P'(x + x0, y + y0) 
            this.currentX += moveX;
            this.currentY += moveY;
        }

        public override void rotate(double rotateDegree, double originX, double originY)
        {
            //Rotation of Axes 
            //X = xcos(θ) - ysin(θ)
            //Y = xsin(θ) + ycos(θ)

            //Rotation around Arbitrary Center
            //X = (x0 – xc)cos(θ) – (y0 – yc)sin(θ) + xc
            //Y = (x0 – xc)sin(θ) + (y0 – yc)cos(θ) + yc
            //O(xc, xy) is the new origin other than (0,0)

            double dx = this.currentX - originX; //Set origin for rotation, X
            double dy = this.currentY - originY; //Set origin for rotation, Y
            double cosTheta = Math.Cos(rotateDegree);
            double sinTheta = Math.Sin(rotateDegree);

            double calculateX = Math.Round((dx * cosTheta) - (dy * sinTheta) + originX, 2);
            double calculateY = Math.Round((dx * sinTheta) + (dy * cosTheta) + originY, 2);

            //Rotation (2 decimals)
            this.currentX = calculateX;
            this.currentY = calculateY;
        }

        public override void toString()
        {
            Console.WriteLine("Point: P({0}, {1})", this.currentX, this.currentY);
        }
    }

    public class Line : Shape
    {
        public Point lineStart, lineEnd;

        public Line(double startX, double startY, double endX, double endY)
        {
            this.lineStart = new Point(startX, startY);
            this.lineEnd = new Point(endX, endY);
        }

        public override void move(double moveX, double moveY)
        {
            //Both the start point and end point will move accordingly
            this.lineStart.move(moveX, moveY);
            this.lineEnd.move(moveX, moveY);
        }

        public override void rotate(double rotateDegree, double originX, double originY)
        {
            this.lineStart.rotate(rotateDegree, originX, originY);
            this.lineEnd.rotate(rotateDegree, originX, originY);
        }

        public override void toString()
        {
            Console.WriteLine("Line (2 points):");
            Console.WriteLine("The starting point is currently at A({0}, {1})", this.lineStart.currentX, this.lineStart.currentY);
            Console.WriteLine("The ending point is currently at B({0}, {1})", this.lineEnd.currentX, this.lineEnd.currentY);
        }
    }

    public class Circle : Shape
    {
        //a circle contains a center point and a radius
        public Point centerPoint;
        public double radius;

        public Circle(double centerX, double centerY, double radius)
        {
            this.centerPoint = new Point(centerX, centerY);
            this.radius = radius;
        }

        public override void move(double moveX, double moveY)
        {
            this.centerPoint.move(moveX, moveY);
        }

        public override void rotate(double rotateDegree, double originX, double originY)
        {
            this.centerPoint.rotate(rotateDegree, originX, originY);
        }

        public override void toString()
        {
            Console.WriteLine("Circle:");
            Console.Write("Center Point: P({0}, {1})", this.centerPoint.currentX, this.centerPoint.currentY);
            Console.WriteLine(" with a radius of {0}", this.radius);
        }
    }

    public class Aggregate : Shape
    {
        public ArrayList shapeList;

        public Aggregate()
        {
            this.shapeList = new ArrayList();
        }

        public void AddShape(Shape newShape)
        {
            this.shapeList.Add(newShape);
        }

        public override void move(double moveX, double moveY)
        {
            //Perform move for all the shapes within the ArrayList
            foreach (Shape s in this.shapeList)
                s.move(moveX, moveY);
        }

        public override void rotate(double rotateDegree, double originX, double originY)
        {
            //Perform rotation for all the shapes within the ArrayList
            foreach (Shape s in this.shapeList)
                s.rotate(rotateDegree, originX, originY);
        }

        public override void toString()
        {
            Console.WriteLine("All Shapes:");
            foreach (Shape s in this.shapeList)
            {
                Console.WriteLine("\nEntry: {0}", shapeList.IndexOf(s));
                s.toString();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("\nInitial Starting ");
            Point samplePoint = new Point(3, 4);
            samplePoint.toString();

            // Move by (0,1)
            Console.WriteLine("\nMove by (0, 1):");
            samplePoint.move(0, 1);
            samplePoint.toString();

            //Rotate anti clockwise 90 degrees
            //R'= (y, -x)
            Console.WriteLine("\nRotate anti clockwise 90 degrees:");
            samplePoint.rotate(Math.PI / 2, 0, 0);
            samplePoint.toString();

            //Rotate clockwise 180 degrees
            //A'= (-y, x)
            Console.WriteLine("\nRotate clockwise 180 degrees:");
            samplePoint.rotate(-Math.PI, 0, 0);
            samplePoint.toString();

            //Arbitrary Rotation (on (2, 1))
            Console.WriteLine("\nAnti clockwise 180 degrees Arbitrary Rotation on (2, 1):");
            samplePoint.rotate(Math.PI, 2, 1);
            samplePoint.toString();

            //Arbitrary Rotation (on ownself)
            //Point should not move (no reference point)
            Console.WriteLine("\nAnti clockwise 180 degrees Arbitrary Rotation on ownself:");
            samplePoint.rotate(Math.PI, samplePoint.currentX, samplePoint.currentY);
            samplePoint.toString();

            Console.WriteLine("\nInitial Starting Line:");
            Line sampleLine = new Line(1, 1, 4, 2); 
            sampleLine.toString();

            //Move by (2, 0)
            Console.WriteLine("\nMove by (2, 0):");
            sampleLine.move(1, 0); 
            sampleLine.toString();

            //Move by (-1, 0)
            Console.WriteLine("\nMove by (-1, 0):");
            sampleLine.move(-1, 0); 
            sampleLine.toString();

            //Rotate anti clockwise 180 degrees
            Console.WriteLine("\nRotate anti clockwise 180 degrees:");
            sampleLine.rotate(Math.PI, 0, 0); 
            sampleLine.toString();

            //Rotate clockwise 45 degrees
            Console.WriteLine("\nRotate clockwise 45 degrees:");
            sampleLine.rotate(-Math.PI/4, 0, 0);
            sampleLine.toString();

            //Circle with radius 4 centered at (-1, -1)
            Console.WriteLine("\nInitial Starting Circle:");
            Circle sampleCircle = new Circle(-1, -1, 4); 
            sampleCircle.toString();

            //Move by (4, 4)
            Console.WriteLine("\nMove by (4, 4):");
            sampleCircle.move(4, 4);
            sampleCircle.toString();

            //Rotate anti clockwise 90 degrees
            Console.WriteLine("\nRotate anti clockwise 90 degrees:");
            sampleCircle.rotate(Math.PI, 0, 0);
            sampleCircle.toString();

            //Rotate clockwise 45 degrees
            Console.WriteLine("\nRotate clockwise 45 degrees:");
            sampleCircle.rotate(-Math.PI/4, 0, 0);
            sampleCircle.toString();

            Aggregate agg = new Aggregate();
            agg.AddShape(new Point(3, 2));
            agg.AddShape(new Point(1, 2));

            agg.AddShape(new Circle(1, 1, 1));

            agg.AddShape(new Line(1, 1, 2, 2));
            agg.AddShape(new Line(-1, -1, -2, -2));
            agg.AddShape(new Line(3, 4, 5, 6));

            Console.Write("\nInitial Numbers of ");
            agg.toString();

            Console.WriteLine("\nMove by (3, 3):");
            agg.move(3, 3);
            agg.toString();

            Console.WriteLine("\nMove by (-4, -5):");
            agg.move(-4, -5);
            agg.toString();

            Console.WriteLine("\nRotate clockwise 45 degrees:");
            agg.rotate(-Math.PI/4, 0, 0);
            agg.toString();

            Console.ReadLine();
        }
    }
}

