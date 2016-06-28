using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Oracle
{
    public class BuildCode
    {
        /// <summary>
        /// 创建某个用户下的表结构
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        public static string MakeEntity<TDBInformation>() where TDBInformation : IDBInformation
        {
            

            return "";
        }





        /// <summary>
        /// 数据库用户，可以不写 有个默认用户对象
        /// </summary>
        private static IList<string> _dbUsers=new List<string>();
        /// <summary>
        /// 开始生成代码
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MakeClass(string nameSpace, string path)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string newPath = string.Format("{0}_temp-{1}.dll", path, DateTime.Now.Ticks.ToString());
                File.Copy(path, newPath);
                Assembly assembly = Assembly.LoadFile(newPath);
                var publicClass = assembly.GetExportedTypes(); //获取所有公共实体类
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine("using System.Data.OracleClient;");
                sb.AppendLine("using System.ComponentModel;");
                sb.Append("namespace ").AppendLine(nameSpace).AppendLine("{");
                //sb.AppendLine(BuildOracleHelper.CreateCode());//生成外界代码
                foreach (var p in publicClass)
                {
                    sb.AppendLine(DoClass(p));
                }
                sb.AppendLine(DoStaticConnString());
                return sb.AppendLine("}").ToString();
            }
            catch (Exception ex)
            {
                return sb.Clear().AppendLine(ex.Message).AppendLine(string.Empty).AppendLine(ex.StackTrace).ToString();
            }
        }

      
        

        #region 私有方法
        /// <summary>
        /// 生成连接字符串方法
        /// </summary>
        /// <returns></returns>
        private static string DoStaticConnString()
        {
            string reserve = "           ";//预留空间
            StringBuilder sb = new StringBuilder();
            sb.Append(reserve).AppendLine("internal partial class OracleHelper");
            sb.Append(reserve).AppendLine("{");
            sb.Append(reserve).AppendLine("    public static string defalutConnString{ get{return System.Configuration.ConfigurationSettings.AppSettings[\"defaultOracleConn\"];}}");
            foreach (var item in _dbUsers)
            {
                sb.Append(reserve).AppendLine(string.Format("    public static string {0}ConnString{ get{return System.Configuration.ConfigurationSettings.AppSettings[\"{0}OracleConn\"];}}",item));
            }
            sb.Append(reserve).AppendLine("}");
            return sb.ToString();
        }

        /// <summary>
        /// 构建类方法
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string DoClass(Type p)
        {
            MemberInfo classInfo = p;
            StringBuilder sb = new StringBuilder();
            var attrs = System.Attribute.GetCustomAttributes(classInfo, typeof(System.Attribute)).ToList();
            if (attrs == null || attrs.Count <= 0)
                return string.Empty;
            Attribute.TableAttribute table = null;
            bool isPartial = false;//是否有自动生成的方法
            attrs.ForEach(a =>
            {
                if (table == null && a.GetType() == typeof(Attribute.TableAttribute))
                {
                    table = a as Attribute.TableAttribute;
                    if (!string.IsNullOrWhiteSpace(table.BelongToDBUser) && !_dbUsers.Contains(table.BelongToDBUser)) {
                        _dbUsers.Add(table.BelongToDBUser);
                    }
                }
                else if (!isPartial && a is IBaseMaker)
                {
                    isPartial = true;
                }
            });
            if (table == null)
                return string.Empty;
            if (isPartial)
                sb.AppendLine(DoMethod(table, attrs, p));
            return sb.ToString();
        }

        private static string DoMethod(Attribute.TableAttribute table, List<System.Attribute> attrs, Type p)
        {
            string className = table.TableName;// p.Name.StartsWith("m_") ? p.Name.Substring(2, p.Name.Length - 2) : p.Name;//设置类名
            StringBuilder attrBuilder = new StringBuilder();
            //todo 实现该类
            attrBuilder.Append("    #region 注释：").Append(p.FullName).AppendLine(table.Description);
            attrBuilder.AppendLine("    /// <summary>");
            attrBuilder.AppendLine("    /// 模板生成");
            attrBuilder.Append("    /// CreateBy 童岭 ").AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            attrBuilder.Append("    /// ").AppendLine(table.Description);
            attrBuilder.AppendLine("    /// </summary>");
            attrBuilder.Append("    public partial class dl_").AppendLine(className);
            attrBuilder.AppendLine("    {");
            foreach (var attr in attrs) //遍历每一个特性
            {
                if (attr is IBaseMaker) //如果其实现了ICodeBuildMaker 接口
                {
                    attrBuilder.AppendLine((attr as IBaseMaker).Do(table, p)); //添加方法
                }
            }
            return attrBuilder.AppendLine("    }").AppendLine("    #endregion").ToString();
        }

        #endregion
    }
}
