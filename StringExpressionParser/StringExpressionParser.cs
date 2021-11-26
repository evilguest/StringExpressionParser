using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringExpressionParser
{
    internal class StringExpressionParser<D> : StringExpressionParserBase
        where D : Delegate
    {
        
        public StringExpressionParser() : base(InferParameters())
        {
            AddFunction(nameof(Upper));
            AddFunction(nameof(Lower));
            AddFunction(nameof(Find));
        }
        private void AddFunction(string name) => Functions.Add(typeof(StringExpressionParser<D>).GetMethod(name));
        public static ParameterExpression[] InferParameters() 
            => (from p in typeof(D).GetMethod("Invoke")!.GetParameters()
                select Expression.Parameter(p.ParameterType, p.Name)).ToArray();
        public Expression<D> Parse(string code)
        { 
            var t = base.Parse(code);
            return Expression.Lambda<D>(t, Parameters.Values);
        }
        #region Functions
        public static string Upper(string s) => s.ToUpper();
        public static string Lower(string s) => s.ToLower();
        public static int Find(string what, string where) => where.IndexOf(what);
        #endregion
    }
}
