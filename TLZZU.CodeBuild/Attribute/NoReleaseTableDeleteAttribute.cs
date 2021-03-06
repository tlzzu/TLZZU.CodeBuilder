﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    [Obsolete]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NoReleaseTableDeleteAttribute:BaseAttribute,INoReleaseMaker
    {

        public string WhereSql { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="whereSql">where后的语句 比如：name=:name and age=20 and sex=:sex</param>
        /// <param name="description">描述</param>
        public NoReleaseTableDeleteAttribute(string methodName, string whereSql, string description)
        {
            this.Description = description;
            this.MethodName = methodName;
            this.WhereSql = whereSql;
        }

        public string CreateCode(DBTableAttribute tableAttribute, Type p)
        {
            this.VerifyWhereSql(this.WhereSql, p.FullName);
            if (string.IsNullOrWhiteSpace(this.WhereSql))
                throw new Exception("where 不能为空！");
            StringBuilder sb = new StringBuilder();
            var param = this.GetSqlParams(this.WhereSql);
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>");
            foreach (var par in param)
            {
                sb.AppendLine(string.Format("        /// <param name=\"{0}\">{0}</param>", par));
            }
            sb.AppendLine("        /// <returns></returns>").
               AppendLine(string.Format("        public int {0}({1})",this.MethodName, this.GetMethodParam(param, p))).
               AppendLine("        {").
               AppendLine("            try").
               AppendLine("            {").
               Append(this.GetParamStr("                cdb.Parameters.Add(\":{0}\",{1});", param, p)).
               AppendLine(string.Format("                cdb.ExeSQL(\"delete from {0} where {1}\");", tableAttribute.TableName, this.WhereSql));
            sb.AppendLine("                var result=cdb.SqlNRows;");
            sb.AppendLine("                if (result > 0){").
               AppendLine("                     cdb.Commit();").
               AppendLine("                }").
               AppendLine("                else").
               AppendLine("                {").
               AppendLine("                     cdb.Rollback();").
               AppendLine("                }");
            sb.AppendLine("                return result;");
            sb.AppendLine("            }");

            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
              AppendLine("            {").
              AppendLine("                if (oracleException.Number == 3113)").
              AppendLine(string.Format("                    return {0}({1});", this.MethodName, GetMethodParamFields(param, p))).
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
