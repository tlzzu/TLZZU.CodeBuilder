using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ViewPagingAttribute : BaseAttribute, IReleaseMaker
    {
        /// <summary>
        /// where 语句
        /// </summary>
        public string WhereSql { get; set; }
        /// <summary>
        /// 查询字段
        /// </summary>
        public IList<string> SelectFields { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public IList<string> OrderFields { get; set; }

        //public bool IsDesc { get; set; }

        /// <summary>
        /// 生成sql语句
        /// </summary>
        /// <param name="tableName">表名字</param>
        /// <param name="fields">需要获取的字段名s</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="whereStr"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex">分页索引，从0开始</param>
        /// <param name="isDesc">如何排序</param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private string GetPagingSql(string tableName, string fields, string orderField, string whereStr, int pageSize, int pageIndex, bool isDesc = true)
        {
            return
                string.Format(
                    "select {1} from {0} where rowid in (select rid from (select rownum rn,rid from(select rowid rid,{2} from {0} where {6} order by {2} {3}) where rownum<{4}) where rn>{5}) order by {2} {3}",
                    tableName,
                    fields,
                    orderField,
                    isDesc ? "desc" : "asc",
                    ((pageIndex + 1) * pageSize + 1),
                    pageSize * pageIndex, whereStr);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="selectFields">例如：name,age</param>
        /// <param name="orderField">例如:name,age</param>
        /// <param name="whereStr">例如：name=:name and age=:age</param>
        /// <param name="description"></param>
        public ViewPagingAttribute(string methodName, string selectFields, string orderField, string whereStr, string description)
        {
            this.MethodName = methodName;
            this.Description = description;
            this.WhereSql = whereStr;
            this.SelectFields = selectFields.Trim().Trim(',').Split(',').ToList();
            this.OrderFields = orderField.Trim().Trim(',').Split(',').ToList();
        }

        public string CreateCode(DBTableAttribute tableAttribute, Type p)
        {
            try
            {
                var pros = p.GetProperties().Select(a => a.Name.ToLower()).ToList();
                foreach (var item in this.SelectFields)//验证字段是否包含在实体对象中
                {
                    if (pros.FindAll(a=>a==item.ToLower()).Count<=0) {
                        throw new Exception(string.Format("{0}对象中的{1}方法中查询结果有不包含{2}字段问题",p.FullName,this.MethodName,item));
                        break;
                    }
                }
                return string.Format("{0}{1}{2}{3}", CreateDLCode(tableAttribute, p), CreateNRCode(tableAttribute, p), CreateDLCountCode(tableAttribute, p), CreateNRCountCode(tableAttribute, p));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        

        private string CreateDLCode(DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// "+this.Description);
            sb.AppendLine("        /// </summary>");
            var param = this.GetSqlParams(this.WhereSql);
            var tempPar = p.GetProperties().Select(a=>a.Name).ToList();
            foreach (var item in param)
            {
                var result = tempPar.FindAll(a => a.ToLower() == item.ToLower()).FirstOrDefault();
                sb.AppendLine(string.Format("        /// <param name=\"where{0}\">查询条件参数{0}</param>", result));
            }
            sb.AppendLine("        /// <param name=\"pageSize\">每页大小</param>");
            sb.AppendLine("        /// <param name=\"pageIndex\">页索引，从零开始计数</param>");
            sb.AppendLine("        /// <param name=\"isDesc\">是否正排，默认true最大的排在前面</param>");
            sb.AppendLine("        /// <returns></returns>");
            var temp=this.GetMethodParam(param,p,"where");
            temp = string.IsNullOrWhiteSpace(temp) ? string.Empty : temp + ",";
            sb.AppendLine(string.Format( "        public IList<{0}> {1}({2} int pageSize, int pageIndex, bool isDesc=true)",p.FullName,this.MethodName,temp));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            sb.AppendLine("                {");
            //sb.AppendLine("                    cdb.Parameters.Clear();");
            sb.AppendLine(this.GetParamStr("                    cdb.Parameters.Add(\":{0}\", where{1});",param,p));
            sb.AppendLine(string.Format("                    var result = cdb.GetDataItems<{0}>(string.Format(",p.FullName));
            sb.AppendLine("                    \"select {1} from {0} where rowid in (select rid from (select rownum rn,rid from(select rowid rid,{2} from {0} {6} order by {2} {3}) where rownum<{4}) where rn>{5}) order by {2} {3}\",");
            sb.AppendLine(string.Format("                    \"{0}\",", tableAttribute.TableName));
            sb.AppendLine(string.Format("                    \"{0}\",", string.Join(",", this.SelectFields)));
            sb.AppendLine(string.Format("                    \"{0}\",", string.Join(",", OrderFields)));
            sb.AppendLine("                    isDesc ? \"desc\" : \"asc\",");
            sb.AppendLine("                    ((pageIndex + 1) * pageSize + 1),");
            sb.AppendLine("                    pageSize * pageIndex,");
            var whereSqlStr=string.IsNullOrWhiteSpace(this.WhereSql)?"string.Empty":string.Format("\"where {0}\"",this.WhereSql);
            sb.AppendLine(string.Format("                    {0}));",whereSqlStr));
            sb.AppendLine("                    return result;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (oracleException.Number == 3113)");
            var tempR=this.GetMethodParamFields(param, p,"where");
            tempR=string.IsNullOrWhiteSpace(tempR)?string.Empty:tempR+",";
            sb.AppendLine(string.Format("                    return {0}({1} pageSize, pageIndex, isDesc);", this.MethodName, tempR));
            sb.AppendLine("                else");
            sb.AppendLine("                    throw oracleException;");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            return sb.ToString();
        }
        private string CreateNRCode(DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// " + this.Description);
            sb.AppendLine("        /// </summary>");
            var param = this.GetSqlParams(this.WhereSql);
            var tempPar = p.GetProperties().Select(a => a.Name).ToList();
            foreach (var item in param)
            {
                var result = tempPar.FindAll(a => a.ToLower() == item.ToLower()).FirstOrDefault();
                sb.AppendLine(string.Format("        /// <param name=\"where{0}\">查询条件参数{0}</param>", result));
            }
            sb.AppendLine("        /// <param name=\"pageSize\">每页大小</param>");
            sb.AppendLine("        /// <param name=\"pageIndex\">页索引，从零开始计数</param>");
            sb.AppendLine("        /// <param name=\"cdb\">传入参数</param>");
            sb.AppendLine("        /// <param name=\"isDesc\">是否正排，默认true最大的排在前面</param>");
            sb.AppendLine("        /// <returns></returns>");
            var temp = this.GetMethodParam(param, p, "where");
            temp = string.IsNullOrWhiteSpace(temp) ? string.Empty : temp + ",";
            sb.AppendLine(string.Format("        internal IList<{0}> {1}({2} int pageSize, int pageIndex,CDataBase cdb,bool isDesc=true)", p.FullName, this.MethodName, temp));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            //sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            //sb.AppendLine("                {");
            //sb.AppendLine("                    cdb.Parameters.Clear();");
            sb.AppendLine(this.GetParamStr("                cdb.Parameters.Add(\":{0}\", where{1});", param, p));
            sb.AppendLine(string.Format("                var result = cdb.GetDataItems<{0}>(string.Format(",p.FullName));
            sb.AppendLine("                \"select {1} from {0} where rowid in (select rid from (select rownum rn,rid from(select rowid rid,{2} from {0} {6} order by {2} {3}) where rownum<{4}) where rn>{5}) order by {2} {3}\",");
            sb.AppendLine(string.Format("                \"{0}\",", tableAttribute.TableName));
            sb.AppendLine(string.Format("                \"{0}\",", string.Join(",", this.SelectFields)));
            sb.AppendLine(string.Format("                \"{0}\",", string.Join(",", OrderFields)));
            sb.AppendLine("                isDesc ? \"desc\" : \"asc\",");
            sb.AppendLine("                ((pageIndex + 1) * pageSize + 1),");
            sb.AppendLine("                pageSize * pageIndex,");
            var whereSqlStr = string.IsNullOrWhiteSpace(this.WhereSql) ? "string.Empty" : string.Format("\"where {0}\"", this.WhereSql);
            sb.AppendLine(string.Format("                {0}));", whereSqlStr));
            sb.AppendLine("                return result;");
            sb.AppendLine("            }");
            //sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)");
            //sb.AppendLine("            {");
            //sb.AppendLine("                if (oracleException.Number == 3113)");
            //var tempR = this.GetMethodParamFields(param, p, "where");
            //tempR = string.IsNullOrWhiteSpace(tempR) ? string.Empty : tempR + ",";
            //sb.AppendLine(string.Format("                    return {0}({1} pageSize, pageIndex,cdb, isDesc);", this.MethodName, tempR));
            //sb.AppendLine("                else");
            //sb.AppendLine("                    throw oracleException;");
            //sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            return sb.ToString();
        }
        private string CreateNRCountCode(DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// " + this.Description);
            sb.AppendLine("        /// </summary>");
            var param = this.GetSqlParams(this.WhereSql);
            var tempPar = p.GetProperties().Select(a => a.Name).ToList();
            foreach (var item in param)
            {
                var result = tempPar.FindAll(a => a.ToLower() == item.ToLower()).FirstOrDefault();
                sb.AppendLine(string.Format("        /// <param name=\"where{0}\">查询条件参数{0}</param>", result));
            }
            sb.AppendLine("        /// <param name=\"pageSize\">每页大小</param>");
            sb.AppendLine("        /// <param name=\"pageIndex\">页索引，从零开始计数</param>");
            sb.AppendLine("        /// <param name=\"count\">记录总数</param>");
            sb.AppendLine("        /// <param name=\"cdb\">数据库操作对象</param>");
            sb.AppendLine("        /// <param name=\"isDesc\">是否正排，默认true最大的排在前面</param>");
            sb.AppendLine("        /// <returns></returns>");
            var temp = this.GetMethodParam(param, p, "where");
            temp = string.IsNullOrWhiteSpace(temp) ? string.Empty : temp + ",";
            sb.AppendLine(string.Format("        internal IList<{0}> {1}({2} int pageSize, int pageIndex, out int count,CDataBase cdb,bool isDesc=true)", p.FullName, this.MethodName, temp));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            //sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            //sb.AppendLine("                {");
            //sb.AppendLine("                    cdb.Parameters.Clear();");
            sb.AppendLine(this.GetParamStr("                cdb.Parameters.Add(\":{0}\", where{1});", param, p));
            var countWhere = string.IsNullOrWhiteSpace(this.WhereSql) ? string.Empty : "where " + this.WhereSql;
            sb.AppendLine(string.Format("                count = Convert.ToInt32(cdb.ExeSQL(string.Format(\"select count(*) from {0} {1}\")));", tableAttribute.TableName, countWhere));
            sb.AppendLine(string.Format("                var result = cdb.GetDataItems<{0}>(string.Format(",p.FullName));
            sb.AppendLine("                \"select {1} from {0} where rowid in (select rid from (select rownum rn,rid from(select rowid rid,{2} from {0} {6} order by {2} {3}) where rownum<{4}) where rn>{5}) order by {2} {3}\",");
            sb.AppendLine(string.Format("                \"{0}\",", tableAttribute.TableName));
            sb.AppendLine(string.Format("                \"{0}\",", string.Join(",", this.SelectFields)));
            sb.AppendLine(string.Format("                \"{0}\",", string.Join(",", OrderFields)));
            sb.AppendLine("                isDesc ? \"desc\" : \"asc\",");
            sb.AppendLine("                ((pageIndex + 1) * pageSize + 1),");
            sb.AppendLine("                pageSize * pageIndex,");
            var whereSqlStr = string.IsNullOrWhiteSpace(this.WhereSql) ? "string.Empty" : string.Format("\"where {0}\"", this.WhereSql);
            sb.AppendLine(string.Format("                {0}));", whereSqlStr));
            sb.AppendLine("                return result;");
            sb.AppendLine("            }");
            //sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)");
            //sb.AppendLine("            {");
            //sb.AppendLine("                if (oracleException.Number == 3113)");
            //var tempR = this.GetMethodParamFields(param, p, "where");
            //tempR = string.IsNullOrWhiteSpace(tempR) ? string.Empty : tempR + ",";
            //sb.AppendLine(string.Format("                    return {0}({1} pageSize, pageIndex, out count,isDesc);", this.MethodName, tempR));
            //sb.AppendLine("                else");
            //sb.AppendLine("                    throw oracleException;");
            //sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            return sb.ToString();
        }

        private string CreateDLCountCode(DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// " + this.Description);
            sb.AppendLine("        /// </summary>");
            var param = this.GetSqlParams(this.WhereSql);
            var tempPar = p.GetProperties().Select(a => a.Name).ToList();
            foreach (var item in param)
            {
                var result = tempPar.FindAll(a => a.ToLower() == item.ToLower()).FirstOrDefault();
                sb.AppendLine(string.Format("        /// <param name=\"where{0}\">查询条件参数{0}</param>", result));
            }
            sb.AppendLine("        /// <param name=\"pageSize\">每页大小</param>");
            sb.AppendLine("        /// <param name=\"pageIndex\">页索引，从零开始计数</param>");
            sb.AppendLine("        /// <param name=\"count\">记录总数</param>");
            sb.AppendLine("        /// <param name=\"isDesc\">是否正排，默认true最大的排在前面</param>");
            sb.AppendLine("        /// <returns></returns>");
            var temp = this.GetMethodParam(param, p, "where");
            temp = string.IsNullOrWhiteSpace(temp) ? string.Empty : temp + ",";
            sb.AppendLine(string.Format("        public IList<{0}> {1}({2} int pageSize, int pageIndex, out int count,bool isDesc=true)", p.FullName, this.MethodName, temp));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            sb.AppendLine("                {");
            //sb.AppendLine("                    cdb.Parameters.Clear();");
            sb.AppendLine(this.GetParamStr("                    cdb.Parameters.Add(\":{0}\", where{1});", param, p));
            var countWhere = string.IsNullOrWhiteSpace(this.WhereSql) ? string.Empty : "where " + this.WhereSql;
            sb.AppendLine(string.Format("                    count = Convert.ToInt32(cdb.ExeSQL(string.Format(\"select count(*) from {0} {1}\")));",tableAttribute.TableName,countWhere));
            sb.AppendLine(string.Format("                    var result = cdb.GetDataItems<{0}>(string.Format(",p.FullName));
            sb.AppendLine("                    \"select {1} from {0} where rowid in (select rid from (select rownum rn,rid from(select rowid rid,{2} from {0} {6} order by {2} {3}) where rownum<{4}) where rn>{5}) order by {2} {3}\",");
            sb.AppendLine(string.Format("                    \"{0}\",", tableAttribute.TableName));
            sb.AppendLine(string.Format("                    \"{0}\",", string.Join(",", this.SelectFields)));
            sb.AppendLine(string.Format("                    \"{0}\",", string.Join(",", OrderFields)));
            sb.AppendLine("                    isDesc ? \"desc\" : \"asc\",");
            sb.AppendLine("                    ((pageIndex + 1) * pageSize + 1),");
            sb.AppendLine("                    pageSize * pageIndex,");
            var whereSqlStr = string.IsNullOrWhiteSpace(this.WhereSql) ? "string.Empty" : string.Format("\"where {0}\"", this.WhereSql);
            sb.AppendLine(string.Format("                    {0}));", whereSqlStr));
            sb.AppendLine("                    return result;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (oracleException.Number == 3113)");
            var tempR = this.GetMethodParamFields(param, p, "where");
            tempR = string.IsNullOrWhiteSpace(tempR) ? string.Empty : tempR + ",";
            sb.AppendLine(string.Format("                    return {0}({1} pageSize, pageIndex, out count,isDesc);", this.MethodName, tempR));
            sb.AppendLine("                else");
            sb.AppendLine("                    throw oracleException;");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            return sb.ToString();
        }
    }
}
