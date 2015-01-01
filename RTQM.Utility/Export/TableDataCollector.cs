using System.Collections.Generic;
using System.Linq;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 表格数据收集器。
    /// </summary>
    internal class TableDataCollector
    {
        private readonly List<string> _columnNames;
        private readonly Dictionary<string, Dictionary<string, object>> _lineDatas;

        /// <summary>
        /// 初始化 TableDataCollector 的新实例。
        /// </summary>
        public TableDataCollector()
        {
            _columnNames = new List<string>();
            _lineDatas = new Dictionary<string, Dictionary<string, object>>();
        }

        /// <summary>
        /// 设置表格中的单元格。
        /// </summary>
        /// <typeparam name="TValue">单元格值类型。</typeparam>
        /// <param name="lineName">行名称。</param>
        /// <param name="columnName">列名称。</param>
        /// <param name="cellValue">单元格值。</param>
        public void SetCellValue<TValue>(string lineName, string columnName, TValue cellValue)
        {
            if (!_columnNames.Contains(columnName))
                _columnNames.Add(columnName);

            if (!_lineDatas.ContainsKey(lineName))
                _lineDatas.Add(lineName, new Dictionary<string, object>());

            _lineDatas[lineName][columnName] = cellValue;
        }

        /// <summary>
        /// 获取表格中的单元格。
        /// </summary>
        /// <typeparam name="TValue">单元格值类型。</typeparam>
        /// <param name="lineName">行名称。</param>
        /// <param name="columnName">列名称。</param>
        /// <param name="cellValue">输出单元格值。</param>
        /// <returns>成功获取返回 true，否则返回 false。</returns>
        public bool GetCellValue<TValue>(string lineName, string columnName, out TValue cellValue)
        {
            if (_lineDatas.ContainsKey(lineName))
            {
                if (_lineDatas[lineName].ContainsKey(columnName))
                {
                    var value = _lineDatas[lineName][columnName];
                    if (typeof (TValue).IsAssignableFrom(value.GetType()))
                    {
                        cellValue = (TValue) value;
                        return true;
                    }
                }
            }
            cellValue = default(TValue);
            return false;
        }

        /// <summary>
        /// 添加一组列名称。
        /// </summary>
        /// <param name="columnNames">列名称列表。</param>
        public void AddColumnNames(string[] columnNames)
        {
            foreach (var columnName in columnNames.Where(columnName => !_columnNames.Contains(columnName)))
            {
                _columnNames.Add(columnName);
            }
        }

        /// <summary>
        /// 添加一组行名称。
        /// </summary>
        /// <param name="lineNames">行名称列表。</param>
        public void AddLineNames(string[] lineNames)
        {
            foreach (var lineName in lineNames.Where(lineName => !_lineDatas.ContainsKey(lineName)))
            {
                _lineDatas.Add(lineName, new Dictionary<string, object>());
            }
        }

        /// <summary>
        /// 获取当前表格中的所有列名称。
        /// </summary>
        /// <returns>返回所有列名称的枚举器。</returns>
        public IEnumerable<string> GetColumnNames()
        {
            return _columnNames.AsEnumerable();
        }

        /// <summary>
        /// 获取当前表格中的所有行名称。
        /// </summary>
        /// <returns>返回所有行名称的枚举器。</returns>
        public IEnumerable<string> GetLineNames()
        {
            return _lineDatas.Keys.AsEnumerable();
        }
    }
}