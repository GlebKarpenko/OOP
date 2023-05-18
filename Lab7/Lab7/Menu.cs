using System;
using System.Reflection.Metadata;

namespace Lab7
{
    class Menu
    {
        IScaleneTriangle t1;
        IEquilateralTriangle t2;
        IIsoscelesTriangle t3;
        IRightTriangle t4;

        public void mainMenu()
        {
            Console.Write(">");
            string input = Console.ReadLine();
            input += " ";
            string[] fullCommand = input.Split(" ");
            string command = fullCommand[0];
            string parameter = fullCommand[1].Trim();

            if (command == "help")
            {
                helpMenu(); 
                mainMenu();
            }

            if (command == "exit")
            {
                return;
            }

            if (command == "create")
            {
                createUndefinedTriangle(parameter); 
                mainMenu();
            }

            if (command == "perimeter")
            {
                getPerimeter(parameter); 
                mainMenu();
            }

            if (command == "area")
            {
                getArea(parameter); 
                mainMenu();
            }

            if (command == "r")
            {
                getInnerRadius(parameter);
                mainMenu();
            }

            if (command == "R")
            {
                getOuterRadius(parameter); 
                mainMenu();
            }

            if (command == "get")
            {
                getAll(parameter);
                mainMenu();
            }

            else
            {
                printWrongCommandError();
                mainMenu();
            }
        }

        void createUndefinedTriangle(string parameter)
        {
            if (parameter == "-e")
                t2 = createTriangle(1);

            if (parameter == "-i")
                t3 = createTriangle(2);

            if (parameter == "-r")
                t4 = createTriangle(3);

            if (parameter != "-e" && parameter != "-i" && parameter != "-r")
            {
                t1 = createTriangle(3);
            }
        }

        void getPerimeter(string parameter)
        {
            try
            {
                if (parameter == "-e")
                    t2.printPerimeter();

                if (parameter == "-i")
                    t3.printPerimeter();

                if (parameter == "-r")
                    t4.printPerimeter();

                if (parameter != "-e" && parameter != "-i" && parameter != "-r")
                {
                    t1.printPerimeter();
                }
            }
            catch
            {
                Console.WriteLine("Не вдалося виконати команду");
            }
        }

        void getArea(string parameter)
        {
            try
            {
                if (parameter == "-e")
                    t2.calculateArea();

                if (parameter == "-i")
                    t3.calculateArea();

                if (parameter == "-r")
                    t4.calculateArea();

                if (parameter != "-e" && parameter != "-i" && parameter != "-r")
                {
                    t1.calculateArea();
                }
            }
            catch
            {
                Console.WriteLine("Не вдалося виконати команду");
            }
        }

        void getInnerRadius(string parameter)
        {
            try
            {
                if (parameter == "-e")
                    t2.calculateInnerRadius();

                if (parameter == "-i")
                    t3.calculateInnerRadius();

                if (parameter == "-r")
                    t4.calculateInnerRadius();
                if (parameter != "-e" && parameter != "-i" && parameter != "-r")
                {
                    t1.calculateInnerRadius();
                }
            }
            catch
            {
                Console.WriteLine("Не вдалося виконати команду");
            }
        }

        void getOuterRadius(string parameter)
        {
            try
            {
                if (parameter == "-e")
                    t2.calculateOuterRadius();

                if (parameter == "-i")
                    t3.calculateOuterRadius();

                if (parameter == "-r")
                    t4.calculateOuterRadius();

                if (parameter != "-e" && parameter != "-i" && parameter != "-r")
                {
                    t1.calculateOuterRadius();
                }
            }
            catch
            {
                Console.WriteLine("Не вдалося виконати команду");
            }
        }

        void getAll(string parameter)
        {
            try
            {
                if (parameter == "-e")
                    t2.printAllMembers();

                if (parameter == "-i")
                    t3.printAllMembers();

                if (parameter == "-r")
                    t4.printAllMembers();
                if (parameter != "-e" && parameter != "-i" && parameter != "-r")
                {
                    t1.printAllMembers();
                }
            }
            catch
            {
                Console.WriteLine("Не вдалося виконати команду");
            }
        }

        Triangle createTriangle(int nOfsides)
        {
            try
            {
                Console.WriteLine("Введiть сторону/и трикутника: ");
                if (nOfsides == 1)
                {
                    double side = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Данi внесенi.");
                    Triangle t = new Triangle(side);
                    return t;
                }
                if (nOfsides == 2)
                {
                    double side1 = Convert.ToDouble(Console.ReadLine());
                    double side2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Данi внесенi.");
                    Triangle t = new Triangle(side1, side2);
                    return t;
                }
                if (nOfsides == 3)
                {
                    double side1 = Convert.ToDouble(Console.ReadLine());
                    double side2 = Convert.ToDouble(Console.ReadLine());
                    double side3 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Данi внесенi.");
                    Triangle t = new Triangle(side1, side2, side3);
                    return t;
                }
            }
            catch
            {
                printCreateTriangleError();
            }
            return null;
        }

        void printTriangleDoesNotExist()
        {
            Console.WriteLine("Трикутник не було створено, для виконання роботи з " +
                "трикутником потрiбно спочатку його ствоити.");
        }

        void printCreateTriangleError()
        {
            Console.WriteLine("Не вдалося створити трикутник, перевiрте введенi данi");
        }

        void printWrongCommandError()
        {
            Console.WriteLine("Не правильно введено команду спробуйте ще раз або введiть" +
            " 'help' для отримання iнструкцiї по використанню");
        }

        void helpMenu()
        {
            Console.WriteLine("\nПрограма призначена для демонстрацiї формул обчислення периметра, " +
                "площi, радiуса вписаного та описаного кола рiзностороннiх, рiвностороннiх, " +
                "рiвнобедрених та прямокутних трикутникiв.");
            Console.WriteLine("\nСписок команд: " +
                "\nhelp -- для отримання допомоги," +
                "\nexit -- для виходу з програми" +
                "\n\ncreate -- для створення рiзностороннього трикутника" +
                "\nperimeter -- для виведення периметру останнього рiзностороннього трикутника" +
                "\narea -- для взаєможiї з набором формул для площi рiзностороннього трикутника" +
                "\nr -- для взаємодiї з набором форул для вписаного в рiзностороннiй трикутник кола" +
                "\nR -- для взаємодiї з набором форул для описаного навколо рiзностороннього трикутника кола" +
                "\n\nget -- для виводу iнформацiї про останнi створенi трикутники: знечення довжин сторiн, периметру, площi та радiусiв описаного, вписаного кiл. " +
                "Дана iнформацiя не буде виведена, якщо перед цим не було запущено команди на її " +
                "обрахунок(окрiм периметру)" +
                "\n\nДля взаємодiї з особливими типами трикутникiв додайте параметри:" +
                "\n-e -- для рiвностороннього трикутника" +
                "\n-i -- для рiвнобiчного трикутника" +
                "\n-r -- для прямокутного трикутника" +
                "\nПараметри можна додати до команд 'create', 'perimeter', 'area', 'r', 'R', 'get'" +
                "\n");
        }
    }
}
