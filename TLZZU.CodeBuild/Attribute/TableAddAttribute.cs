using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TableAddAttribute:BaseAttribute,IReleaseMaker
    {
        public TableAddAttribute():this("Add","新增方法") { }

        public TableAddAttribute(string methodName, string description) {
            this.Description = description;
            this.MethodName = methodName;
        }

        /// <summary>
        /// 返回数据库所需参数
        /// </summary>
        /// <param name="format">比如：                    cdb.Parameters.Add(":{0}", model.{1});</param>
        /// <param name="p">代表所对应的1</param>
        /// <returns></returns>
        public string GetParamStrAdd(string format, Type p)
        {
            var pros = p.GetProperties().Select(a => a.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                    var fields = new List<string>();");
            sb.AppendLine("                    cdb.Parameters.Clear();");
            foreach (var item in p.GetProperties())
            {
                if (item.CustomAttributes.Count() > 0 && item.CustomAttributes.FirstOrDefault().AttributeType == typeof(FieldSeqAttribute))
                {
                     MemberInfo classInfo = item;
                    var seq=System.Attribute.GetCustomAttribute(classInfo,typeof(FieldSeqAttribute)) as FieldSeqAttribute;
                    //sb.AppendLine(string.Format("                    cdb.Parameters.Add(\":{0}\", cdb.GetNextValue(\"{1}\"));", item.Name, seq.Seq));
                    sb.AppendLine(string.Format("                model.{0}=cdb.GetNextValue(\"{1}\");", item.Name, seq.Seq));
                }
                if (item.CustomAttributes.Count() > 0 && item.CustomAttributes.FirstOrDefault().AttributeType == typeof(FieldNoDBAttribute))
                {
                    //不是数据库中的字段
                }
                else
                {
                    sb.AppendLine(string.Format(format, item.Name, item.Name));
                }
               
            }
            return sb.ToString();
        }


        /// <summary>
        /// 返回数据库所需参数
        /// </summary>
        /// <param name="format">比如：                    cdb.Parameters.Add(":{0}", model.{1});</param>
        /// <param name="p">代表所对应的1</param>
        /// <returns></returns>
        public string GetNRParamStrAdd(string format, Type p)
        {
            var pros = p.GetProperties().Select(a => a.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                    var fields = new List<string>();");
            sb.AppendLine("                cdb.Parameters.Clear();");
            foreach (var item in p.GetProperties())
            {
                if (item.CustomAttributes.Count() > 0 && item.CustomAttributes.FirstOrDefault().AttributeType == typeof(FieldSeqAttribute))
                {
                    MemberInfo classInfo = item;
                    var seq = System.Attribute.GetCustomAttribute(classInfo, typeof(FieldSeqAttribute)) as FieldSeqAttribute;
                    sb.AppendLine(string.Format("                model.{0}=cdb.GetNextValue(\"{1}\");", item.Name, seq.Seq));
                    //sb.AppendLine(string.Format("                cdb.Parameters.Add(\":{0}\", cdb.GetNextValue(\"{1}\"));", item.Name, seq.Seq));
                }

                if (item.CustomAttributes.Count() > 0 && item.CustomAttributes.FirstOrDefault().AttributeType == typeof(FieldNoDBAttribute))
                {
                    //不是数据库中的字段
                }
                else
                {
                    sb.AppendLine(string.Format(format, item.Name, item.Name));
                }
                
            }
            return sb.ToString();
        }

        public IList<string> GetFields(Type p)
        {
            IList<string> fields = new List<string>();
            foreach (var item in p.GetProperties())
            {
                if (item.CustomAttributes.Count() > 0 && item.CustomAttributes.FirstOrDefault().AttributeType == typeof(FieldNoDBAttribute))
                {
                    //不是数据库中的字段
                }
                else
                {
                    fields.Add(item.Name);
                }
            }
            return fields;
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
        
        /// <summary>
        /// 不是放CDataBase对象
        /// </summary>
        /// <param name="tableAttribute"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private string CreateNRCode(DBTableAttribute tableAttribute, Type p) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>").
               AppendLine("        /// <param name=\"model\">新增对象</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine(string.Format("        internal int {0}({1} model,CDataBase cdb)", this.MethodName, p.FullName));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.Append(this.GetNRParamStrAdd("                if(model.{1}!=null) fields.Add(\"{0}\");if(model.{1}!=null) cdb.Parameters.Add(\":{0}\",model.{1});", p));
            //var fields = GetFields(p);

            sb.AppendLine("                cdb.ExeSQL(string.Format(\"insert into " + tableAttribute.TableName + "({0}) values(:{1})\",string.Join(\",\",fields),string.Join(\",:\",fields)));");
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
            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();


            /*
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>").
               AppendLine("        /// <param name=\"model\">新增对象</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine(string.Format("        internal int {0}({1} model,CDataBase cdb)", this.MethodName, p.FullName));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.Append(this.GetNRParamStrAdd("                cdb.Parameters.Add(\":{0}\",model.{1});", p));
            //var fields = p.GetProperties().Select(a => a.Name).ToList();
            var fields = GetFields(p);

            sb.AppendLine(string.Format("                cdb.ExeSQL(\"insert into {0}({1}) values(:{2})\");", tableAttribute.TableName, string.Join(",", fields), string.Join(",:", fields)));
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
            //sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
            //   AppendLine("            {").
            //   AppendLine("                if (oracleException.Number == 3113)").
            //   AppendLine(string.Format("                    return {0}(model);", this.MethodName)).
            //   AppendLine("                else").
            //   AppendLine("                    throw oracleException;").
            //   AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();
            */
        }
        /// <summary>
        /// 创建自助释放CDataBase 对象资源
        /// </summary>
        /// <param name="tableAttribute"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private string CreateDLCode(DBTableAttribute tableAttribute, Type p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>").
               AppendLine("        /// <param name=\"model\">新增对象</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine(string.Format("        public int {0}({1} model)", this.MethodName, p.FullName));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            sb.AppendLine("                {");
            sb.Append(this.GetParamStrAdd("                    if(model.{1}!=null) fields.Add(\"{0}\");if(model.{1}!=null)cdb.Parameters.Add(\":{0}\",model.{1});", p));
            var fields = GetFields(p);// p.GetProperties().Select(a => a.Name).ToList();
            sb.AppendLine("                cdb.ExeSQL(string.Format(\"insert into " + tableAttribute.TableName + "({0}) values(:{1})\",string.Join(\",\",fields),string.Join(\",:\",fields)));");
            sb.AppendLine("                    var result=cdb.SqlNRows;");
            sb.AppendLine("                    if (result > 0){").
               AppendLine("                         cdb.Commit();").
               AppendLine("                    }").
               AppendLine("                    else").
               AppendLine("                    {").
               AppendLine("                         cdb.Rollback();").
               AppendLine("                    }");
            sb.AppendLine("                    return result;");
            sb.AppendLine("                }").
               AppendLine("            }");
            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
              AppendLine("            {").
              AppendLine("                if (oracleException.Number == 3113)").
              AppendLine(string.Format("                return {0}(model);", this.MethodName)).
              AppendLine("                else").
              AppendLine("                    throw oracleException;").
              AppendLine("            }");

            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();


            /*
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("        /// <summary>").
               AppendLine("        /// " + this.Description).
               AppendLine("        /// </summary>").
               AppendLine("        /// <param name=\"model\">新增对象</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine(string.Format("        public int {0}({1} model)", this.MethodName, p.FullName));
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (CDataBase cdb = new CDataBase(_dbUser))");
            sb.AppendLine("                {");
            sb.Append(this.GetParamStrAdd("                    cdb.Parameters.Add(\":{0}\",model.{1});", p));
            var fields = GetFields(p);// p.GetProperties().Select(a => a.Name).ToList();
            sb.AppendLine(string.Format("                    cdb.ExeSQL(\"insert into {0}({1}) values(:{2})\");", tableAttribute.TableName, string.Join(",", fields), string.Join(",:", fields)));
            sb.AppendLine("                    var result=cdb.SqlNRows;");
            sb.AppendLine("                    if (result > 0){").
               AppendLine("                         cdb.Commit();").
               AppendLine("                    }").
               AppendLine("                    else").
               AppendLine("                    {").
               AppendLine("                         cdb.Rollback();").
               AppendLine("                    }");
            sb.AppendLine("                    return result;");
            sb.AppendLine("                }").
               AppendLine("            }");
            sb.AppendLine("            catch (Oracle.DataAccess.Client.OracleException oracleException)").
              AppendLine("            {").
              AppendLine("                if (oracleException.Number == 3113)").
              AppendLine(string.Format("                return {0}(model);", this.MethodName)).
              AppendLine("                else").
              AppendLine("                    throw oracleException;").
              AppendLine("            }");
            
            sb.AppendLine("            catch (Exception ex)").
               AppendLine("            {").
               AppendLine("                throw ex;").
               AppendLine("            }").
               AppendLine("        }");
            return sb.ToString();
            */
        }
    }
}
