using System;

class TParallelepiped : TRectangle
{
    protected double c;

    public TParallelepiped()
    {
        //empty
    }
    public TParallelepiped(double a, double b, double c) : base(a, b)
    {
        this.c = c;
    }

    public TParallelepiped(TParallelepiped parallelepiped1) : base(parallelepiped1)
    {
        c = parallelepiped1.c;
    }

    public override TParallelepiped read()
    {
        TRectangle rect = base.read();
        double a = rect.getA();
        double b = rect.getB();
        double c = 0;

        try
        {
            Console.Write("\nВведiть сторорну c: ");
            c = Convert.ToDouble(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Помилка вводу");
            read();
        }
        if (c <= 0)
        {
            Console.WriteLine("Сторони повиннi бути бiльше 0");
            read();
        }

        TParallelepiped parallelepiped1 = new TParallelepiped(a, b, c);
        return parallelepiped1;
    }

    public override void print()
    {
        base.print();
        Console.Write(", c: " + c);
    }

    public override double getArea()
    {
        double Area = 2 * (base.calculateArea(a, b) + base.calculateArea(a, c) + base.calculateArea(b, c));
        return Area;
    }

    public override double getPerimeter()
    {
        double P = 4 * a + 4 * b + 4 * c;
        return P;
    }

    public double getVolume()
    {
        double V = a * b * c;
        return V;
    }

    public bool equals(TParallelepiped aParallelepiped)
    {
        if (base.equals(aParallelepiped) && c == aParallelepiped.c)
        {
            return true;
        }
        return false;
    }

    static public TParallelepiped operator +(TParallelepiped p1, TParallelepiped p2)
    {
        TParallelepiped p3 = new TParallelepiped(p1.a + p2.a, p1.b + p2.b, p1.c + p2.c);
        return p3;
    }

    static public TParallelepiped operator -(TParallelepiped p1, TParallelepiped p2)
    {
        TParallelepiped p3 = new TParallelepiped(p1.a - p2.a, p1.b - p2.b, p1.c - p2.c);
        return p3;
    }

    static public TParallelepiped operator *(TParallelepiped p1, double multiplicator)
    {
        TParallelepiped p3 = new TParallelepiped(p1.a * multiplicator, p1.b * multiplicator, p1.c * multiplicator);
        return p3;
    }
}