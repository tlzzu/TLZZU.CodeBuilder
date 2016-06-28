using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using TLZZU.CodeBuild.Attribute;

namespace TLZZU.CodeBuild
{
    public class MakeCode
    {
        //public static void AddAttribute()

        /// <summary>
        /// 根据传入的dll路径，来反射dll，获取里面的特性值
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string DoBuild(string nameSpace,string path)
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
                //if (publicClass!=null&&publicClass.Length > 0)
                //    sb.Append("using ").Append(publicClass[0].Namespace).AppendLine(";");
                sb.Append("namespace ").AppendLine(nameSpace).AppendLine("{");
                sb.AppendLine(DB.GetDB());
                foreach (var p in publicClass)
                {
                    sb.AppendLine(GetClassCode(p));
                }
                return sb.AppendLine("}").ToString();
            }
            catch (Exception ex)
            {
                return sb.Clear().AppendLine(ex.Message).AppendLine(string.Empty).AppendLine(ex.StackTrace).ToString();
            }
        }
        /// <summary>
        /// 生成类，并且判断是那种方式的生成
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string GetClassCode(Type p)
        {
            MemberInfo classInfo = p;
            StringBuilder sb=new StringBuilder();
            var attrs = System.Attribute.GetCustomAttributes(classInfo, typeof (System.Attribute)).ToList();

            if (attrs == null || attrs.Count <= 0)
                return string.Empty;
            Attribute.DBTableAttribute table = null;
            bool isPartial = false;//是否存在扩展类
            //bool isNR = false;//是否存在非扩展类
            attrs.ForEach(a =>
            {
                if (table == null && a.GetType() == typeof (Attribute.DBTableAttribute))
                {
                    table = a as Attribute.DBTableAttribute;
                }
                else if (!isPartial && a is Attribute.IReleaseMaker)
                {
                    isPartial = true;
                }
                //else if (!isNR && a is Attribute.INoReleaseMaker)
                //{
                //    isNR = true;
                //}
            });
            if (table == null)
                return string.Empty;
            if (isPartial)
                sb.AppendLine(DoPartialCode(table, attrs,p));
            //if (isNR)
            //    sb.AppendLine(DoNRCode(table, attrs,p));
            return sb.ToString();
        }
        /// <summary>
        /// 获取扩展类的
        /// </summary>
        /// <param name="table"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private static string DoPartialCode(DBTableAttribute table, List<System.Attribute> attrs,Type p)
        {
            string className = p.Name.StartsWith("m_") ? p.Name.Substring(2, p.Name.Length - 2) : p.Name;//设置类名
            StringBuilder attrBuilder=new StringBuilder();
            //todo 实现该类
            attrBuilder.Append("    #region 外部可直接访问 注释：").Append(p.FullName).AppendLine(table.Description);
            attrBuilder.AppendLine("    /// <summary>");
            attrBuilder.AppendLine("    /// 模板生成");
            attrBuilder.Append("    /// CreateBy 童岭 ").AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            attrBuilder.Append("    /// ").AppendLine(table.Description);
            attrBuilder.Append("    /// ").Append(table.TableName).Append("表所属用户 ").AppendLine(table.BelongToDBUser);
            attrBuilder.AppendLine("    /// </summary>");
            attrBuilder.Append("    public partial class dl_").AppendLine(className);
            attrBuilder.AppendLine("    {");
            attrBuilder.Append("        private static readonly string _dbUser = ");
            if (string.IsNullOrWhiteSpace(table.BelongToDBUser))//return string.IsNullOrWhiteSpace(this.TableName)?:this.TableName;
            {
                attrBuilder.Append("System.Configuration.ConfigurationSettings.AppSettings[\"app_user\"].ToString()");
            }
            else {
                attrBuilder.Append("\"").Append(table.BelongToDBUser).Append("\"");
            }
            attrBuilder.Append(";//定义该表数据库访问用户");
            foreach (var attr in attrs) //遍历每一个特性
            {
                if (attr is Attribute.IReleaseMaker) //如果其实现了ICodeBuildMaker 接口
                {
                    attrBuilder.AppendLine((attr as Attribute.IReleaseMaker).CreateCode(table,p)); //添加方法
                }
            }
            return attrBuilder.AppendLine("    }").AppendLine("    #endregion").ToString();
        }

        ///// <summary>
        ///// 获取非扩展类，并且cdb不释放
        ///// </summary>
        ///// <param name="table"></param>
        ///// <param name="attrs"></param>
        ///// <returns></returns>
        //private static string DoNRCode(DBTableAttribute table, List<System.Attribute> attrs,Type p)
        //{
        //    string className = p.Name.StartsWith("m_") ? p.Name.Substring(2, p.Name.Length - 2) : p.Name;//设置类名
        //    StringBuilder attrBuilder = new StringBuilder();
        //    //todo 实现该类
        //    attrBuilder.Append("    #region 外部不可直接访问，需要自己写方法调用 注释：").Append(p.FullName).AppendLine(table.Description);
        //    attrBuilder.AppendLine("    /// <summary>");
        //    attrBuilder.AppendLine("    /// 模板生成，该类不可扩展");
        //    attrBuilder.Append("    /// CreateBy 童岭 ").AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    attrBuilder.Append("    /// ").AppendLine(table.Description);
        //    attrBuilder.Append("    /// ").Append(table.TableName).Append("表所属用户 ").AppendLine(table.BelongToDBUser);
        //    attrBuilder.AppendLine("    /// </summary>");
        //    attrBuilder.Append("    internal class nr_").AppendLine(className);
        //    attrBuilder.AppendLine("    {");
        //    attrBuilder.AppendLine("        private CDataBase cdb;//操作数据库实体");
        //    attrBuilder.AppendLine(string.Format("        public nr_{0}(CDataBase {1})",className,table.BelongToDBUser));
        //    attrBuilder.AppendLine("        {");
        //    attrBuilder.AppendLine(string.Format("            this.cdb = {0};",table.BelongToDBUser));
        //    attrBuilder.AppendLine("        }");
        //    foreach (var attr in attrs) //遍历每一个特性
        //    {
        //        if (attr is Attribute.INoReleaseMaker) //如果其实现了ICodeBuildMaker 接口
        //        {
        //            attrBuilder.AppendLine((attr as Attribute.INoReleaseMaker).CreateCode(table,p)); //添加方法
        //        }
        //    }
        //    return attrBuilder.AppendLine("    }").AppendLine("    #endregion").ToString();
        //}
    }

    
}