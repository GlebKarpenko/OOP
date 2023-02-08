using System;

class Program
{
    void testTRectangle()
    {
        TRectangle rect1 = new TRectangle(2, 3);
        TRectangle rect2 = new TRectangle(rect1);

        Console.Write("\n\n\nВвод двох прямокутникiв");

        rect1 = rect1.read();
        rect2 = rect2.read();

        Console.Write("\n\nВивiд двох прямокутникiв");
        Console.Write("\n\n");
        rect1.print();
        rect2.print();

        Console.Write("\nЗнаходження площi прямокутника 'rect1':");
        Console.Write(rect1.getArea());

        Console.Write("\n\nЗнаходження периметру прямокутника 'rect1':");
        Console.Write(rect1.getPerimeter());

        Console.Write("\n\nПорiвняння двох прямокутникiв: ");
        if (rect1.equals(rect2))
        {
            Console.WriteLine("Прямокутники однаковi");
        }
        else
        {
            Console.WriteLine("Прямокутникi не однаковi");
        }

        Console.Write("\nДодавання сторiн двох прямокутникiв: ");
        TRectangle rect3 = new TRectangle();
        rect3 = rect1 + rect2;
        rect3.print();

        Console.Write("\nВiднiмання сторiн двох прямокутникiв: ");
        rect3 = rect1 - rect2;
        rect3.print();

        Console.Write("\nМноження сторiн прямокутника 'rect1' на множник 3: ");
        rect3 = rect1 * 3;
        rect3.print();
    }

    void testTParallelepiped ()
    {
        TParallelepiped p1 = new TParallelepiped(2, 3, 4);
        TParallelepiped p2 = new TParallelepiped(p1);

        Console.Write("\n\n\nВвод двох паралелепiпедiв");

        p1 = p1.read();
        p2 = p2.read();

        Console.Write("\n\nВивiд двох паралелепiпедiв");
        Console.Write("\n\n");
        p1.print();
        p2.print();

        Console.Write("\nЗнаходження площi паралелепiпеда 'p1':");
        Console.Write(p1.getArea());

        Console.Write("\n\nЗнаходження периметру паралелепiпеда 'p1':");
        Console.Write(p1.getPerimeter());

        Console.Write("\n\nПорiвняння двох паралелепiпедiв: ");
        if (p1.equals(p2))
        {
            Console.WriteLine("паралелепiпеди однаковi");
        }
        else
        {
            Console.WriteLine("паралелепiпеди не однаковi");
        }
        
        Console.Write("\nДодавання сторiн двох паралелепiпедiв: ");
        TParallelepiped p3 = new TParallelepiped();
        p3 = p1 + p2;
        p3.print();

        Console.Write("\nВiднiмання сторiн двох паралелепiпедiв: ");
        p3 = p1 - p2;
        p3.print();

        Console.Write("\nМноження сторiн паралелепiпеда 'p1' на множник 3: ");
        p3 = p1 * 3;
        p3.print();
    }

    static void Main(string[] args)
    {
        Program main = new Program();
        main.testTRectangle();
        main.testTParallelepiped();
    }
}