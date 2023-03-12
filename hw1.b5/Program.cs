using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shapes
{
    public class Factory
    {
        public static Shape GetShape(string str, int side1, int side2 = 0, int side3 = 0)
        {
            Shape shape;
            if (str.Equals("Square"))
            {
                shape = new Square(side1);
            }
            else if (str.Equals("Rectangle"))
            {
                shape = new Rectangle(side1, side2);
            }
            else shape = new Triangle(side1, side2, side3);
            return shape;
        }
    }
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
            Shape[] shapes =
            {
                Factory.GetShape("Square",10), Factory.GetShape("Square",15),Factory.GetShape("Square",20),
                Factory.GetShape("Rectangle",10,5), Factory.GetShape("Rectangle",15,10),
                Factory.GetShape("Rectangle",3,5), Factory.GetShape("Rectangle",5,8),
                Factory.GetShape("Triangle",3,4,5), Factory.GetShape("Triangle",6,8,10),
                Factory.GetShape("Triangle",5,12,13)
            };
            double sum = 0.0;
            for (int i = 0; i < shapes.Length; i++) 
            {
                sum += shapes[i].area;
            }
            Console.WriteLine(sum);
        }
    }
}
