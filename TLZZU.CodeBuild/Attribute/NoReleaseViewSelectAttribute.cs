using System;
using System.Collections.Generic;
using System.Text;

namespace TLZZU.CodeBuild.Attribute
{
    [Obsolete]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NoReleaseViewSelectAttribute : BaseAttribute, INoReleaseMaker
    {
       
        public string Sql { get; set; }
        public bool IsMult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="sql">sql语句 比如 select * from yyfz_test where name=:name and age=23 </param>
        /// <param name="description">描述</param>
        /// <param name="isMult">是否多行</param>
        public NoReleaseViewSelectAttribute(string methodName, string sql, string description, bool isMult = true)
        {
            this.Description = description;
            this.Sql = sql;
            this.MethodName = methodName;
            this.IsMult = isMult;
        }

        public string CreateCode(DBTableAttribute tableAttribute, Type p)
        {
            this.VerifySelectSql(this.Sql, p.FullName);
            StringBuilder sb = new StringBuilder();
            var param = this.GetSqlParams(this.Sql);
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>");
            foreach (var par in param)
            {
                sb.AppendLine(string.Format("        /// <param name=\"{0}\">{0}</param>", par));
            }
            string tempReturn = this.IsMult ? string.Format("IList<{0}>", p.FullName) : p.FullName;
            sb.AppendLine("        /// <returns></returns>").
               AppendLine(string.Format("        public {0} {1}({2})",tempReturn,this.MethodName,this.GetMethodParam(param,p))).
               AppendLine("        {").
               AppendLine("            try").
               AppendLine("            {").
               Append(this.GetParamStr("                cdb.Parameters.Add(\":{0}\",{1});", param, p)).
               AppendLine(string.Format("                var result = cdb.GetDataItems<{0}>(\"{1}\");", p.FullName, this.Sql));
            if (IsMult)
            {
                sb.AppendLine("                return result;");
            }
            else {
                sb.AppendLine("                return result.FirstOrDefault();");
            }
            sb.AppendLine("            }");

            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
              AppendLine("            {").
              AppendLine("                if (oracleException.Number == 3113)").
              AppendLine(string.Format("                    return {0}({1});", this.MethodName, this.GetMethodParamFields(param, p))).
              AppendLine("                else").
              AppendLine("                    throw oracleException;").
              AppendLine("            }");

           
            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();
        }
    }
}