using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 为 Expression(T) 添加带不同参数的 Add 和 Or 的扩展方法。
    /// </summary>
    internal static class ExpressionBuilder
    {
        /// <summary>
        /// 组合两个表达式树，并合并为一个新的表达式树。
        /// </summary>
        /// <typeparam name="T">表达式树的类型参数。</typeparam>
        /// <param name="first">表达式树。</param>
        /// <param name="second">合并的表达式树。</param>
        /// <param name="merge">合并的方法。</param>
        /// <returns>返回新的合并表达式树。</returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // 构造参数映射（从 Second 的参数到 First 的参数）。
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            // 用 First 的参数替换 Second Lambda 表达式的参数。
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // 应用 First 的参数组合两个 Lambda 表达式的主体。
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// AND 操作符。
        /// </summary>
        /// <typeparam name="T">表达式中的参数类型。</typeparam>
        /// <param name="first">AND 操作符的右表达式。</param>
        /// <param name="second">AND 操作符的左表达式。</param>
        /// <returns>返回新的 AND 表达式。</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        /// <summary>
        /// OR 操作符。
        /// </summary>
        /// <typeparam name="T">表达式中的参数类型。</typeparam>
        /// <param name="first">OR 操作符的右表达式。</param>
        /// <param name="second">OR 操作符的左表达式。</param>
        /// <returns>返回新的 OR 表达式。</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
}
