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

        var e = a.Parse("2*x + y^3 + z");
        var l = Expression.Lambda<Func<double, double, double, double>>(e, x, y, z);
        var c = l.Compile();
        Console.WriteLine(c(1, 2, 3));
    }

    private static ParameterExpression NewParam(string name) => Expression.Parameter(typeof(double), name);
}