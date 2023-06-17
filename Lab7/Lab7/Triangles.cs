using System;

namespace Lab7
{
    class Triangle : IEquilateralTriangle, IScaleneTriangle, IRightTriangle, IIsoscelesTriangle
    {
        public double side { set; get; }
        public double baseSide { set; get; }
        public double side1 { set; get; }
        public double side2 { set; get; }
        public double side3 { set; get; }

        double perimeter, area, innerRadius, outerRadius;

        public Triangle(double a, double b, double c)
        {
            if (existsAsTriangle(a, b, c))
            {
                side1 = a;
                side2 = b;
                side3 = c;
            }
            else
            {
                printCreationError();
            }
            calculatePerimeter();
        }

        public Triangle(double side, double baseSide)
        {
            if (existsAsTriangle(side, side, baseSide))
            {
                this.side = side;
                this.baseSide = baseSide;
                side1 = side;
                side2 = side;
                side3 = side;
            }
            else
            {
                printCreationError();
            }
            calculatePerimeter();
        }

        public Triangle(double side)
        {
            if (existsAsTriangle(side, side, side))
            {
                this.side = side;
                side1 = side;
                side2 = side;
                side3 = side;
            }
            else
            {
                printCreationError();
            }
            calculatePerimeter();
        }

        void printCreationError()
        {
            Console.WriteLine("Створити трикутник неможливо: " +
        "данi вiдрiзки не можуть утворювати трикутник.");
        }

        public bool existsAsTriangle(double a, double b, double c)
        {
            if (valueCheck(a, b, c) && lengthCheck(a, b, c))
            {
                return true;
            }
            return false;
        }

        bool valueCheck(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                return true;
            }
            return false;
        }


        bool lengthCheck(double a, double b, double c)
        {
            if (a + b > c || a + c > b || b + c > a)
            {
                return true;
            }
            return false;
        }

        void calculatePerimeter()
        {
            perimeter = side1 + side2 + side3;
        }

        public void printPerimeter()
        {
            Console.WriteLine("Значення периметру для цього трикутника: " + perimeter);
        }

