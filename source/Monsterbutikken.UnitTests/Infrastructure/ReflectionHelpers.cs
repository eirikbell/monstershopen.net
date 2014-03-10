using System;
using System.Linq.Expressions;

namespace Monsterbutikken.UnitTests.Infrastructure
{
    public class ReflectionHelpers
    {
        public static string GetMethodName<TParameter, TResult>(Expression<Func<TParameter, TResult>> expression)
        {
            var method = expression.Body as MethodCallExpression;
            if (method != null)
                return method.Method.Name;

            throw new ArgumentException("Expression is wrong");
        }

        public static Type GetMethodReturnType<TParameter, TResult>(Expression<Func<TParameter, TResult>> expression)
        {
            var method = expression.Body as MethodCallExpression;
            if (method != null)
                return method.Method.ReturnType;

            throw new ArgumentException("Expression is wrong");
        }
    }
}
