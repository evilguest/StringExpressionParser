using System.Linq.Expressions;
namespace StringExpressionParser;

public class Program
{
    public delegate string ABC(string a, string b, string c);
    public static void Main(string[] args)
    {
        var p = new StringExpressionParser<ABC>();
        foreach (var s in StringExpressions())
        {
            Console.WriteLine(s + ":");
            try
            {
                var e = p.Parse(s);
                Console.WriteLine("\t" + e.ToString());
                var c = e.Compile();
                Console.WriteLine("\t" + c("Hello", ", ", "world!"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }
    }

    private static IEnumerable<string> StringExpressions()
    {
        yield return "a+b+c";
        yield return "a[0..5] + b + Upper(c)[1..2]";
        yield return "a + b + t";
        yield return "Something(a)";
        yield return "Upper(q)";
        yield return "Find(a+b, b)";
        yield return "Upper(a, b)";
        yield return "(a ~ c[1..1] ? a : c)";
    }
}