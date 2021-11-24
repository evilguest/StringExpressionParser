using System.Linq.Expressions;
namespace StringExpressionParser;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var x = NewParam("x");
        var y = NewParam("y");
        var z = NewParam("z");

        var a = new Arithmetics();
        a.Parameters.Add(x, y, z);

        var e = a.Parse("2*x + y + z");
        var l = Expression.Lambda<Func<int, int, int, int>>(e, x, y, z);
        var c = l.Compile();
        Console.WriteLine(c(1, 2, 3));

    }

    private static ParameterExpression NewParam(string name) => Expression.Parameter(typeof(int), name);
}