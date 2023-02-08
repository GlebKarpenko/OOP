using System;
using System.Numerics;

class TRectangle
{
    protected double a, b;

    public TRectangle()
    {
        //empty
    }

    public TRectangle(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public TRectangle(TRectangle rect1)
    {
        a = rect1.a;
        b = rect1.b;
    }

    public double getA()
    {
        return this.a;
    }

    public double getB()
    {
        return this.b;
    }

    public virtual TRectangle read()
    {
        double a = 0, b = 0;
        try
        {
            Console.Write("\nВведiть сторорну a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nВведiть сторорну b: ");
            b = Convert.ToDouble(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Помилка вводу");
            read();
        }

        if (a <= 0 || b <= 0)
        {
            Console.WriteLine("Сторони повиннi бути бiльше 0");
            read();
        }

        TRectangle rect1 = new TRectangle(a, b);
        return rect1;
    }

    public virtual void print()
    {
        Console.Write("\nСторони фiгури: a: " + a + ", b: " + b);
    }

    public virtual double getArea()
    {
        double Area = calculateArea(a, b);
        return Area;
    }

    protected double calculateArea(double a, double b)
    {
        double Area = a * b;
        return Area;
    }

    public virtual double getPerimeter()
    {
        double P = 2 * (a + b);
        return P;
    }

    public bool equals(TRectangle aRect)
    {

        if (a == aRect.a && b == aRect.b)
        {
            return true;
        }
        return false;
    }

    static public TRectangle operator +(TRectangle rect1, TRectangle rect2)
    {
        TRectangle rect3 = new TRectangle(rect1.a + rect2.a, rect1.b + rect2.b);
        return rect3;
    }

    static public TRectangle operator -(TRectangle rect1, TRectangle rect2)
    {
        TRectangle rect3 = new TRectangle(rect1.a - rect2.a, rect1.b - rect2.b);
        return rect3;
    }

    static public TRectangle operator *(TRectangle rect1, double multiplicator)
    {
        TRectangle rect3 = new TRectangle(rect1.a * multiplicator, rect1.b * multiplicator);
        return rect3;
    }
};
