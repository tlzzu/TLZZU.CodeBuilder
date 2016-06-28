using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Attribute
{
    public abstract class BaseAttribute: System.Attribute
    {
        public string Description { get; set; }
        public string MethodName { get; set; }

        /// <summary>
        /// 利用正则表达式 获取参数 比如SELECT productID from products WHERE productid=:productid and name=:name and cc='34' 会获得productid和name
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<string> GetSqlParams(string sql) {
            Regex reg = new Regex(@":\w*");
            List<string> strs=new List<string>();
            if(reg.IsMatch(sql)){
                foreach (Match item in reg.Matches(sql))
                {
                    strs.Add(item.Value.Trim().Trim(':'));
                }
            }
            return strs;
        }
        /// <summary>
        /// 返回数据库所需参数
        /// </summary>
        /// <param name="format">比如：                    cdb.Parameters.Add(":{0}", model.{1});</param>
        /// <param name="sqlParam">代表0</param>
        /// <param name="p">代表所对应的1</param>
        /// <returns></returns>
        public string GetParamStr(string format, List<string> sqlParam,Type p)
        {
            if (sqlParam == null || sqlParam.Count <= 0)
            {
                return string.Empty;
            }
            var pros=p.GetProperties().Select(a=>a.Name).ToList();
            StringBuilder sb = new StringBuilder();
            if (this.GetType().FullName.Contains("NoRelease"))
            {
                sb.AppendLine("                cdb.Parameters.Clear();");
            }
            else
            {
                sb.AppendLine("                    cdb.Parameters.Clear();");
            }
            foreach (var item in sqlParam)
            {
                var pro=pros.FindAll(a=>a.ToUpper()==item.ToUpper());
                if (pro != null && pro.Count > 0)
                {
                    sb.AppendLine(string.Format(format, item, pro.FirstOrDefault()));
                }
                else {
                    throw new Exception(string.Format("{0}对象的{1}方法{2}【sql】参数无法匹配！",p.FullName,this.MethodName,item));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取方法参数 比如 string name,int age
        /// </summary>
        /// <param name="sqlParam"></param>
        /// <param name="p"></param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public string GetMethodParam(List<string> sqlParam, Type p, string prefix="")
        {
            List<string> list=new List<string>();
            foreach (var item in sqlParam)
            {
                var temp=p.GetProperties().ToList().FindAll(a=>a.Name.ToUpper()==item.ToUpper());
                if (temp != null && temp.Count > 0)
                {
                    var tempType = temp.FirstOrDefault().PropertyType;
                    if (tempType.IsGenericType && tempType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        tempType = tempType.GetGenericArguments().FirstOrDefault();
                        list.Add(string.Format("{0}? {2}{1}", tempType.Name, temp.FirstOrDefault().Name, prefix));
                    }
                    else {
                        list.Add(string.Format("{0} {2}{1}", tempType.Name, temp.FirstOrDefault().Name, prefix));
                    }
                    
                }
            }
            return string.Join(",",list);
        }
        /// <summary>
        /// 获取比如：name,age,sex
        /// </summary>
        /// <param name="sqlParam"></param>
        /// <param name="p"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetMethodParamFields(List<string> sqlParam, Type p, string prefix = "")
        {
            List<string> list = new List<string>();
            foreach (var item in sqlParam)
            {
                var temp = p.GetProperties().ToList().FindAll(a => a.Name.ToUpper() == item.ToUpper());
                if (temp != null && temp.Count > 0)
                {
                    var tempType = temp.FirstOrDefault().PropertyType;
                    if (tempType.IsGenericType && tempType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        tempType = tempType.GetGenericArguments().FirstOrDefault();
                    }
                    list.Add(string.Format("{1}{0}",temp.FirstOrDefault().Name,prefix));
                }
            }
            return string.Join(",", list);
        }

        /// <summary>
        /// 匹配sql语句 比如select * from xxx where 1=1
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model">实体名称</param>
        public void VerifySelectSql(string sql,string model) {

            //var currentSql = sql.Trim().ToLower();
            //if (!currentSql.StartsWith("select "))
            //    throw new Exception(string.Format("{0}方法sql语句错误，不存在select 关键字，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));
            //currentSql = currentSql.Substring(6, currentSql.Length - 7).Trim();//去除开头的 select
            //if(!currentSql.Contains(" from "))
            //    throw new Exception(string.Format("{0}方法sql语句错误，不存在 from 关键字，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));
            
            //var temp1 = currentSql.Replace(" from ","|").Split('|')[0];
            //if(temp1.Contains("select ")||temp1.Contains(" where "))
            //    throw new Exception(string.Format("{0}方法sql语句错误，不存在 from 关键字所在位置错误，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));
            //if(currentSql.Contains("where")&&!currentSql.Contains(" where "))
            //    throw new Exception(string.Format("{0}方法sql语句错误，where关键字错误，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));

        }
        /// <summary>
        /// 验证 where语句是否正确 不能匹配嵌套where语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        public void VerifyWhereSql(string sql, string model)
        {

            //var currentSql = sql.Trim().ToLower();
            //if (currentSql.Split('=').Length > 2 && !currentSql.Contains(" and "))
            //    throw new Exception(string.Format("{0}方法where语句错误，and关键字错误，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));
            //var tempAnd = currentSql.Replace(" and ", "|").Split('|').Length + 1;
            //if (currentSql.Split('=').Length != tempAnd)
            //    throw new Exception(string.Format("{0}方法where语句错误，and关键字与=数理无法匹配，请检查！原始sql语句为:{1},该错误所属实体类为：{2}", this.MethodName, sql, model));
        }


    }
}