        void setArea()
        {
            double p = perimeter / 2;
            area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        void IScaleneTriangle.calculateArea()
        {
            Console.WriteLine("Площу рiзностороннього трикутника можна знайти за формулами:" +
        "\nS = sqrt(p(p - a)(p - b)(p - c));" +
        "\n де S -- площа, a, b, c -- сторони, p -- пiвпериметр трикутника.");

            double p = perimeter / 2;

            double area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            Console.WriteLine("Значення площi для даного трикутника: " +
                Math.Round(area, 4) + "...");
            this.area = area;
        }

        void IEquilateralTriangle.calculateArea()
        {
            Console.WriteLine("Площу рiвностороннього трикутника можна знайти за формулами:" +
                "\nS = 0.5 * a * h);" +
                "\nS = sqrt(3)/4 * a^2;" +
                "\nде S -- площа, a -- сторона, h -- висота.");

            double area = side1 * Math.Sqrt(3) / 4 * side1 * side1;

            Console.WriteLine("Значення площi для даного трикутника: " + Math.Round(area, 4) + "...");
            this.area = area;
        }

        void IIsoscelesTriangle.calculateArea()
        {
            Console.WriteLine("Площу рiвнобедреного трикутника можна знайти за формулою:" +
            "\nS = 0.5 * b * h;" +
            "\nде S -- площа, b -- основа, h -- висота.");

            double area = 0.5 * side * baseSide;

            Console.WriteLine("Значення площi для даного трикутника: " +
                Math.Round(area, 4) + "...");
            this.area = area;
        }

        void IRightTriangle.calculateArea()
        {
            Console.WriteLine("Площу прямокутного трикутника можна знайти за формулою:" +
            "\nS = 0.5 * a * b" +
            "\nде S -- площа, a, b -- катети.");

            double area = side1 * side2 * 0.5;

            Console.WriteLine("Значення площi для даного трикутника: " +
                Math.Round(area, 4) + "...");
            this.area = area;
        }

        void IScaleneTriangle.calculateInnerRadius()
        {
            Console.WriteLine("Радiус кола вписаного в рiзностороннiй трикутник" +
            " можна знайти за формулою:" +
            "\nr = sqrt((p - a)(p - b)(p - c) / p)" +
            "\nде r -- радiус цього кола, p -- пiвпериметр.");

            double p = perimeter / 2;
            double r = Math.Sqrt((p - side1) * (p - side2) * (p - side3) / 3);

            Console.WriteLine("Значення радiуса кола вписаного в даний трикутник: " + 
                Math.Round(r, 4) + "...");
            this.innerRadius = r;
        }

        void IEquilateralTriangle.calculateInnerRadius()
        {
            Console.WriteLine("Радiус кола вписаного в рiзностороннiй трикутник" +
            " можна знайти за формулою:" +
            "\nr = a / 2 * sqrt(3))" +
            "\nде r -- радiус цього кола, a -- сторона.");

            double r = side / (2 * Math.Sqrt(3));

            Console.WriteLine("Значення радiуса кола вписаного в даний трикутник: " +
                Math.Round(r, 4) + "...");
            this.innerRadius = r;
        }

        void IIsoscelesTriangle.calculateInnerRadius()
        {
            Console.WriteLine("Радiус кола вписаного в рiвнобедрений трикутник" +
            " можна знайти за формулою:" +
            "\nr = b / 2 * sqrt((2 * a - b) / (2 * a + b))" +
            "\nде r -- радiус цього кола, a -- сторона, b -- основа.");

            if (area == 0)
                setArea();

            double r = (baseSide / 2) * Math.Sqrt((2 * side - baseSide) / (2 * area + baseSide));

            Console.WriteLine("Значення радiуса кола вписаного в даний трикутник: " + Math.Round(r, 4) + "...");
            this.innerRadius = r;
        }

        void IRightTriangle.calculateInnerRadius()
        {
            Console.WriteLine("Радiус кола вписаного в прямокутний трикутник" +
            " можна знайти за формулою:" +
            "\nr = (a + b - c) / 2" +
            "\nде r -- радiус цього кола, a, b -- катети, c -- гiпотенуза.");

            double r = side1 + side2 - side3 / 2;

            Console.WriteLine("Значення радiуса кола вписаного в даний трикутник: " + 
                Math.Round(r, 4) + "...");
            this.innerRadius = r;
        }

        void IScaleneTriangle.calculateOuterRadius()
        {
            Console.WriteLine("Радiус кола описаного навколо рiзностороннього трикутника" +
            " можна знайти за формулою:" +
            "\n(abc) / (4S)" +
        "   \nде a, b, c -- сторони трикутника, S -- площа трикутника");

            if (area == 0)
                setArea();

            double R = side1 + side2 - side3 / (4 * area);

            Console.WriteLine("Значення радiуса кола описаного навколо даного трикутника: " + 
                Math.Round(R, 4) + "...");
            this.outerRadius = R;
        }

        void IEquilateralTriangle.calculateOuterRadius()
        {
            Console.WriteLine("Радiус кола описаного навколо рiвностороннього трикутника" +
            " можна знайти за формулою:" +
            "\na / sqrt(3)" +
        "   \nде a -- сторона трикутника, S -- площа трикутника");

            double R = side / Math.Sqrt(3);

            Console.WriteLine("Значення радiуса кола описаного навколо даного трикутника: " + 
                Math.Round(R, 4) + "...");
            this.outerRadius = R;
        }

        void IIsoscelesTriangle.calculateOuterRadius()
        {
            Console.WriteLine("Радiус кола описаного навколо рiвнобедреного трикутника" +
            " можна знайти за формулою:" +
            "\na^2 / sqrt(4 * a^2 - b^2)" +
        "   \nде a -- сторона трикутника, b -- основа трикутника");
            double R = Math.Pow(side, 2) / Math.Sqrt(4 * Math.Pow(side, 2) - Math.Pow(baseSide, 2));

            Console.WriteLine("Значення радiуса кола описаного навколо даного трикутника: " +
                Math.Round(R, 4) + "...");
            this.outerRadius = R;
        }

        void IRightTriangle.calculateOuterRadius()
        {
            Console.WriteLine("Радiус кола описаного навколо прямокутного трикутника" +
            " - це половина гiпотенузи, оскiльки його центр лежить на її серединi");

            double R = side3 / 2;

            Console.WriteLine("Значення радiуса кола описаного навколо даного трикутника: " +
                Math.Round(R, 4) + "...");
            this.outerRadius = R;
        }

        public void printAllMembers()
        {
            Console.WriteLine("\nПериметр трикутника: " + perimeter);
            Console.WriteLine("Площа трикутника: " + area);
            Console.WriteLine("Радiус вписаноного кола: " + innerRadius);
            Console.WriteLine("Радiус описаного кола: " + outerRadius);
            Console.WriteLine();
        }
    }

    //рівносторонній трикутник
    public interface IEquilateralTriangle
    {
        double side { set; get; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }

    //рівнобедрений трикутник
    public interface IIsoscelesTriangle
    {
        double side { set; get; }
        double baseSide { get; set; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }

    //прямокутний трикутник
    public interface IRightTriangle
    {
        double side1 { set; get; }
        double side2 { set; get; }
        double side3 { set; get; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }

    //різносторонній трикутник
    public interface IScaleneTriangle
    {
        double side1 { set; get; }
        double side2 { get; set; }
        double side3 { get; set; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }
}
