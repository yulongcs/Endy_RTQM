using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lgsoft.RTQM.Utility
{
    public static class ListExportUtility
    {
        public static Stream ListExport<TDTOType>(List<TDTOType> exportList, Dictionary<string, string> fieldNameMap)
        {
            var memStream = new MemoryStream();
            var streamWrite = new StreamWriter(memStream, Encoding.UTF8);

            var keyTypeProperties =
                typeof(TDTOType).GetMembers().Where(m => m.MemberType == MemberTypes.Property).ToList();

            // 写字段名
            foreach (var keyTypeProperty in keyTypeProperties)
            {
                var pName = keyTypeProperty.Name;
                if (fieldNameMap.ContainsKey(pName))
                    streamWrite.Write(fieldNameMap[pName] + ",");
                else
                    streamWrite.Write(pName + ",");
            }
            streamWrite.WriteLine();

            // 写数据
            foreach (var dto in exportList)
            {
                foreach (var keyTypeProperty in keyTypeProperties)
                {
                    var getM = (keyTypeProperty as PropertyInfo).GetGetMethod();
                    streamWrite.Write((getM.Invoke(dto, null) ?? string.Empty) + ",");
                }
                streamWrite.WriteLine();
            }

            streamWrite.Flush();

            return memStream;
        }
    }
}
