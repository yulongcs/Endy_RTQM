namespace Lgsoft.SF.Domain
{
    /// <summary>
    /// “工作单元模式”接口。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交容器中所有的更改。
        /// </summary>
        /// <remarks>
        /// 如果实体对象包含固定属性（Fixed Property）并且引发了乐观并发异常，
        /// 则抛出异常。
        /// </remarks>
        void Commit();

        /// <summary>
        /// 提交容器中所有的更改。
        /// </summary>
        /// <remarks>
        /// 如果实体对象包含固定属性（Fixed Property）并且引发了乐观并发异常，
        /// 则使用数据源的值刷新实体对象的原始值，确保调用方成功。
        /// </remarks>
        void CommitAndRefreshChanges();

        /// <summary>
        /// 回滚未写入数据源的更改。
        /// </summary>
        void RollbackChanges();
    }
}
