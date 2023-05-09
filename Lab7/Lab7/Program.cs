using System;

class Program
{
    public static void Main(string[] args)
    {
        Program main = new Program();

        Triangle t1 = main.readTriangle();
        Console.WriteLine("Тип трикутника: " + t1.getType());
        t1.getAll();

        IEquilateralTriangle t2 = main.readTriangle();
        t2.getType();
        t2.getAll();

        ISceleneTriangle t3 = main.readTriangle();
        t3.getType();
        t3.getAll();

        IRightTriangle t4 = main.readTriangle();
        t4.getType();
        t4.getAll();

        IIsoscelesTriangle t5 = main.readTriangle();
        t5.getType();
        t5.getAll();
    }

    Triangle readTriangle()
    {
        Console.WriteLine("Введіть сторони трикутника:");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine();
        Triangle t = new Triangle(a, b, c);
        return t;
    }
}

class Triangle: IEquilateralTriangle, ISceleneTriangle, IRightTriangle, IIsoscelesTriangle
{
    double a, b, c;
    string type;

    public Triangle(double a, double b, double c)
    {
        if (valueCheck(a, b, c) && lengthCheck(a, b, c))
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            Console.WriteLine("Створити трикутник неможливо: " +
                "дані відрізки не можуть утворювати трикутник.");
        }
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

    public double getPerimeter()
    {
        return a + b + c;
    }

    public double getArea()
    {
        double p = getPerimeter() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double getInnerRadius()
    {
        return 2 * getArea() / getPerimeter();
    }

    public double getOuterRadius()
    {
        return (a * b * c) / (4 * getArea()); 
    }

    public string getType()
    {
        return "не визначено";
    }

    string IEquilateralTriangle.getType()
    {
        string type = "рівносторонній";
        Console.WriteLine("\nТип трикутника: '" + type + "'");
        return type;
    }

    string ISceleneTriangle.getType()
    {
        string type = "різносторонній";
        Console.WriteLine("\nТип трикутника: '" + type + "'");
        return type;
    }

    string IRightTriangle.getType()
    {
        string type = "прямокутний";
        Console.WriteLine("\nТип трикутника: '" + type + "'");
        return type;
    }

    string IIsoscelesTriangle.getType()
    {
        string type = "рівнобедрений";
        Console.WriteLine("\nТип трикутника: '" + type + "'");
        return type;
    }

    public void getAll()
    {
        Console.WriteLine("Сторони трикутника: " + a + ", " + b + ", " + c);
        Console.WriteLine("Периметр трикутника: " + getPerimeter());
        Console.WriteLine("Площа трикутника: " + getArea());
        Console.WriteLine("Радіус вписаноного кола: " + getInnerRadius());
        Console.WriteLine("Радіус описаного кола: " + getOuterRadius());
        Console.WriteLine();
    }
}



public interface IEquilateralTriangle
{
    double getPerimeter();
    double getArea();
    double getInnerRadius();
    double getOuterRadius();
    string getType();
    void getAll();
}

public interface ISceleneTriangle
{
    double getPerimeter();
    double getArea();
    double getInnerRadius();
    double getOuterRadius();
    string getType();
    void getAll();
}

public interface IRightTriangle
{
    double getPerimeter();
    double getArea();
    double getInnerRadius();
    double getOuterRadius();
    string getType();
    void getAll();
}

public interface IIsoscelesTriangle
{
    double getPerimeter();
    double getArea();
    double getInnerRadius();
    double getOuterRadius();
    string getType();
    void getAll();
}
