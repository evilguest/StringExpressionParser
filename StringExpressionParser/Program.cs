using System.Linq.Expressions;
namespace StringExpressionParser;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var x = Expression.Parameter(typeof(int), "x");
        var y = Expression.Parameter(typeof(int), "y");
        var z = Expression.Parameter(typeof(int), "z");

        var a = new Arithmetics();
        a.Parameters.Add(x);
        a.Parameters.Add(y);
        a.Parameters.Add(z);

        var e = a.Parse("2*x + y + z");
        var l = Expression.Lambda<Func<int, int, int, int>>(e, x, y, z);
        var c = l.Compile();
        Console.WriteLine(c(1, 2, 3));
         
    }
}