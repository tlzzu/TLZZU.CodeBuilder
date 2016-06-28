using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.DemoModel
{
    public class TestAttribute : TLZZU.CodeBuild.Attribute.BaseAttribute, TLZZU.CodeBuild.Attribute.IReleaseMaker
    {

        public string CreateCode(Attribute.DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 自扩展方法");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public string Test()");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"Hello Word --这是测试方法！\";");
            sb.AppendLine("        }");
            return sb.ToString();
        }
    }
}
