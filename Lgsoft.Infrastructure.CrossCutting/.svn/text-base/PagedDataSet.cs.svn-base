using System.Collections;
using System.Collections.Generic;

namespace Lgsoft.SF.Infrastructure.CrossCutting
{
    /// <summary>
    /// 分页集合。
    /// </summary>
    /// <typeparam name="TObject">集合使用的对象类型。</typeparam>
    public class PagedDataSet<TObject> : IEnumerable
    {
        /// <summary>
        /// 分页序号。
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小。
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 数据总量。
        /// </summary>
        public int DataCount { get; set; }

        /// <summary>
        /// 当前页数据集合。
        /// </summary>
        public List<TObject> CurrentPageDataSet { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
