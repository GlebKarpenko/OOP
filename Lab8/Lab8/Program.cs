using System;
using System.Linq.Expressions;

class Program
{
    public static void Main(string[] args)
    {
        string text = File.ReadAllText($@"{Environment.CurrentDirectory}\input.txt");
        char[] symbols = text.ToCharArray();
        List<char> list = symbols.ToList<char>();

        Program main = new Program();
        Console.WriteLine("\nВикористаємо масив.");
        Console.WriteLine("Кiлькiсть прописних лiтер в файлi 'input.txt': " + main.countUppercase(symbols));
        Console.WriteLine("\nВикористаємо список.");
        Console.WriteLine("Кiлькiсть прописних лiтер в файлi 'input.txt': " + main.countUppercase(list));
    }

    int countUppercase(char[] symbols)
    {
        int count = 0;
        foreach (char element in symbols)
        {
            if (Char.IsUpper(element))
            {
                count++;
            }
        }
        return count;
    }

    int countUppercase(List<char> list)
    {
        int count = 0;
        foreach (char element in list)
        {
            if (Char.IsUpper(element))
            {
                count++;
            }
        }
        return count;
    }
}