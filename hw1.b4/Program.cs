using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shapes
{
    public abstract class Shape
    {
        public abstract double area
        { get; set; }
        public abstract void valid();
    }
    public class Square : Shape
    {
        private int width;
        public Square(int width)
        {
            this.width = width;
        }
        public override double area 
        {
            get
            {
                if (width > 0)
                    return width * width;
                else return 0;
            }
            set
            {
                area = width * width;
            }
        }
        public override void valid() 
        {
            if (width <= 0)
                Console.WriteLine("This square is not valid. ");
            else Console.WriteLine("This square is valid. ");
        }
    }
    public class Rectangle : Shape
    {
        private int width, length;
        public Rectangle(int width, int length)
        {
            this.width = width;
            this.length = length;
        }
        public override double area
        {
            get
            {
                if (width > 0 && length > 0) 
                    return width * length;
                else return 0;
            }
            set
            {
                area = width * length;
            }
        }
        public override void valid()
        {
            if (width <= 0 || length <= 0) 
                Console.WriteLine("This rectangle is not valid. ");
            else Console.WriteLine("This rectangle is valid. ");
        }
    }
    public class Triangle : Shape
    {
        private int side1, side2, side3;
        public Triangle(int side1, int side2, int side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public override double area
        {
            get
            {
                if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1
                    && side1 > 0 && side2 > 0 && side3 > 0)  
                {
                    double p = Convert.ToDouble((side1 + side2 + side3)) / 2.0;
                    return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
                }
                else return 0;
            }
            set
            {
                double p = Convert.ToDouble((side1 + side2 + side3)) / 2.0;
                area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            }
        }
        public override void valid()
        {
            if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1
                    && side1 > 0 && side2 > 0 && side3 > 0)
                Console.WriteLine("This triangle is valid. ");
            else Console.WriteLine("This triangle is not valid. ");
        }
    }
    public class Mainclass
    {
        public static void Main(string[] args)
        {
            Shape square1 = new Square(5);
            Console.WriteLine(square1.area);
            square1.valid();
            Shape square2 = new Square(-1);
            Console.WriteLine(square2.area);
            square2.valid();

            Shape rectangle1= new Rectangle(5, 10);
            Console.WriteLine(rectangle1.area);
            rectangle1.valid();
            Shape rectangle2 = new Rectangle(5, -10);
            Console.WriteLine(rectangle2.area);
            rectangle2.valid();

            Shape triangle1 = new Triangle(3, 4, 5);
            Console.WriteLine(triangle1.area);
            triangle1.valid();
            Shape triangle2 = new Triangle(3, 4, 9);
            Console.WriteLine(triangle2.area);
            triangle2.valid();
        }
    }
}