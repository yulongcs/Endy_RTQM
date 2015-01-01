using System.Collections.Generic;

namespace Lgsoft.SF.Infrastructure.Data
{
    /// <summary>
    /// 支持特殊查询的接口。
    /// </summary>
    public interface ISql
    {
        /// <summary>
        /// 向数据源执行特定的查询。
        /// </summary>
        /// <typeparam name="TEntity">查询结果的实体类型。</typeparam>
        /// <param name="sqlQuery">查询语句。</param>
        /// <param name="parameters">查询参数集合。</param>
        /// <returns>返回查询的枚举集合。</returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        /// <summary>
        /// 向数据源执行任意命令。
        /// </summary>
        /// <param name="sqlCommand">命令语句。</param>
        /// <param name="parameters">查询参数集合。</param>
        /// <returns>返回受命令影响的行数。</returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
