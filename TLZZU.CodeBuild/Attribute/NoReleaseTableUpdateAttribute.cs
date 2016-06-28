using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    [Obsolete]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class NoReleaseTableUpdateAttribute:BaseAttribute,INoReleaseMaker
    {
        public string WhereSql { get; set; }
        public List<string> UpdateFields { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="updateFields">需要更新的字段 例如：yhid,yhxm</param>
        /// <param name="whereSql">where后的语句 比如：name=:name and age=20 and sex=:sex</param>
        /// <param name="description">描述</param>
        public NoReleaseTableUpdateAttribute(string methodName, string updateFields, string whereSql, string description)
        {
            this.Description = description;
            this.MethodName = methodName;
            this.WhereSql = whereSql;
            if (!string.IsNullOrWhiteSpace(updateFields)) {
                this.UpdateFields = updateFields.Split(',').ToList();
            }
        }
        /// <summary>
        /// 返回update字符串 比如：age=:updateage,name=:updatename
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetUpdateSql(Type p) {
            List<string> updateStr = new List<string>();
            var tempTypePro = p.GetProperties().Select(a => a.Name.ToUpper()).ToList();
            foreach (var item in this.UpdateFields)
            {
                if (tempTypePro.Contains(item.ToUpper()))
                {
                    updateStr.Add(string.Format("{0}=:update{0}", item));
                }
                else {
                    throw new Exception(string.Format("{0}对象中不存在updateFields中的{1}字段，请核对！", p.FullName, item));
                }
            }
            return string.Join(",", updateStr);
        }
        public string CreateCode(DBTableAttribute tableAttribute, Type p)
        {
            
            if (string.IsNullOrWhiteSpace(this.WhereSql))
                throw new Exception("where 不能为空！");
            if (this.UpdateFields == null || this.UpdateFields.Count <= 0)
                throw new Exception("update 不能为空");
            this.VerifyWhereSql(this.WhereSql, p.FullName);
            var tempPro=p.GetProperties().Select(a=>a.Name.ToUpper()).ToList();
            foreach (var field in this.UpdateFields)
            {
                if (!tempPro.Contains(field.ToUpper())) {
                    throw new Exception(string.Format("{0}对象中不存在updateFields中的{1}字段，请核对！",p.FullName,field));
                }
            }
            StringBuilder sb = new StringBuilder();
            var param = this.GetSqlParams(this.WhereSql);
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>");
            foreach (var pro in this.UpdateFields)
            {
                sb.AppendLine(string.Format("        /// <param name=\"update{0}\">update{0}</param>", pro));
            }
            foreach (var par in param)
            {
                sb.AppendLine(string.Format("        /// <param name=\"where{0}\">where{0}</param>", par));
            }
            sb.AppendLine("        /// <returns></returns>");
            string whereParams=this.GetMethodParam(param, p,"where");
            string updateParams=this.GetMethodParam(this.UpdateFields, p,"update");
            var tempParam=string.Join(",",new []{updateParams,whereParams});
            sb.AppendLine(string.Format("        public int {0}({1})", this.MethodName,tempParam ));
            sb.AppendLine("        {").
               AppendLine("            try").
               AppendLine("            {").
               Append(this.GetParamStr("                cdb.Parameters.Add(\":update{0}\",update{1});", this.UpdateFields, p)).
               Append(this.GetParamStr("                cdb.Parameters.Add(\":{0}\",where{1});", param, p).Replace("cdb.Parameters.Clear();",string.Empty)).
               AppendLine(string.Format("                cdb.ExeSQL(\"update {0} set {1} where {2}\");",tableAttribute.TableName,this.GetUpdateSql(p), this.WhereSql));
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

            string fwhereParams = this.GetMethodParamFields(param, p, "where");
            string fupdateParams = this.GetMethodParamFields(this.UpdateFields, p, "update");
            var ftempParam = string.Join(",", new[] { fupdateParams, fwhereParams });

            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
              AppendLine("            {").
              AppendLine("                if (oracleException.Number == 3113)").
              AppendLine(string.Format("                    return {0}({1});", this.MethodName, ftempParam)).
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
