using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    /// <summary>
    /// 表示该字段不是数据库中的字段
    /// </summary>
     [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FieldNoDBAttribute : System.Attribute
    {

    }
}
