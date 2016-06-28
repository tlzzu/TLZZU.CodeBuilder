using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Oracle
{
    public interface IDBInformation
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
         string ConnStr { get; }
        /// <summary>
        /// 表结构说明
        /// </summary>
         IDictionary<string, string> GetTables();
    }
}
