using System;
using System.Collections.Generic;
using System.Text;

namespace TLZZU.CodeBuild.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ViewSelectAttribute : BaseAttribute, IReleaseMaker
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
        public ViewSelectAttribute(string methodName,string sql,string description,bool isMult=true) {
            this.Description = description;
            this.Sql = sql;
            this.MethodName = methodName;
            this.IsMult = isMult;
        }

        public string CreateCode(DBTableAttribute tableAttribute, Type p) {
            try
            {
                return string.Format("{0}{1}", CreateDLCode(tableAttribute, p), CreateNRCode(tableAttribute, p));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CreateNRCode(DBTableAttribute tableAttribute, Type p)
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
            sb.AppendLine("        /// <returns></returns>");
            var temp= this.GetMethodParam(param, p);
            temp=string.IsNullOrWhiteSpace(temp)?"CDataBase cdb":temp+",CDataBase cdb";
            sb.AppendLine(string.Format("        internal {0} {1}({2})", tempReturn, this.MethodName,temp)).
               AppendLine("        {").
               AppendLine("            try").
               AppendLine("            {").
               Append(this.GetParamStr("                cdb.Parameters.Add(\":{0}\",{1});", param, p)).
               AppendLine(string.Format("                var result = cdb.GetDataItems<{0}>(\"{1}\");", p.FullName, this.Sql));
            if (IsMult)
            {
                sb.AppendLine("                return result;");
            }
            else
            {
                sb.AppendLine("                return result.FirstOrDefault();");
            }
            sb.AppendLine("            }");

            //sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
            //  AppendLine("            {").
            //  AppendLine("                if (oracleException.Number == 3113)").
            //  AppendLine(string.Format("                    return {0}({1},cdb);", this.MethodName, this.GetMethodParamFields(param, p))).
            //  AppendLine("                else").
            //  AppendLine("                    throw oracleException;").
            //  AppendLine("            }");


            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();
        }

        public string CreateDLCode(DBTableAttribute tableAttribute, Type p)
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
               AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))").
               AppendLine("                {").
               Append(this.GetParamStr("                    cdb.Parameters.Add(\":{0}\",{1});",param,p)).
               AppendLine(string.Format("                    var result = cdb.GetDataItems<{0}>(\"{1}\");",p.FullName,this.Sql));
            if (IsMult)
            {
                sb.AppendLine("                    return result;");
            }
            else {
                sb.AppendLine("                    return result.FirstOrDefault();");
            }
            sb.AppendLine("                }");
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


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="selectName">查询方法名称</param>
        ///// <param name="sql">sql语句</param>
        ///// <param name="description">描述</param>
        ///// <param name="isReturnMult">是否返回多行</param>
        //public ViewSelectAttribute(string selectName, string sql, string description, bool isReturnMult = false)
        //{
        //    this.Description = description;
        //    this.IsReturnMult = isReturnMult;
        //    this.Name = selectName;
        //    this.Sql = sql;
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="selectName">查询方法名称</param>
        ///// <param name="sql">sql语句</param>
        ///// <param name="whereFields">where条件字段格式为：yhid:int|yhxm:string</param>
        ///// <param name="description">方法描述</param>
        ///// <param name="isReturnMult">是否返回多行</param>
        //public ViewSelectAttribute(string selectName, string sql, string whereFields, string description,
        //    bool isReturnMult = false)
        //{
        //    this.Description = description;
        //    this.Sql = sql;
        //    this.IsReturnMult = isReturnMult;
        //    this.Name = selectName;

        //    var tempdics = whereFields.Split('|');
        //    this.WhereFields = new Dictionary<string, string>();
        //    for (int i = 0; i < tempdics.Length; i++)
        //    {
        //        var tempKV = tempdics[i].Split(':');
        //        this.WhereFields.Add(tempKV[0], tempKV[1]);
        //    }
        //}


        //public string CreateCode(DBTableAttribute tableAttribute ,Type p)
        //{
        //    //string className = p.Name.StartsWith("m_")?p.Name.Substring(2,p.Name.Length-2):p.Name;//设置类名
        //    string rtnType = this.IsReturnMult ? string.Format("IList<{0}>",p.FullName):p.FullName;//返回类型
        //    StringBuilder sb=new StringBuilder();
        //    sb.AppendLine("        /// <summary>");
        //    sb.Append("        /// ").AppendLine(this.Description);
        //    sb.AppendLine("        /// </summary>");
        //    sb.Append(GetParamStr());
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.Append(string.Format("        public {0} {1}", rtnType, this.Name)).AppendLine(GetParam());
        //    sb.AppendLine("        {");
        //    sb.AppendLine(string.Format("            IList<{0}> result = null;", p.FullName));
        //    sb.AppendLine("            using (CDataBase cdb = new CDataBase(_dbUser))");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                try");
        //    sb.AppendLine("                {");
        //    sb.Append(GetParameters());
        //    sb.AppendLine(string.Format("                    result = cdb.GetDataItems<{0}>(\"{1}\");",p.FullName,this.Sql));
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                catch (Exception ex)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    Lenovo.Tool.Log4NetHelper.Error(ex);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine(string.Format("            return {0};",this.IsReturnMult ? "result" : "result.FirstOrDefault()"));
        //    sb.AppendLine("        }");
        //    return sb.ToString();
        //}

        //private string GetParamStr()
        //{
        //    StringBuilder sb=new StringBuilder();
        //    if (this.WhereFields != null && this.WhereFields.Count > 0)
        //    {
        //        foreach (var field in WhereFields)
        //        {
        //            sb.AppendLine(string.Format("        /// <param name=\"{0}\"></param>", field.Key));
        //        }
        //    }
        //    return sb.ToString();
        //}

        //private string GetParam()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (this.WhereFields != null && this.WhereFields.Count > 0)
        //    {
        //        foreach (var field in WhereFields)
        //        {
        //            if (sb.Length > 0)
        //            {
        //                sb.Append(string.Format(",{0} {1}", field.Value, field.Key));
        //            }
        //            else
        //            {
        //                sb.Append(string.Format("{0} {1}", field.Value, field.Key));
        //            }
        //        }
        //    }
        //    return string.Format("({0})",sb.ToString());
        //}

        //private string GetParameters()
        //{
        //    StringBuilder sb=new StringBuilder();
        //    if (this.WhereFields != null && this.WhereFields.Count > 0)
        //    {
        //        sb.AppendLine("                    cdb.ParametersClear();");
        //        foreach (var field in WhereFields)
        //        {
        //            sb.AppendLine(string.Format("                    cdb.ParametersAdd(\":{0}\", {0});",field.Key));
        //        }
        //    }
        //    return sb.ToString();
        //}

       
    }
}