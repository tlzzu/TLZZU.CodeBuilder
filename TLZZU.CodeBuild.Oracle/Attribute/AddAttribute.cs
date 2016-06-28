using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Oracle.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AddAttribute : BaseAttribute,IBaseMaker
    {

        public AddAttribute() : this("Add", "新增方法") { }

        public AddAttribute(string methodName, string description)
        {
            this.Description = description;
            this.MethodName = methodName;
        }

        public string Do(TableAttribute tableAttribute, Type p)
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(DoPublic(tableAttribute,p)).AppendLine(DoPrivate(tableAttribute,p));
            return sb.ToString();
        }








        public string DoPublic(TableAttribute tableAttribute, Type p) {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// 添加方法，生成时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendLine("        /// " + this.Description);
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"model\">添加对象</param>");
                sb.AppendLine("        /// <returns>大于0为添加成功</returns>");
                sb.AppendLine(string.Format("        public int {0}({1} model)", this.MethodName, p.FullName));
                sb.AppendLine("        {");
                sb.AppendLine("            try");
                sb.AppendLine("            {");
                var fields = GetAddFields(p);
                sb.AppendLine("                using (var conn = new System.Data.OracleClient.OracleConnection(OracleHelper.ConnString)){").AppendLine("                    conn.Open();");
                sb.AppendLine("                    var command = conn.CreateCommand();");
                sb.Append(this.GetOracleAddParam("                    if(model.{1}!=null) fields.Add(\"{0}\");if(model.{1}!=null) command.Parameters.Add(new OracleParameter(\":{0}\", model.{1}));", p));
                //sb.AppendLine(string.Format("                    command.CommandText = \"insert into {0}({1}) values(:{2})\";", tableAttribute.TableName, string.Join(",", fields), string.Join(",:", fields)));
                sb.AppendLine("                    command.CommandText = string.Format(\"insert into " + tableAttribute.TableName + "({0}) values(:{1})\",string.Join(\",\",fields),string.Join(\",:\",fields));");
                sb.AppendLine("                    return command.ExecuteNonQuery();");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine("            catch (Exception ex)");
                sb.AppendLine("            {");
                sb.AppendLine("                Lenovo.Tool.Log4NetHelper.Error(ex);");
                sb.AppendLine("                return 0;");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string DoPrivate(TableAttribute tableAttribute, Type p)
        {
            
        }

        
    }
}
