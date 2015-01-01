using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lgsoft.SF.Domain.Specification
{
    /// <summary>
    /// 表达式参数重新绑定辅助类，可以避免在表达式中使用 Invoke 方法。
    /// （这种方式并不支持所有的 LINQ 查询提供程序，例如 LINQ to Entities 是不支持的。）
    /// </summary>
    internal class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        /// <summary>
        /// 初始化 ParameterRebinder 的新实例。
        /// </summary>
        /// <param name="map">参数映射规则。</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 使用参数映射信息替换表达式中的参数。
        /// </summary>
        /// <param name="map">参数映射信息。</param>
        /// <param name="exp">要替换参数的表达式。</param>
        /// <returns>替换了参数的表达式。</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        /// <summary>
        /// 访问者模式（Visitor Pattern）的方法。
        /// </summary>
        /// <param name="p">参数表达式。</param>
        /// <returns>返回新的访问表达式。</returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (_map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }
    }
}
