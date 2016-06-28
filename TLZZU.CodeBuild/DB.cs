using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild
{
    internal class DB {
        public static string GetDB()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("    #region 数据库访问");
            sb.AppendLine("    using Oracle.DataAccess.Client;");
            sb.AppendLine("    using System;");
            sb.AppendLine("    using System.Collections.Generic;");
            sb.AppendLine("    using System.Collections.Specialized;");
            sb.AppendLine("    using System.ComponentModel;");
            sb.AppendLine("    using System.Configuration;");
            sb.AppendLine("    using System.Data;");
            sb.AppendLine("    using System.Linq;");
            sb.AppendLine("    using System.Text;");
            sb.AppendLine("    using System.Threading.Tasks;");
            sb.AppendLine("    internal class VariableInfo");
            sb.AppendLine("    {");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 应用程序级变量(配置文件和Application中变量的集合)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public class ApplicationVar");
            sb.AppendLine("        {");
            sb.AppendLine("            private static string _applname;");
            sb.AppendLine("            private static string _appldm;");
            sb.AppendLine("            private static string _znqxglmkdm;//组内权限管理模块代码");
            sb.AppendLine("            private static string _dwdm;");
            sb.AppendLine("            private static string _dwmc;");
            sb.AppendLine("            private static string _ywdwmc;  //英文单位名称");
            sb.AppendLine("            private static string _servicephone;  //服务电话");
            sb.AppendLine("            private static string _HaveGlobalAccessControl;");
            sb.AppendLine("            private static long _ApplTotalLoginUserCount;");
            sb.AppendLine("            private static long _OnLineUserCount;");
            sb.AppendLine("            private static string _sbyxbs;");
            sb.AppendLine("            private static string _sbyljgdm;//社保医疗机构代码");
            sb.AppendLine("            private static string _nbyljgdm;//农保医疗机构代码");
            sb.AppendLine("            private static string _nbqzjdz;//农保前置机网络地址：IP+端口号");
            sb.AppendLine("            private static int? _xtggid;//系统公告信息ID号");
            sb.AppendLine("            private static string _oaxxlb;//oa系统短信的消息类别");
            sb.AppendLine("            private static System.Object _LockObj1 = new object();");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 应用程序名称");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string ApplName");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_applname))");
            sb.AppendLine("                        _applname = System.Configuration.ConfigurationManager.AppSettings[\"applname\"];");
            sb.AppendLine("                    return _applname;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _applname = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// oa系统短信的消息类别");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string OAXXLB");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_oaxxlb))");
            sb.AppendLine("                        _oaxxlb = System.Configuration.ConfigurationManager.AppSettings[\"oaxxlb\"];");
            sb.AppendLine("                    return _oaxxlb;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _oaxxlb = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 应用程序代码");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string ApplDm");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_appldm))");
            sb.AppendLine("                        _appldm = System.Configuration.ConfigurationManager.AppSettings[\"appldm\"];");
            sb.AppendLine("                    return _appldm;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _appldm = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 组内权限管理模块代码");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string ZNQXGLMKDM");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_znqxglmkdm))");
            sb.AppendLine("                        _znqxglmkdm = System.Configuration.ConfigurationManager.AppSettings[\"znqxglmkdm\"];");
            sb.AppendLine("                    return _znqxglmkdm;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _znqxglmkdm = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 系统公告ID");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static int? XTGGID");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (!_xtggid.HasValue)");
            sb.AppendLine("                        _xtggid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[\"xtggid\"]);");
            sb.AppendLine("                    return _xtggid;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _xtggid = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 当前登录用户人数（即当前在线人数）");
            sb.AppendLine("            /// *注意* 使用 OnLineUserCount++会导致ApplTotalLoginUserCount自动加一");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static long OnLineUserCount");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    lock (_LockObj1)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        if (_OnLineUserCount < 0)");
            sb.AppendLine("                            _OnLineUserCount = 0;");
            sb.AppendLine("                        return _OnLineUserCount;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    lock (_LockObj1)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        if (_OnLineUserCount == value - 1)");
            sb.AppendLine("                        {");
            sb.AppendLine("                            _ApplTotalLoginUserCount++;");
            sb.AppendLine("                        }");
            sb.AppendLine("                        _OnLineUserCount = value;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 单位代码");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string dwdm");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_dwdm))");
            sb.AppendLine("                        _dwdm = System.Configuration.ConfigurationManager.AppSettings[\"dwdm\"];");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_dwdm)) _dwdm = \"01\";");
            sb.AppendLine("                    return _dwdm;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _dwdm = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 单位名称");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string dwmc");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_dwmc))");
            sb.AppendLine("                        _dwmc = System.Configuration.ConfigurationManager.AppSettings[\"dwmc\"];");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_dwmc)) _dwmc = \"温州医院\";");
            sb.AppendLine("                    return _dwmc;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _dwmc = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 英文单位名称");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string ywdwmc");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_ywdwmc))");
            sb.AppendLine("                        _ywdwmc = System.Configuration.ConfigurationManager.AppSettings[\"ywdwmc\"];");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_ywdwmc)) _ywdwmc = \"WenZhou Hospital\";");
            sb.AppendLine("                    return _ywdwmc;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _ywdwmc = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 服务电话(错误页中用到)");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string servicephone");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_servicephone))");
            sb.AppendLine("                        _servicephone = System.Configuration.ConfigurationManager.AppSettings[\"servicephone\"];");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_servicephone)) _servicephone = \"没有登记服务电话\";");
            sb.AppendLine("                    return _servicephone;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _servicephone = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 全局页面访问控制模式");
            sb.AppendLine("            /// \"0\" 不控制");
            sb.AppendLine("            /// \"1\" 已经登记的页面按权限访问，没有登记则不控制访问");
            sb.AppendLine("            /// \"2\" 已经登记的页面按权限访问，没有登记则禁止访问");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string GlobalAccessControl");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_HaveGlobalAccessControl))");
            sb.AppendLine("                        _HaveGlobalAccessControl = System.Configuration.ConfigurationManager.AppSettings[\"GlobalAccessControl\"];");
            sb.AppendLine("                    return _HaveGlobalAccessControl;");
            sb.AppendLine("                }");
            sb.AppendLine("                set");
            sb.AppendLine("                {");
            sb.AppendLine("                    _HaveGlobalAccessControl = value;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 农保医疗机构代码");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string NBYLJGDM");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_nbyljgdm))");
            sb.AppendLine("                    {");
            sb.AppendLine("                        lock (_LockObj1)");
            sb.AppendLine("                        {");
            sb.AppendLine("");
            sb.AppendLine("                            _nbyljgdm = \"1001\";");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                    return _nbyljgdm;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            /// <summary>");
            sb.AppendLine("            /// 农保前置机IP地址及端口号");
            sb.AppendLine("            /// </summary>");
            sb.AppendLine("            public static string NBQZJDZ");
            sb.AppendLine("            {");
            sb.AppendLine("                get");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (string.IsNullOrEmpty(_nbqzjdz))");
            sb.AppendLine("                    {");
            sb.AppendLine("                        lock (_LockObj1)");
            sb.AppendLine("                        {");
            sb.AppendLine("");
            sb.AppendLine("                            _nbqzjdz = \"172.16.12.92:9999\";");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                    return _nbqzjdz;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 自定义异常类");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    internal class CustomException : ApplicationException");
            sb.AppendLine("    {");
            sb.AppendLine("        private string _ipAddress;  //客户端ip地址");
            sb.AppendLine("        private string _czz;        //操作者");
            sb.AppendLine("        private Int64 _idczz;       //操作者ID    ");
            sb.AppendLine("        private string _url;        //出错页面");
            sb.AppendLine("        private string _userAgent;  //客户段浏览器代理信息");
            sb.AppendLine("        private CustomExceptionType _exceptionType;");
            sb.AppendLine("        private bool _loged = false;");
            sb.AppendLine("        private string _hostname;");
            sb.AppendLine("        protected void Init()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                _exceptionType = CustomExceptionType.UnKnowException;");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                System.Diagnostics.Debug.Write(ex.Message);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        #region 构造函数");
            sb.AppendLine("        public CustomException(CustomExceptionType exceptionType, string message, Exception innerException)");
            sb.AppendLine("            : base(message, innerException)");
            sb.AppendLine("        {");
            sb.AppendLine("            Init();");
            sb.AppendLine("            _exceptionType = exceptionType;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        public CustomException(string message, Exception innerException)");
            sb.AppendLine("            : base(message, innerException)");
            sb.AppendLine("        {");
            sb.AppendLine("            Init();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public CustomException(CustomExceptionType exceptionType, string message)");
            sb.AppendLine("            : base(message)");
            sb.AppendLine("        {");
            sb.AppendLine("            Init();");
            sb.AppendLine("            _exceptionType = exceptionType;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public CustomException(string message)");
            sb.AppendLine("            : base(message)");
            sb.AppendLine("        {");
            sb.AppendLine("            Init();");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 属性");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取包括InnerException的所有异常信息");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public virtual string MessageAll");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                string ls_msg = base.Message;");
            sb.AppendLine("");
            sb.AppendLine("                if (InnerException != null)");
            sb.AppendLine("                {");
            sb.AppendLine("                    CustomException blex = InnerException as CustomException;");
            sb.AppendLine("                    if (blex != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        if (string.IsNullOrEmpty(ls_msg))");
            sb.AppendLine("                            ls_msg = blex.MessageAll;");
            sb.AppendLine("                        else");
            sb.AppendLine("                            ls_msg = ls_msg + \",\" + blex.MessageAll;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    else");
            sb.AppendLine("                    {");
            sb.AppendLine("                        if (string.IsNullOrEmpty(ls_msg))");
            sb.AppendLine("                            ls_msg = InnerException.Message;");
            sb.AppendLine("                        else");
            sb.AppendLine("                            ls_msg = ls_msg + \",错误原因：\" + InnerException.Message;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine("                return ls_msg;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 客户端IP地址");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public string IPAddress");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _ipAddress;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 操作者");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public string Czz");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _czz;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 操作者ID");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public Int64 IDCzz");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _idczz;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 出错页面");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public string URL");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _url;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 客户段浏览器代理信息");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public string UserAgent");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _userAgent;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public string HostName");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _hostname;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public string YYDM");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return VariableInfo.ApplicationVar.ApplDm;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 异常类型");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public CustomExceptionType ExceptionType");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _exceptionType;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 异常类型");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    internal enum CustomExceptionType");
            sb.AppendLine("    {");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        //------------101-200为一般等级的异常类型--------//");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 验证异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Validate = 101,");
            sb.AppendLine("");
            sb.AppendLine("        //----------------------------------------------//");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        //------------201-300为严重等级的异常类型--------//");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 严重的异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Serious = 201,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 数据库访问异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        DataAccess = 202,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取数据库数据异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Select = 203,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入数据库数据异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Insert = 204,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新数据库数据异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Update = 205,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除数据库数据异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        Delete = 206,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新并发异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        UpdateConcurrency = 207,");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除并发异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        DeleteConcurrency = 208,");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        //------------------------------------");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 未知异常");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        UnKnowException = 999");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("    internal partial class CDataBase : IDisposable");
            sb.AppendLine("    {");
            sb.AppendLine("");
            sb.AppendLine("        public void ParametersClear()");
            sb.AppendLine("        {");
            sb.AppendLine("            this.Parameters.Clear();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public void ParametersAdd(string key, object value)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.Parameters.Add(key, value);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public IList<T> GetDataItems<T>(string sql) where T : class, new()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                this.iCommand.CommandText = sql;");
            sb.AppendLine("                this._iReader = this.iCommand.ExecuteReader();");
            sb.AppendLine("                if (!this._iReader.HasRows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    this._iReader.Close();");
            sb.AppendLine("                    return new List<T>();");
            sb.AppendLine("                }");
            sb.AppendLine("                Type typeFromHandle = typeof(T);");
            sb.AppendLine("                var inner =");
            sb.AppendLine("                    from i in Enumerable.Range(1, this._iReader.FieldCount)");
            sb.AppendLine("                    select new");
            sb.AppendLine("                    {");
            sb.AppendLine("                        Name = this._iReader.GetName(i - 1),");
            sb.AppendLine("                        Index = i - 1");
            sb.AppendLine("                    };");
            sb.AppendLine("                var enumerable = typeFromHandle.GetProperties().Join(inner, x => x.Name.ToUpper(), x => x.Name, (x, y) => new { y.Index, x });");
            sb.AppendLine("                List<T> list = new List<T>();");
            sb.AppendLine("                while (this._iReader.Read())");
            sb.AppendLine("                {");
            sb.AppendLine("                    T t = Activator.CreateInstance<T>();");
            sb.AppendLine("                    foreach (var current in enumerable)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        //tempType = current;");
            sb.AppendLine("                        //isNull = \"isNull\";");
            sb.AppendLine("                        //isNull = this._iReader[current.Index].ToString();");
            sb.AppendLine("");
            sb.AppendLine("                        if (this._iReader[current.Index].GetType() != typeof(DBNull))");
            sb.AppendLine("                        {");
            sb.AppendLine("                            try");
            sb.AppendLine("                            {");
            sb.AppendLine("                                if (current.x.PropertyType.IsGenericType && current.x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))");
            sb.AppendLine("                                {");
            sb.AppendLine("                                    current.x.SetValue(t, new NullableConverter(current.x.PropertyType).ConvertFromString(this._iReader[current.Index].ToString()), null);");
            sb.AppendLine("                                }");
            sb.AppendLine("                                else");
            sb.AppendLine("                                    current.x.SetValue(t, Convert.ChangeType(this._iReader[current.Index], current.x.PropertyType), null);");
            sb.AppendLine("");
            sb.AppendLine("                            }");
            sb.AppendLine("                            catch (Exception exe)");
            sb.AppendLine("                            {");
            sb.AppendLine("                                throw exe;");
            sb.AppendLine("                                //Lenovo.Tool.Log4NetHelper.Error(exe);");
            sb.AppendLine("                            }");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                    list.Add(t);");
            sb.AppendLine("                }");
            sb.AppendLine("                this._iReader.Close();");
            sb.AppendLine("                return list;");
            sb.AppendLine("");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return GetDataItems<T>(sql);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        #region 类成员定义");
            sb.AppendLine("        //实例化后成员：Oracle连接");
            sb.AppendLine("        private OracleConnection iConnection;    //Connect执行成功后：Oracle连接");
            sb.AppendLine("        private OracleCommand iCommand;          //实例化后成员：Oracle命令");
            sb.AppendLine("        private OracleCommand _DataTableSelectCommand;//SetDataTable后的可用成员：Oracle命令");
            sb.AppendLine("        private OracleDataAdapter _iAdapter;      //SetDateSet：OracleAdapter");
            sb.AppendLine("        private OracleDataReader _iReader;        //SetReader执行成功后：OracleReader");
            sb.AppendLine("        private DataTable _iDataTable;");
            sb.AppendLine("        private int _SqlNRows = -1;                 //ExeSQL执行后影响到的行数 -1表示未执行sql语句或不确定几条记录");
            sb.AppendLine("        private int _SqlCode = -1;                 //ExeSQL执行成功还是失败，－1失败 0成功");
            sb.AppendLine("        public string _SqlErrorText;");
            sb.AppendLine("");
            sb.AppendLine("        private OracleTransaction iTrans;       //Connect执行成功后：事务处理对象  bm zsm mm constr");
            sb.AppendLine("        //private static Dictionary<string, string> DbConnection = new Dictionary<string, string>();");
            sb.AppendLine("        //private static Dictionary<string, string> DbConnStr = new Dictionary<string, string>();");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 数据库用户集合，《 <数据库号，用户名>,连接串》");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private static Dictionary<KeyValuePair<int, string>, string> _dbuser = new Dictionary<KeyValuePair<int, string>, string>();");
            sb.AppendLine("        private bool disposed = false;");
            sb.AppendLine("        #endregion");
            sb.AppendLine("        #region 公有属性");
            sb.AppendLine("        public OracleDataAdapter iAdapter");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _iAdapter;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public OracleDataReader iReader");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _iReader;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public DataTable iDataTable");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _iDataTable;//db.iDataTable[0][0].;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public int SqlNRows");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _SqlNRows;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public int SqlCode");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _SqlCode;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public string SqlErrorText");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return _SqlErrorText;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        /// 只读属性 OracleParameterCollection");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public OracleParameterCollection Parameters");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return iCommand.Parameters;");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 返回datatable");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        #endregion");
            sb.AppendLine("        #region 构造函数和析构函数及资源的释放管理");
            sb.AppendLine("        //.............开始实例化后的方法定义.....................");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet三个成员");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public CDataBase()");
            sb.AppendLine("        {");
            sb.AppendLine("            iCommand = new OracleCommand();");
            sb.AppendLine("            iCommand.BindByName = true;");
            sb.AppendLine("            Connect(0, ConfigurationManager.AppSettings[\"DefaultUser\"]);");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
            sb.AppendLine("        public CDataBase(string vUser)");
            sb.AppendLine("        {");
            sb.AppendLine("            iCommand = new OracleCommand();");
            sb.AppendLine("            iCommand.BindByName = true;");
            sb.AppendLine("            Connect(0, vUser);");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
            sb.AppendLine("        public CDataBase(int ai_DBIndex, string vUser)");
            sb.AppendLine("        {");
            sb.AppendLine("            iCommand = new OracleCommand();");
            sb.AppendLine("            iCommand.BindByName = true;");
            sb.AppendLine("            Connect(ai_DBIndex, vUser);");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 释放托管与非托管资源");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"disposing\"></param>");
            sb.AppendLine("        [System.Diagnostics.DebuggerNonUserCodeAttribute()]");
            sb.AppendLine("        protected virtual void Dispose(bool disposing)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (!this.disposed)");
            sb.AppendLine("            {");
            sb.AppendLine("                //释放非托管资源");
            sb.AppendLine("                DisConnect();");
            sb.AppendLine("");
            sb.AppendLine("                //释放托管资源");
            sb.AppendLine("                if (disposing)");
            sb.AppendLine("                {");
            sb.AppendLine("                    iConnection.Dispose();");
            sb.AppendLine("                    iConnection = null;");
            sb.AppendLine("");
            sb.AppendLine("                    if (iTrans != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        iTrans.Dispose();");
            sb.AppendLine("                        iTrans = null;");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("                    if (_iAdapter != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        _iAdapter.Dispose();");
            sb.AppendLine("                        _iAdapter = null;");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                    if (_iReader != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        _iReader.Dispose();");
            sb.AppendLine("                        _iReader = null;");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("                    if (iCommand != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        iCommand.Dispose();");
            sb.AppendLine("                        iCommand = null;");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("                    if (_iDataTable != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        _iDataTable.Dispose();");
            sb.AppendLine("                        _iDataTable = null;");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("                }");
            sb.AppendLine("");
            sb.AppendLine("            }");
            sb.AppendLine("            disposed = true;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        public void Dispose()");
            sb.AppendLine("        {");
            sb.AppendLine("            Dispose(true);");
            sb.AppendLine("            GC.SuppressFinalize(this);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        ~CDataBase()");
            sb.AppendLine("        {");
            sb.AppendLine("            Dispose(false);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 服务器初始化用");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取指定数据库的DBUser个数");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        private static int GetDBUserCount(int ai_DBIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            int count = 0;");
            sb.AppendLine("            foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (ls_keyvalue.Key.Key == ai_DBIndex)");
            sb.AppendLine("                    count++;");
            sb.AppendLine("            }");
            sb.AppendLine("            return count;");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除指定数据库的所有DBUser");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
            sb.AppendLine("        private static void RemoveDBUser(int ai_DBIndex)");
            sb.AppendLine("        {");
            sb.AppendLine("            foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (ls_keyvalue.Key.Key == ai_DBIndex)");
            sb.AppendLine("                    _dbuser.Remove(ls_keyvalue.Key);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        private static string GenConnectString(string as_ds, string as_dbuser, string as_password)");
            sb.AppendLine("        {");
            sb.AppendLine("            string ls_constr;");
            sb.AppendLine("            ls_constr = \"Data Source=\" + as_ds + \";User ID=\" + as_dbuser + \";Password=\" + as_password +");
            sb.AppendLine("                        \";Pooling=false\" +             //true，则请求从连接池返回，没连接池则自动创建,默认值为true");
            sb.AppendLine("                \";Enlist=true\";           　　//");
            sb.AppendLine("            return \"Data Source=\" + as_ds + \";User ID=\" + as_dbuser + \";Password=\" + as_password + \";Pooling=true; Persist Security Info=True;min pool size=50;max pool size =100;\";");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 将字符转换为ＡＳＣ码");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"asciiCode\">字符</param>");
            sb.AppendLine("        /// <returns>对应的ＡＳＣ码</returns>");
            sb.AppendLine("        private static int Asc(string character)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (character.Length == 1)");
            sb.AppendLine("            {");
            sb.AppendLine("                byte[] bytes = System.Text.Encoding.Default.GetBytes(character);");
            sb.AppendLine("                int intAsciiCode = (int)bytes[0];");
            sb.AppendLine("                return (intAsciiCode);");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new Exception(\"字符的长度不对\");");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 返回字符串的长度（包括汉字），汉字长度为2");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
            sb.AppendLine("        /// <returns>字符串</returns>");
            sb.AppendLine("        private static int f_length(string yourstring)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return 0;");
            sb.AppendLine("            int len = yourstring.Length;");
            sb.AppendLine("            byte[] sarr = System.Text.Encoding.Default.GetBytes(yourstring);");
            sb.AppendLine("            return sarr.Length;");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 从左边开始取len长个几个字符串");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
            sb.AppendLine("        /// <param name=\"len\">指定长度</param>");
            sb.AppendLine("        /// <returns>字符串</returns>");
            sb.AppendLine("        private static string f_left(string yourstring, int ai_len)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (ai_len <= 0) return string.Empty;");
            sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return string.Empty;");
            sb.AppendLine("            int length = f_length(yourstring);");
            sb.AppendLine("            if (length <= ai_len)");
            sb.AppendLine("                return yourstring;");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                int tmp = 0;");
            sb.AppendLine("                int len = 0;");
            sb.AppendLine("                int okLen = 0;");
            sb.AppendLine("                int li_asc;");
            sb.AppendLine("                string ls_return = string.Empty;");
            sb.AppendLine("                for (int i = 0; i < length; i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    //获取asc码");
            sb.AppendLine("                    li_asc = Asc(yourstring.Substring(i, 1));");
            sb.AppendLine("                    if (li_asc > 127)");
            sb.AppendLine("                        tmp += 2;");
            sb.AppendLine("                    else");
            sb.AppendLine("                        len += 1;");
            sb.AppendLine("                    okLen += 1;");
            sb.AppendLine("                    if (tmp + len == ai_len)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ls_return = yourstring.Substring(0, okLen);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    else if (tmp + len > ai_len)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ls_return = yourstring.Substring(0, okLen - 1);");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("                return ls_return;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 从指定文字开始取len长的字符串");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
            sb.AppendLine("        /// <param name=\"start\">开始的位置</param>");
            sb.AppendLine("        /// <param name=\"len\">指定长度</param>");
            sb.AppendLine("        /// <returns>字符串</returns>");
            sb.AppendLine("        public static string f_mid(string yourstring, int start, int len)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (len <= 0 || start < 0) return string.Empty;");
            sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return string.Empty;");
            sb.AppendLine("            if (yourstring.Length < start) return string.Empty;");
            sb.AppendLine("            if (yourstring.Length <= start + len - 1)");
            sb.AppendLine("                return yourstring.Substring(start - 1);");
            sb.AppendLine("            else");
            sb.AppendLine("                return yourstring.Substring(start - 1, len);");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 按固定数、随机数加密或解密");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"as_pass\"></param>");
            sb.AppendLine("        /// <param name=\"ai_mod\">ai_mod = 0 固定数加密,ai_mod = 1 随机数加密,ai_mod = 2 解密</param>");
            sb.AppendLine("        /// <returns>加／解密后的字符串</returns>");
            sb.AppendLine("        private static string f_passwd2(string as_pass, int ai_mod)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (as_pass.Length > 23)");
            sb.AppendLine("                return \"-\";");
            sb.AppendLine("            int li_i, li_len, li_pos;");
            sb.AppendLine("            string ls_cpu = \"\", ls_tmp = \"\", ls_ret = \"\";");
            sb.AppendLine("            string[,] ls_pass = new string[14, 2];");
            sb.AppendLine("            if (ai_mod == 0 || ai_mod == 1)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (string.IsNullOrEmpty(as_pass)) return \"\";");
            sb.AppendLine("                as_pass = f_left(as_pass, 10);");
            sb.AppendLine("                if (ai_mod == 1)");
            sb.AppendLine("                {");
            sb.AppendLine("                    ls_cpu = DateTime.Now.ToString(\"mmss\");");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    ls_cpu = f_left(System.Convert.ToString(System.Convert.ToDouble(f_length(as_pass)) / 0.000412), 4);     //不能改变");
            sb.AppendLine("                }");
            sb.AppendLine("                li_len = f_length(as_pass);");
            sb.AppendLine("                ls_ret = as_pass + ls_cpu;");
            sb.AppendLine("                for (li_i = 1; li_i <= 4; li_i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));");
            sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
            sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
            sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);");
            sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
            sb.AppendLine("                    li_pos = (9 - li_pos) % (li_len + 4);");
            sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
            sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
            sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);");
            sb.AppendLine("                }");
            sb.AppendLine("                for (li_i = 1; li_i <= li_len + 4; li_i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (ls_pass[li_i - 1, 1] == \"1\") continue;");
            sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_i, 1);");
            sb.AppendLine("                }");
            sb.AppendLine("                ls_ret = System.Convert.ToString(li_len - 1) + ls_cpu + ls_tmp;");
            sb.AppendLine("                return ls_ret;");
            sb.AppendLine("            }");
            sb.AppendLine("            else if (ai_mod == 2)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (string.IsNullOrEmpty(as_pass)) return \"\";");
            sb.AppendLine("                li_len = System.Convert.ToInt32(f_mid(as_pass, 1, 1)) + 1;");
            sb.AppendLine("                ls_cpu = f_mid(as_pass, 2, 4);");
            sb.AppendLine("                ls_ret = f_mid(as_pass, 6, f_length(as_pass));");
            sb.AppendLine("                for (li_i = 1; li_i <= 4; li_i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));");
            sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
            sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
            sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
            sb.AppendLine("                    ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i - 1, 1);");
            sb.AppendLine("                    li_pos = (9 - li_pos) % (li_len + 4);");
            sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
            sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
            sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
            sb.AppendLine("                    ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i, 1);");
            sb.AppendLine("                }");
            sb.AppendLine("                li_pos = 9;");
            sb.AppendLine("                for (li_i = 1; li_i <= li_len; li_i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (ls_pass[li_i - 1, 1] == \"1\")");
            sb.AppendLine("                    {");
            sb.AppendLine("                        //null ");
            sb.AppendLine("                    }");
            sb.AppendLine("                    else");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ls_pass[li_i - 1, 0] = f_mid(ls_ret, li_pos, 1);");
            sb.AppendLine("                        li_pos++;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    ls_tmp = ls_tmp + ls_pass[li_i - 1, 0];");
            sb.AppendLine("                }");
            sb.AppendLine("                return ls_tmp;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                return as_pass;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 生成指定数据库的DBUser的配置信息（必须是使用温一医DBUser结构的）");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
            sb.AppendLine("        /// <param name=\"ab_IsForceUpdated\">是否强制重新获取信息</param>");
            sb.AppendLine("        private static void GetDBUserData(int ai_DBIndex, Boolean ab_IsForceUpdated)");
            sb.AppendLine("        {");
            sb.AppendLine("            lock (_dbuser)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (GetDBUserCount(ai_DBIndex) > 0 && ab_IsForceUpdated == false) //有数据而且不要求强制更新");
            sb.AppendLine("                {");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    RemoveDBUser(ai_DBIndex);");
            sb.AppendLine("                }");
            sb.AppendLine("                string ls_constr, ls_ds, ls_dbuser, ls_pwd;");
            sb.AppendLine("                NameValueCollection app = System.Configuration.ConfigurationManager.AppSettings;");
            sb.AppendLine("                //取预连接信息");
            sb.AppendLine("                ls_ds = app[\"dbservername\" + ai_DBIndex.ToString()];");
            sb.AppendLine("                ls_dbuser = app[\"predbuser\"];");
            sb.AppendLine("                ls_pwd = app[\"predbpwd\"];");
            sb.AppendLine("                ls_constr = GenConnectString(ls_ds, ls_dbuser, ls_pwd);");
            sb.AppendLine("                //预连接数据库获取数据库用户信息");
            sb.AppendLine("                using (OracleConnection con = new OracleConnection(ls_constr))");
            sb.AppendLine("                {");
            sb.AppendLine("");
            sb.AppendLine("                    OracleCommand cmd = new OracleCommand(\"select sjkyhm,sjkmm from vi_sjkyh\", con);");
            sb.AppendLine("                    con.Open();");
            sb.AppendLine("                    OracleDataAdapter iAdapter = new OracleDataAdapter();");
            sb.AppendLine("                    OracleDataReader odr = cmd.ExecuteReader();");
            sb.AppendLine("                    DataTable ldt = new DataTable();");
            sb.AppendLine("                    ldt.Columns.Add(\"name\");");
            sb.AppendLine("                    ldt.Columns.Add(\"password\");");
            sb.AppendLine("                    ldt.PrimaryKey = new DataColumn[] { ldt.Columns[0] };");
            sb.AppendLine("                    while (odr.Read())");
            sb.AppendLine("                    {");
            sb.AppendLine("                        DataRow ldr = ldt.NewRow();");
            sb.AppendLine("                        ldr[0] = f_passwd2(odr.GetString(0), 2).ToLower().Trim();");
            sb.AppendLine("                        ldr[1] = f_passwd2(odr.GetString(1), 2);");
            sb.AppendLine("                        ldt.Rows.Add(ldr);");
            sb.AppendLine("                    }");
            sb.AppendLine("                    odr.Close();");
            sb.AppendLine("                    foreach (DataRowView ldrv in ldt.DefaultView)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        ml_dbuser luser = new ml_dbuser();");
            sb.AppendLine("                        luser.DBIndex = ai_DBIndex;");
            sb.AppendLine("                        luser.DataBaseServerName = ls_ds;");
            sb.AppendLine("                        luser.Name = ldrv[0].ToString();");
            sb.AppendLine("                        luser.Password = ldrv[1].ToString();");
            sb.AppendLine("                        luser.Alias = app[luser.Name];");
            sb.AppendLine("                        if (string.IsNullOrEmpty(luser.Alias))");
            sb.AppendLine("                            luser.ConnectString = GenConnectString(ls_ds, luser.Name, luser.Password);");
            sb.AppendLine("                        else");
            sb.AppendLine("                        {");
            sb.AppendLine("                            DataRow ldr_row = ldt.Rows.Find(luser.Alias.ToLower());");
            sb.AppendLine("                            if (ldr_row != null)");
            sb.AppendLine("                                luser.Password = ldr_row[1].ToString();");
            sb.AppendLine("                            luser.ConnectString = GenConnectString(ls_ds, luser.Alias, luser.Password);");
            sb.AppendLine("");
            sb.AppendLine("                        }");
            sb.AppendLine("                        _dbuser.Add(new KeyValuePair<int, string>(ai_DBIndex, luser.Name), luser.ConnectString);");
            sb.AppendLine("                    }");
            sb.AppendLine("");
            sb.AppendLine("                    if (con.State == ConnectionState.Open) con.Close();");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 设置数据库用户及连接字符串于静态变量DbConnection中");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>true/false</returns>");
            sb.AppendLine("        public static bool SetDBUser()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                GetDBUserData(0, false);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch");
            sb.AppendLine("            {");
            sb.AppendLine("                return false;");
            sb.AppendLine("            }");
            sb.AppendLine("            return true;");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 返回Oracle连接");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"as_dbuser\">数据库连接用户名</param>");
            sb.AppendLine("        /// <returns>OracleConnection/null</returns>");
            sb.AppendLine("        #endregion");
            sb.AppendLine("        #region 连接、断开数据库、获取数据库连接");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 不带参数的实例化本类后，需执行本函数成功后，才能执行SetReader和SetDataSet");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
            sb.AppendLine("        /// <returns>true成功，false异常</returns>");
            sb.AppendLine("        public void Connect(String vUser)");
            sb.AppendLine("        {");
            sb.AppendLine("            Connect(0, vUser);");
            sb.AppendLine("        }");
            sb.AppendLine("        public void Connect(int vDBIndex, string vUser)");
            sb.AppendLine("        {");
            sb.AppendLine("            iConnection = CDataBase.GetConnection(vDBIndex, vUser);");
            sb.AppendLine("            iConnection.Open();");
            sb.AppendLine("            iCommand.Connection = iConnection;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 断开iConnecton的连接");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        /// ");
            sb.AppendLine("        [System.Diagnostics.DebuggerNonUserCodeAttribute()]");
            sb.AppendLine("        public void DisConnect()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (iTrans != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (iTrans.Connection != null)");
            sb.AppendLine("                    iTrans.Rollback();");
            sb.AppendLine("            }");
            sb.AppendLine("            if (iConnection != null) iConnection.Close();");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("            _SqlCode = 0;");
            sb.AppendLine("            _SqlNRows = 0;");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 默认连接第一个配置");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"as_dbuser\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public static OracleConnection GetConnection(string as_dbuser)");
            sb.AppendLine("        {");
            sb.AppendLine("            return GetConnection(0, as_dbuser);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 连接指定配置的数据库");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"ai_DBIndex\"></param>");
            sb.AppendLine("        /// <param name=\"as_dbuser\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public static OracleConnection GetConnection(int ai_DBIndex, string as_dbuser)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (GetDBUserCount(ai_DBIndex) <= 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                GetDBUserData(ai_DBIndex, false);");
            sb.AppendLine("            }");
            sb.AppendLine("            KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? \"\" : as_dbuser.ToLower());");
            sb.AppendLine("            if (_dbuser.ContainsKey(ls_keyvalue))");
            sb.AppendLine("            {");
            sb.AppendLine("                OracleConnection con = new OracleConnection(_dbuser[ls_keyvalue]);");
            sb.AppendLine("                return con;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new CustomException(CustomExceptionType.Serious, \"你使用的数据库用户\" + as_dbuser + \"不存在\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public static KeyValuePair<KeyValuePair<int, string>, string> GetDBUser(int ai_DBIndex, string as_dbuser)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (GetDBUserCount(ai_DBIndex) <= 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                GetDBUserData(ai_DBIndex, false);");
            sb.AppendLine("            }");
            sb.AppendLine("            KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? \"\" : as_dbuser.ToLower());");
            sb.AppendLine("            if (_dbuser.ContainsKey(ls_keyvalue))");
            sb.AppendLine("                return new KeyValuePair<KeyValuePair<int, string>, string>(ls_keyvalue, _dbuser[ls_keyvalue]);");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new CustomException(CustomExceptionType.Serious, \"你使用的数据库用户\" + as_dbuser + \"不存在\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 返回DataTable或DataReader");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 生成OracleDataReader类型的iReader");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vSelectSql\">要执行的sql语句</param>");
            sb.AppendLine("        /// <returns>OracleDataReader/null</returns>");
            sb.AppendLine("");
            sb.AppendLine("        public OracleDataReader SetReader(String vSelectSql)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandText = vSelectSql;");
            sb.AppendLine("                _iReader = iCommand.ExecuteReader();");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                _SqlNRows = -1; //不确定几条记录");
            sb.AppendLine("                return _iReader;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return SetReader(vSelectSql);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        public DataTable SetDataTable(string vSql)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandText = vSql;");
            sb.AppendLine("                if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
            sb.AppendLine("                _iAdapter.SelectCommand = iCommand;");
            sb.AppendLine("                DataTable ldt = new DataTable();");
            sb.AppendLine("                _SqlNRows = _iAdapter.Fill(ldt);");
            sb.AppendLine("                _iDataTable = ldt;");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                return _iDataTable;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return SetDataTable(vSql);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("       ");
            sb.AppendLine("        }");
            sb.AppendLine("        public DataTable SetDataTable(string vSql, bool ForUpdate)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandText = vSql;");
            sb.AppendLine("                if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
            sb.AppendLine("                if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();");
            sb.AppendLine("                _iAdapter.SelectCommand = iCommand;");
            sb.AppendLine("                DataTable ldt = new DataTable();");
            sb.AppendLine("                _SqlNRows = _iAdapter.Fill(ldt);");
            sb.AppendLine("                _iDataTable = ldt;");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                return _iDataTable;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return SetDataTable(vSql, ForUpdate);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        ");
            sb.AppendLine("        }");
            sb.AppendLine("        public DataTable SetDataTable(string vSql, int startRecord, int maxRecords)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandText = vSql;");
            sb.AppendLine("                if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
            sb.AppendLine("                _iAdapter.SelectCommand = iCommand;");
            sb.AppendLine("                DataTable ldt = new DataTable();");
            sb.AppendLine("                _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);");
            sb.AppendLine("                _iDataTable = ldt;");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                return _iDataTable;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return SetDataTable( vSql,  startRecord,  maxRecords);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        ");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public DataTable SetDataTable(string vSql, int startRecord, int maxRecords, bool ForUpdate)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandText = vSql;");
            sb.AppendLine("                if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
            sb.AppendLine("                if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();");
            sb.AppendLine("                _iAdapter.SelectCommand = iCommand;");
            sb.AppendLine("                DataTable ldt = new DataTable();");
            sb.AppendLine("                _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);");
            sb.AppendLine("                _iDataTable = ldt;");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                return _iDataTable;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return SetDataTable( vSql,  startRecord,  maxRecords,  ForUpdate);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("        ");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 自动把iDataTable中改动，插入的数据同步到数据库");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>同步的记录数</returns>");
            sb.AppendLine("        public int UpdateDataTable()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (_iDataTable == null || _DataTableSelectCommand == null) return 0;");
            sb.AppendLine("            return UpdateDataTable(_iDataTable);");
            sb.AppendLine("        }");
            sb.AppendLine("        public int UpdateDataTable(DataTable aDataTable)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (_iDataTable == null || _DataTableSelectCommand == null) return 0;");
            sb.AppendLine("            _iAdapter.SelectCommand = _DataTableSelectCommand;");
            sb.AppendLine("            OracleCommandBuilder builder = new OracleCommandBuilder(_iAdapter);");
            sb.AppendLine("            return _iAdapter.Update(aDataTable);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 执行sql语句或存储过程");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 执行sql语句");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vSQL\">SQL语句,</param>");
            sb.AppendLine("        /// <returns>select语句返回第一行第一例的值，其他返回null</returns>");
            sb.AppendLine("        public object ExeSQL(string vSQL)");
            sb.AppendLine("        {");
            sb.AppendLine("            string ls_sql;");
            sb.AppendLine("            object lo_obj = null;");
            sb.AppendLine("            ls_sql = vSQL.Trim();");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                iCommand.CommandType = CommandType.Text;");
            sb.AppendLine("                switch (ls_sql.Substring(0, 6).ToUpper())");
            sb.AppendLine("                {");
            sb.AppendLine("                    case \"SELECT\":");
            sb.AppendLine("                        iCommand.CommandText = ls_sql;");
            sb.AppendLine("                        lo_obj = iCommand.ExecuteScalar();");
            sb.AppendLine("                        if (lo_obj == null)");
            sb.AppendLine("                        {");
            sb.AppendLine("                            _SqlCode = 0;");
            sb.AppendLine("                            _SqlNRows = 0;");
            sb.AppendLine("                        }");
            sb.AppendLine("                        else");
            sb.AppendLine("                        {");
            sb.AppendLine("                            if (lo_obj == DBNull.Value) lo_obj = null;");
            sb.AppendLine("                            _SqlCode = 0;");
            sb.AppendLine("                            _SqlNRows = 1;");
            sb.AppendLine("                        }");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"UPDATE\":");
            sb.AppendLine("                        if (iTrans == null)");
            sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        else");
            sb.AppendLine("                        {");
            sb.AppendLine("                            if (iTrans.Connection == null)");
            sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        }");
            sb.AppendLine("                        iCommand.CommandText = vSQL;");
            sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
            sb.AppendLine("                        _SqlCode = 0;");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"INSERT\":");
            sb.AppendLine("                        if (iTrans == null)");
            sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        else");
            sb.AppendLine("                        {");
            sb.AppendLine("                            if (iTrans.Connection == null)");
            sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        }");
            sb.AppendLine("                        iCommand.CommandText = vSQL;");
            sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
            sb.AppendLine("                        _SqlCode = 0;");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"DELETE\":");
            sb.AppendLine("                        if (iTrans == null)");
            sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        else");
            sb.AppendLine("                        {");
            sb.AppendLine("                            if (iTrans.Connection == null)");
            sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                        }");
            sb.AppendLine("                        iCommand.CommandText = vSQL;");
            sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
            sb.AppendLine("                        _SqlCode = 0;");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    default:");
            sb.AppendLine("                        iCommand.CommandText = vSQL;");
            sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
            sb.AppendLine("                        _SqlCode = 0;");
            sb.AppendLine("                        break;");
            sb.AppendLine("                }");
            sb.AppendLine("                return lo_obj;");
            sb.AppendLine("");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        return ExeSQL( vSQL);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = -1;");
            sb.AppendLine("                _SqlNRows = 0;");
            sb.AppendLine("                _SqlErrorText = e.Message;");
            sb.AppendLine("                throw e;");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        public void ExecProcedure(string vProcedureName)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                if (iTrans == null)");
            sb.AppendLine("                    iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (iTrans.Connection == null)");
            sb.AppendLine("                        iTrans = iConnection.BeginTransaction();");
            sb.AppendLine("                }");
            sb.AppendLine("                iCommand.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("                iCommand.CommandText = vProcedureName;");
            sb.AppendLine("                _SqlNRows = iCommand.ExecuteNonQuery();");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("            }");
            sb.AppendLine("            //catch (Oracle.DataAccess.Client.OracleException oracleException)");
            sb.AppendLine("            //{");
            sb.AppendLine("            //    if (oracleException.Number == 3113)");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        ExecProcedure(vProcedureName);");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //    else");
            sb.AppendLine("            //    {");
            sb.AppendLine("            //        throw oracleException;");
            sb.AppendLine("            //    }");
            sb.AppendLine("            //}");
            sb.AppendLine("            catch (Exception e)");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = -1;");
            sb.AppendLine("                _SqlNRows = 0;");
            sb.AppendLine("                _SqlErrorText = e.Message;");
            sb.AppendLine("                throw e;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        #endregion");
            sb.AppendLine("        #region 事务处理");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 提交事务");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>返回true成功；返回false失败</returns>");
            sb.AppendLine("        public void Commit()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (iTrans != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (iTrans.Connection != null)");
            sb.AppendLine("                {");
            sb.AppendLine("                    iTrans.Commit();");
            sb.AppendLine("                    _SqlCode = 0;");
            sb.AppendLine("                    _SqlNRows = -1;");
            sb.AppendLine("");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            else//select 结束事物提交");
            sb.AppendLine("            {");
            sb.AppendLine("                if (iConnection != null && iConnection.State == ConnectionState.Open)");
            sb.AppendLine("                {");
            sb.AppendLine("                    ExeSQL(\"commit\");");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 回滚事务");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>返回true成功；返回false失败</returns>");
            sb.AppendLine("        public void Rollback()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (iTrans != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (iTrans.Connection != null)");
            sb.AppendLine("                {");
            sb.AppendLine("                    iTrans.Rollback();");
            sb.AppendLine("                    _SqlCode = 0;");
            sb.AppendLine("                    _SqlNRows = -1;");
            sb.AppendLine("");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("        #region 数据连接后的特殊服务，如获取时间、拼音五笔和序列值");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取数据库时间，失败则以应用服务器的时间代替");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public DateTime GetDBDateTime()");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                return (DateTime)ExeSQL(\"select sysdate from dual\");");
            sb.AppendLine("            }");
            sb.AppendLine("            catch");
            sb.AppendLine("            {");
            sb.AppendLine("                return DateTime.Now;");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取拼音五笔");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"yourstring\"></param>");
            sb.AppendLine("        /// <param name=\"strpy\"></param>");
            sb.AppendLine("        /// <param name=\"strwb\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public void f_GetPyWb(string yourstring, out string strpy, out string strwb)");
            sb.AppendLine("        {");
            sb.AppendLine("            strpy = string.Empty;");
            sb.AppendLine("            strwb = string.Empty;");
            sb.AppendLine("            if (string.IsNullOrEmpty(yourstring))");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            string strchar = string.Empty;");
            sb.AppendLine("            for (int i = 0; i < yourstring.Length; i++)");
            sb.AppendLine("            {");
            sb.AppendLine("");
            sb.AppendLine("                strchar = yourstring.Substring(i, 1);");
            sb.AppendLine("                SetReader(\"SELECT py,wb FROM xtgl_pywb WHERE xtgl_pywb.zf = '\" + strchar + \"'\");");
            sb.AppendLine("                if (_iReader.HasRows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    _iReader.Read();");
            sb.AppendLine("                    strpy = String.Concat(strpy, _iReader[\"py\"].ToString());");
            sb.AppendLine("                    strwb = String.Concat(strwb, _iReader[\"wb\"].ToString());");
            sb.AppendLine("                }");
            sb.AppendLine("                _iReader.Close();");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 获取指定序列的NextValue");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"vSequenceName\">序列名</param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public Int64 GetNextValue(string vSequenceName)");
            sb.AppendLine("        {");
            sb.AppendLine("            iCommand.CommandText = \"select \" + vSequenceName.Trim() + \".nextval from dual\";");
            sb.AppendLine("            object lo_obj = iCommand.ExecuteScalar();");
            sb.AppendLine("            if (lo_obj == null)");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                _SqlNRows = 0;");
            sb.AppendLine("                return -1;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                _SqlNRows = 1;");
            sb.AppendLine("                return Convert.ToInt64(lo_obj);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"as_tablename\"></param>");
            sb.AppendLine("        /// <param name=\"as_colname\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public long GetNextValue(string as_tablename, string as_colname)");
            sb.AppendLine("        {");
            sb.AppendLine("            iCommand.CommandText = string.Format(\"select max({0}) from {1}\", as_tablename, as_colname);");
            sb.AppendLine("            object lo_obj = iCommand.ExecuteScalar();");
            sb.AppendLine("            if (lo_obj == null || lo_obj == DBNull.Value)");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                _SqlNRows = 1;");
            sb.AppendLine("                return 1;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                _SqlCode = 0;");
            sb.AppendLine("                _SqlNRows = 1;");
            sb.AppendLine("                return (Convert.ToInt64(lo_obj) + 1);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 静态函数 一个事务多条Sql语句");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 事务操作(不能用于Blob类型)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sql\">sql语句(不加;)字符串数组(定长)</param>");
            sb.AppendLine("        /// <returns>true/false</returns>");
            sb.AppendLine("        public static bool TransOperate(string[] as_sql, string as_dbuser)");
            sb.AppendLine("        {");
            sb.AppendLine("            int li_cnt = as_sql.Length;");
            sb.AppendLine("            if (li_cnt <= 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                return false;");
            sb.AppendLine("            }");
            sb.AppendLine("            OracleConnection con = GetConnection(as_dbuser);");
            sb.AppendLine("            con.Open();");
            sb.AppendLine("            OracleTransaction trans = con.BeginTransaction();");
            sb.AppendLine("            OracleCommand cmd = new OracleCommand();");
            sb.AppendLine("            cmd.Connection = con;");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                for (int i = 0; i < li_cnt; i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (as_sql[i] == \"\" || as_sql[i] == null) continue;");
            sb.AppendLine("                    cmd.CommandText = as_sql[i];");
            sb.AppendLine("                    cmd.ExecuteNonQuery();");
            sb.AppendLine("                }");
            sb.AppendLine("                trans.Commit();");
            sb.AppendLine("                return true;");
            sb.AppendLine("            }");
            sb.AppendLine("            catch");
            sb.AppendLine("            {");
            sb.AppendLine("                trans.Rollback();");
            sb.AppendLine("                return false;");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            {");
            sb.AppendLine("                con.Close();");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        internal void Connect()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        internal OracleDataReader SetReader()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        internal void Equals()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        internal void ExeSQL()");
            sb.AppendLine("        {");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        internal class ml_dbuser");
            sb.AppendLine("        {");
            sb.AppendLine("            private int _dbindex;");
            sb.AppendLine("            private string _dbalias;");
            sb.AppendLine("            private string _name;");
            sb.AppendLine("            private string _alias;");
            sb.AppendLine("            private string _password;");
            sb.AppendLine("            private string _constr;");
            sb.AppendLine("            //属于web.config中配置的第几个数据库");
            sb.AppendLine("            public int DBIndex");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _dbindex; }");
            sb.AppendLine("                set { _dbindex = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("            //系统内使用数据库名");
            sb.AppendLine("            public string DataBaseServerName");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _dbalias; }");
            sb.AppendLine("                set { _dbalias = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("            //系统内使用DB用户名");
            sb.AppendLine("            public string Name");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _name; }");
            sb.AppendLine("                set { _name = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("            //实际环境中数据库对应的DB用户名");
            sb.AppendLine("            public string Alias");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _alias; }");
            sb.AppendLine("                set { _alias = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("            //DB用户的密码");
            sb.AppendLine("            public string Password");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _password; }");
            sb.AppendLine("                set { _password = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("            //已经配置就绪的连接串");
            sb.AppendLine("            public string ConnectString");
            sb.AppendLine("            {");
            sb.AppendLine("                get { return _constr; }");
            sb.AppendLine("                set { _constr = value; }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("    #endregion");
            return sb.ToString();
        }

        //public static string GetDB() {

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("    #region 数据库访问");

        //    sb.AppendLine("    using Oracle.DataAccess.Client;");
        //    sb.AppendLine("    using System;");
        //    sb.AppendLine("    using System.Collections.Generic;");
        //    sb.AppendLine("    using System.Collections.Specialized;");
        //    sb.AppendLine("    using System.ComponentModel;");
        //    sb.AppendLine("    using System.Configuration;");
        //    sb.AppendLine("    using System.Data;");
        //    sb.AppendLine("    using System.Linq;");
        //    sb.AppendLine("    using System.Text;");
        //    sb.AppendLine("    using System.Threading.Tasks;");
        //    sb.AppendLine("    internal class VariableInfo");
        //    sb.AppendLine("    {");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 应用程序级变量(配置文件和Application中变量的集合)");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public class ApplicationVar");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            private static string _applname;");
        //    sb.AppendLine("            private static string _appldm;");
        //    sb.AppendLine("            private static string _znqxglmkdm;//组内权限管理模块代码");
        //    sb.AppendLine("            private static string _dwdm;");
        //    sb.AppendLine("            private static string _dwmc;");
        //    sb.AppendLine("            private static string _ywdwmc;  //英文单位名称");
        //    sb.AppendLine("            private static string _servicephone;  //服务电话");
        //    sb.AppendLine("            private static string _HaveGlobalAccessControl;");
        //    sb.AppendLine("            private static long _ApplTotalLoginUserCount;");
        //    sb.AppendLine("            private static long _OnLineUserCount;");
        //    sb.AppendLine("            private static string _sbyxbs;");
        //    sb.AppendLine("            private static string _sbyljgdm;//社保医疗机构代码");
        //    sb.AppendLine("            private static string _nbyljgdm;//农保医疗机构代码");
        //    sb.AppendLine("            private static string _nbqzjdz;//农保前置机网络地址：IP+端口号");
        //    sb.AppendLine("            private static int? _xtggid;//系统公告信息ID号");
        //    sb.AppendLine("            private static string _oaxxlb;//oa系统短信的消息类别");
        //    sb.AppendLine("            private static System.Object _LockObj1 = new object();");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 应用程序名称");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string ApplName");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_applname))");
        //    sb.AppendLine("                        _applname = System.Configuration.ConfigurationManager.AppSettings[\"applname\"];");
        //    sb.AppendLine("                    return _applname;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _applname = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// oa系统短信的消息类别");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string OAXXLB");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_oaxxlb))");
        //    sb.AppendLine("                        _oaxxlb = System.Configuration.ConfigurationManager.AppSettings[\"oaxxlb\"];");
        //    sb.AppendLine("                    return _oaxxlb;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _oaxxlb = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 应用程序代码");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string ApplDm");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_appldm))");
        //    sb.AppendLine("                        _appldm = System.Configuration.ConfigurationManager.AppSettings[\"appldm\"];");
        //    sb.AppendLine("                    return _appldm;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _appldm = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 组内权限管理模块代码");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string ZNQXGLMKDM");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_znqxglmkdm))");
        //    sb.AppendLine("                        _znqxglmkdm = System.Configuration.ConfigurationManager.AppSettings[\"znqxglmkdm\"];");
        //    sb.AppendLine("                    return _znqxglmkdm;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _znqxglmkdm = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 系统公告ID");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static int? XTGGID");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (!_xtggid.HasValue)");
        //    sb.AppendLine("                        _xtggid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[\"xtggid\"]);");
        //    sb.AppendLine("                    return _xtggid;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _xtggid = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 当前登录用户人数（即当前在线人数）");
        //    sb.AppendLine("            /// *注意* 使用 OnLineUserCount++会导致ApplTotalLoginUserCount自动加一");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static long OnLineUserCount");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    lock (_LockObj1)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        if (_OnLineUserCount < 0)");
        //    sb.AppendLine("                            _OnLineUserCount = 0;");
        //    sb.AppendLine("                        return _OnLineUserCount;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    lock (_LockObj1)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        if (_OnLineUserCount == value - 1)");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            _ApplTotalLoginUserCount++;");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        _OnLineUserCount = value;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 单位代码");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string dwdm");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_dwdm))");
        //    sb.AppendLine("                        _dwdm = System.Configuration.ConfigurationManager.AppSettings[\"dwdm\"];");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_dwdm)) _dwdm = \"01\";");
        //    sb.AppendLine("                    return _dwdm;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _dwdm = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 单位名称");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string dwmc");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_dwmc))");
        //    sb.AppendLine("                        _dwmc = System.Configuration.ConfigurationManager.AppSettings[\"dwmc\"];");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_dwmc)) _dwmc = \"温州医院\";");
        //    sb.AppendLine("                    return _dwmc;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _dwmc = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 英文单位名称");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string ywdwmc");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_ywdwmc))");
        //    sb.AppendLine("                        _ywdwmc = System.Configuration.ConfigurationManager.AppSettings[\"ywdwmc\"];");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_ywdwmc)) _ywdwmc = \"WenZhou Hospital\";");
        //    sb.AppendLine("                    return _ywdwmc;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _ywdwmc = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 服务电话(错误页中用到)");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string servicephone");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_servicephone))");
        //    sb.AppendLine("                        _servicephone = System.Configuration.ConfigurationManager.AppSettings[\"servicephone\"];");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_servicephone)) _servicephone = \"没有登记服务电话\";");
        //    sb.AppendLine("                    return _servicephone;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _servicephone = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 全局页面访问控制模式");
        //    sb.AppendLine("            /// \"0\" 不控制");
        //    sb.AppendLine("            /// \"1\" 已经登记的页面按权限访问，没有登记则不控制访问");
        //    sb.AppendLine("            /// \"2\" 已经登记的页面按权限访问，没有登记则禁止访问");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string GlobalAccessControl");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_HaveGlobalAccessControl))");
        //    sb.AppendLine("                        _HaveGlobalAccessControl = System.Configuration.ConfigurationManager.AppSettings[\"GlobalAccessControl\"];");
        //    sb.AppendLine("                    return _HaveGlobalAccessControl;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                set");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _HaveGlobalAccessControl = value;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 农保医疗机构代码");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string NBYLJGDM");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_nbyljgdm))");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        lock (_LockObj1)");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("");
        //    sb.AppendLine("                            _nbyljgdm = \"1001\";");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    return _nbyljgdm;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            /// <summary>");
        //    sb.AppendLine("            /// 农保前置机IP地址及端口号");
        //    sb.AppendLine("            /// </summary>");
        //    sb.AppendLine("            public static string NBQZJDZ");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (string.IsNullOrEmpty(_nbqzjdz))");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        lock (_LockObj1)");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("");
        //    sb.AppendLine("                            _nbqzjdz = \"172.16.12.92:9999\";");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    return _nbqzjdz;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("    }");
        //    sb.AppendLine("    /// <summary>");
        //    sb.AppendLine("    /// 自定义异常类");
        //    sb.AppendLine("    /// </summary>");
        //    sb.AppendLine("    internal class CustomException : ApplicationException");
        //    sb.AppendLine("    {");
        //    sb.AppendLine("        private string _ipAddress;  //客户端ip地址");
        //    sb.AppendLine("        private string _czz;        //操作者");
        //    sb.AppendLine("        private Int64 _idczz;       //操作者ID    ");
        //    sb.AppendLine("        private string _url;        //出错页面");
        //    sb.AppendLine("        private string _userAgent;  //客户段浏览器代理信息");
        //    sb.AppendLine("        private CustomExceptionType _exceptionType;");
        //    sb.AppendLine("        private bool _loged = false;");
        //    sb.AppendLine("        private string _hostname;");
        //    sb.AppendLine("        protected void Init()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("                _exceptionType = CustomExceptionType.UnKnowException;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch (Exception ex)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                System.Diagnostics.Debug.Write(ex.Message);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 构造函数");
        //    sb.AppendLine("        public CustomException(CustomExceptionType exceptionType, string message, Exception innerException)");
        //    sb.AppendLine("            : base(message, innerException)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Init();");
        //    sb.AppendLine("            _exceptionType = exceptionType;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public CustomException(string message, Exception innerException)");
        //    sb.AppendLine("            : base(message, innerException)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Init();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public CustomException(CustomExceptionType exceptionType, string message)");
        //    sb.AppendLine("            : base(message)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Init();");
        //    sb.AppendLine("            _exceptionType = exceptionType;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public CustomException(string message)");
        //    sb.AppendLine("            : base(message)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Init();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 属性");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取包括InnerException的所有异常信息");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public virtual string MessageAll");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                string ls_msg = base.Message;");
        //    sb.AppendLine("");
        //    sb.AppendLine("                if (InnerException != null)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    CustomException blex = InnerException as CustomException;");
        //    sb.AppendLine("                    if (blex != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        if (string.IsNullOrEmpty(ls_msg))");
        //    sb.AppendLine("                            ls_msg = blex.MessageAll;");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                            ls_msg = ls_msg + \",\" + blex.MessageAll;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    else");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        if (string.IsNullOrEmpty(ls_msg))");
        //    sb.AppendLine("                            ls_msg = InnerException.Message;");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                            ls_msg = ls_msg + \",错误原因：\" + InnerException.Message;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                return ls_msg;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 客户端IP地址");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public string IPAddress");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _ipAddress;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 操作者");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public string Czz");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _czz;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 操作者ID");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public Int64 IDCzz");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _idczz;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 出错页面");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public string URL");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _url;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 客户段浏览器代理信息");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public string UserAgent");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _userAgent;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public string HostName");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _hostname;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public string YYDM");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return VariableInfo.ApplicationVar.ApplDm;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 异常类型");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public CustomExceptionType ExceptionType");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _exceptionType;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("    }");
        //    sb.AppendLine("    /// <summary>");
        //    sb.AppendLine("    /// 异常类型");
        //    sb.AppendLine("    /// </summary>");
        //    sb.AppendLine("    internal enum CustomExceptionType");
        //    sb.AppendLine("    {");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        //------------101-200为一般等级的异常类型--------//");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 验证异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Validate = 101,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        //----------------------------------------------//");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        //------------201-300为严重等级的异常类型--------//");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 严重的异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Serious = 201,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 数据库访问异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        DataAccess = 202,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取数据库数据异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Select = 203,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 插入数据库数据异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Insert = 204,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 更新数据库数据异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Update = 205,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 删除数据库数据异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        Delete = 206,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 更新并发异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        UpdateConcurrency = 207,");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 删除并发异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        DeleteConcurrency = 208,");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        //------------------------------------");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 未知异常");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        UnKnowException = 999");
        //    sb.AppendLine("");
        //    sb.AppendLine("    }");
        //    sb.AppendLine("    internal partial class CDataBase : IDisposable");
        //    sb.AppendLine("    {");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public void ParametersClear()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            this.Parameters.Clear();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public void ParametersAdd(string key, object value)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            this.Parameters.Add(key, value);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public IList<T> GetDataItems<T>(string sql) where T : class, new()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("");
        //    sb.AppendLine("            //object tempType = null;");
        //    sb.AppendLine("            //string isNull = \"isNull\";");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                this.iCommand.CommandText = sql;");
        //    sb.AppendLine("                this._iReader = this.iCommand.ExecuteReader();");
        //    sb.AppendLine("                if (!this._iReader.HasRows)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    this._iReader.Close();");
        //    sb.AppendLine("                    return new List<T>();");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                Type typeFromHandle = typeof(T);");
        //    sb.AppendLine("                var inner =");
        //    sb.AppendLine("                    from i in Enumerable.Range(1, this._iReader.FieldCount)");
        //    sb.AppendLine("                    select new");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        Name = this._iReader.GetName(i - 1),");
        //    sb.AppendLine("                        Index = i - 1");
        //    sb.AppendLine("                    };");
        //    sb.AppendLine("                var enumerable = typeFromHandle.GetProperties().Join(inner, x => x.Name, x => x.Name, (x, y) => new { y.Index, x });");
        //    sb.AppendLine("                List<T> list = new List<T>();");
        //    sb.AppendLine("                while (this._iReader.Read())");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    T t = Activator.CreateInstance<T>();");
        //    sb.AppendLine("                    foreach (var current in enumerable)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        //tempType = current;");
        //    sb.AppendLine("                        //isNull = \"isNull\";");
        //    sb.AppendLine("                        //isNull = this._iReader[current.Index].ToString();");
        //    sb.AppendLine("");
        //    sb.AppendLine("                        if (this._iReader[current.Index].GetType() != typeof(DBNull))");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            try");
        //    sb.AppendLine("                            {");
        //    sb.AppendLine("                                if (current.x.PropertyType.IsGenericType && current.x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))");
        //    sb.AppendLine("                                {");
        //    sb.AppendLine("                                    current.x.SetValue(t, new NullableConverter(current.x.PropertyType).ConvertFromString(this._iReader[current.Index].ToString()), null);");
        //    sb.AppendLine("                                }");
        //    sb.AppendLine("                                else");
        //    sb.AppendLine("                                    current.x.SetValue(t, Convert.ChangeType(this._iReader[current.Index], current.x.PropertyType), null);");
        //    sb.AppendLine("");
        //    sb.AppendLine("                            }");
        //    sb.AppendLine("                            catch (Exception exe)");
        //    sb.AppendLine("                            {");
        //    sb.AppendLine("                                throw exe;");
        //    sb.AppendLine("                                //Lenovo.Tool.Log4NetHelper.Error(exe);");
        //    sb.AppendLine("                            }");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    list.Add(t);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                this._iReader.Close();");
        //    sb.AppendLine("                return list;");
        //    sb.AppendLine("");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch (Exception ex)");
        //    sb.AppendLine("            {");

        //    sb.AppendLine("                throw ex;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 类成员定义");
        //    sb.AppendLine("        //实例化后成员：Oracle连接");
        //    sb.AppendLine("        private OracleConnection iConnection;    //Connect执行成功后：Oracle连接");
        //    sb.AppendLine("        private OracleCommand iCommand;          //实例化后成员：Oracle命令");
        //    sb.AppendLine("        private OracleCommand _DataTableSelectCommand;//SetDataTable后的可用成员：Oracle命令");
        //    sb.AppendLine("        private OracleDataAdapter _iAdapter;      //SetDateSet：OracleAdapter");
        //    sb.AppendLine("        private OracleDataReader _iReader;        //SetReader执行成功后：OracleReader");
        //    sb.AppendLine("        private DataTable _iDataTable;");
        //    sb.AppendLine("        private int _SqlNRows = -1;                 //ExeSQL执行后影响到的行数 -1表示未执行sql语句或不确定几条记录");
        //    sb.AppendLine("        private int _SqlCode = -1;                 //ExeSQL执行成功还是失败，－1失败 0成功");
        //    sb.AppendLine("        public string _SqlErrorText;");
        //    sb.AppendLine("");
        //    sb.AppendLine("        private OracleTransaction iTrans;       //Connect执行成功后：事务处理对象  bm zsm mm constr");
        //    sb.AppendLine("        //private static Dictionary<string, string> DbConnection = new Dictionary<string, string>();");
        //    sb.AppendLine("        //private static Dictionary<string, string> DbConnStr = new Dictionary<string, string>();");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 数据库用户集合，《 <数据库号，用户名>,连接串》");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        private static Dictionary<KeyValuePair<int, string>, string> _dbuser = new Dictionary<KeyValuePair<int, string>, string>();");
        //    sb.AppendLine("        private bool disposed = false;");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("        #region 公有属性");
        //    sb.AppendLine("        public OracleDataAdapter iAdapter");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _iAdapter;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public OracleDataReader iReader");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _iReader;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public DataTable iDataTable");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _iDataTable;//db.iDataTable[0][0].;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public int SqlNRows");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _SqlNRows;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public int SqlCode");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _SqlCode;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public string SqlErrorText");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return _SqlErrorText;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// 只读属性 OracleParameterCollection");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public OracleParameterCollection Parameters");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            get");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return iCommand.Parameters;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 返回datatable");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("        #region 构造函数和析构函数及资源的释放管理");
        //    sb.AppendLine("        //.............开始实例化后的方法定义.....................");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet三个成员");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public CDataBase()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand = new OracleCommand();");
        //    sb.AppendLine("            iCommand.BindByName = true;");
        //    sb.AppendLine("            Connect(0, ConfigurationManager.AppSettings[\"DefaultUser\"]);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
        //    sb.AppendLine("        public CDataBase(string vUser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand = new OracleCommand();");
        //    sb.AppendLine("            iCommand.BindByName = true;");
        //    sb.AppendLine("            Connect(0, vUser);");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
        //    sb.AppendLine("        public CDataBase(int ai_DBIndex, string vUser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand = new OracleCommand();");
        //    sb.AppendLine("            iCommand.BindByName = true;");
        //    sb.AppendLine("            Connect(ai_DBIndex, vUser);");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 释放托管与非托管资源");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"disposing\"></param>");
        //    sb.AppendLine("        [System.Diagnostics.DebuggerNonUserCodeAttribute()]");
        //    sb.AppendLine("        protected virtual void Dispose(bool disposing)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (!this.disposed)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                //释放非托管资源");
        //    sb.AppendLine("                DisConnect();");
        //    sb.AppendLine("");
        //    sb.AppendLine("                //释放托管资源");
        //    sb.AppendLine("                if (disposing)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    iConnection.Dispose();");
        //    sb.AppendLine("                    iConnection = null;");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (iTrans != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        iTrans.Dispose();");
        //    sb.AppendLine("                        iTrans = null;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (_iAdapter != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        _iAdapter.Dispose();");
        //    sb.AppendLine("                        _iAdapter = null;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (_iReader != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        _iReader.Dispose();");
        //    sb.AppendLine("                        _iReader = null;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (iCommand != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        iCommand.Dispose();");
        //    sb.AppendLine("                        iCommand = null;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (_iDataTable != null)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        _iDataTable.Dispose();");
        //    sb.AppendLine("                        _iDataTable = null;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            disposed = true;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public void Dispose()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Dispose(true);");
        //    sb.AppendLine("            GC.SuppressFinalize(this);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        ~CDataBase()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Dispose(false);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 服务器初始化用");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取指定数据库的DBUser个数");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        private static int GetDBUserCount(int ai_DBIndex)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            int count = 0;");
        //    sb.AppendLine("            foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (ls_keyvalue.Key.Key == ai_DBIndex)");
        //    sb.AppendLine("                    count++;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            return count;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 删除指定数据库的所有DBUser");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
        //    sb.AppendLine("        private static void RemoveDBUser(int ai_DBIndex)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (ls_keyvalue.Key.Key == ai_DBIndex)");
        //    sb.AppendLine("                    _dbuser.Remove(ls_keyvalue.Key);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        private static string GenConnectString(string as_ds, string as_dbuser, string as_password)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            string ls_constr;");
        //    sb.AppendLine("            ls_constr = \"Data Source=\" + as_ds + \";User ID=\" + as_dbuser + \";Password=\" + as_password +");
        //    sb.AppendLine("                        \";Pooling=false\" +             //true，则请求从连接池返回，没连接池则自动创建,默认值为true");
        //    sb.AppendLine("                \";Enlist=true\";           　　//");
        //    sb.AppendLine("            return \"Data Source=\" + as_ds + \";User ID=\" + as_dbuser + \";Password=\" + as_password + \";Pooling=true; Persist Security Info=True;\";");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 将字符转换为ＡＳＣ码");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"asciiCode\">字符</param>");
        //    sb.AppendLine("        /// <returns>对应的ＡＳＣ码</returns>");
        //    sb.AppendLine("        private static int Asc(string character)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (character.Length == 1)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                byte[] bytes = System.Text.Encoding.Default.GetBytes(character);");
        //    sb.AppendLine("                int intAsciiCode = (int)bytes[0];");
        //    sb.AppendLine("                return (intAsciiCode);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                throw new Exception(\"字符的长度不对\");");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 返回字符串的长度（包括汉字），汉字长度为2");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
        //    sb.AppendLine("        /// <returns>字符串</returns>");
        //    sb.AppendLine("        private static int f_length(string yourstring)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return 0;");
        //    sb.AppendLine("            int len = yourstring.Length;");
        //    sb.AppendLine("            byte[] sarr = System.Text.Encoding.Default.GetBytes(yourstring);");
        //    sb.AppendLine("            return sarr.Length;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 从左边开始取len长个几个字符串");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
        //    sb.AppendLine("        /// <param name=\"len\">指定长度</param>");
        //    sb.AppendLine("        /// <returns>字符串</returns>");
        //    sb.AppendLine("        private static string f_left(string yourstring, int ai_len)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (ai_len <= 0) return string.Empty;");
        //    sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return string.Empty;");
        //    sb.AppendLine("            int length = f_length(yourstring);");
        //    sb.AppendLine("            if (length <= ai_len)");
        //    sb.AppendLine("                return yourstring;");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                int tmp = 0;");
        //    sb.AppendLine("                int len = 0;");
        //    sb.AppendLine("                int okLen = 0;");
        //    sb.AppendLine("                int li_asc;");
        //    sb.AppendLine("                string ls_return = string.Empty;");
        //    sb.AppendLine("                for (int i = 0; i < length; i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    //获取asc码");
        //    sb.AppendLine("                    li_asc = Asc(yourstring.Substring(i, 1));");
        //    sb.AppendLine("                    if (li_asc > 127)");
        //    sb.AppendLine("                        tmp += 2;");
        //    sb.AppendLine("                    else");
        //    sb.AppendLine("                        len += 1;");
        //    sb.AppendLine("                    okLen += 1;");
        //    sb.AppendLine("                    if (tmp + len == ai_len)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        ls_return = yourstring.Substring(0, okLen);");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    else if (tmp + len > ai_len)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        ls_return = yourstring.Substring(0, okLen - 1);");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                return ls_return;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 从指定文字开始取len长的字符串");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"yourstring\">源字符串</param>");
        //    sb.AppendLine("        /// <param name=\"start\">开始的位置</param>");
        //    sb.AppendLine("        /// <param name=\"len\">指定长度</param>");
        //    sb.AppendLine("        /// <returns>字符串</returns>");
        //    sb.AppendLine("        public static string f_mid(string yourstring, int start, int len)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (len <= 0 || start < 0) return string.Empty;");
        //    sb.AppendLine("            if (string.IsNullOrEmpty(yourstring)) return string.Empty;");
        //    sb.AppendLine("            if (yourstring.Length < start) return string.Empty;");
        //    sb.AppendLine("            if (yourstring.Length <= start + len - 1)");
        //    sb.AppendLine("                return yourstring.Substring(start - 1);");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("                return yourstring.Substring(start - 1, len);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 按固定数、随机数加密或解密");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"as_pass\"></param>");
        //    sb.AppendLine("        /// <param name=\"ai_mod\">ai_mod = 0 固定数加密,ai_mod = 1 随机数加密,ai_mod = 2 解密</param>");
        //    sb.AppendLine("        /// <returns>加／解密后的字符串</returns>");
        //    sb.AppendLine("        private static string f_passwd2(string as_pass, int ai_mod)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (as_pass.Length > 23)");
        //    sb.AppendLine("                return \"-\";");
        //    sb.AppendLine("            int li_i, li_len, li_pos;");
        //    sb.AppendLine("            string ls_cpu = \"\", ls_tmp = \"\", ls_ret = \"\";");
        //    sb.AppendLine("            string[,] ls_pass = new string[14, 2];");
        //    sb.AppendLine("            if (ai_mod == 0 || ai_mod == 1)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (string.IsNullOrEmpty(as_pass)) return \"\";");
        //    sb.AppendLine("                as_pass = f_left(as_pass, 10);");
        //    sb.AppendLine("                if (ai_mod == 1)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    ls_cpu = DateTime.Now.ToString(\"mmss\");");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                else");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    ls_cpu = f_left(System.Convert.ToString(System.Convert.ToDouble(f_length(as_pass)) / 0.000412), 4);     //不能改变");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                li_len = f_length(as_pass);");
        //    sb.AppendLine("                ls_ret = as_pass + ls_cpu;");
        //    sb.AppendLine("                for (li_i = 1; li_i <= 4; li_i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));");
        //    sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
        //    sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
        //    sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
        //    sb.AppendLine("                    li_pos = (9 - li_pos) % (li_len + 4);");
        //    sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
        //    sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                for (li_i = 1; li_i <= li_len + 4; li_i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (ls_pass[li_i - 1, 1] == \"1\") continue;");
        //    sb.AppendLine("                    ls_tmp = ls_tmp + f_mid(ls_ret, li_i, 1);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                ls_ret = System.Convert.ToString(li_len - 1) + ls_cpu + ls_tmp;");
        //    sb.AppendLine("                return ls_ret;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else if (ai_mod == 2)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (string.IsNullOrEmpty(as_pass)) return \"\";");
        //    sb.AppendLine("                li_len = System.Convert.ToInt32(f_mid(as_pass, 1, 1)) + 1;");
        //    sb.AppendLine("                ls_cpu = f_mid(as_pass, 2, 4);");
        //    sb.AppendLine("                ls_ret = f_mid(as_pass, 6, f_length(as_pass));");
        //    sb.AppendLine("                for (li_i = 1; li_i <= 4; li_i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));");
        //    sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
        //    sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i - 1, 1);");
        //    sb.AppendLine("                    li_pos = (9 - li_pos) % (li_len + 4);");
        //    sb.AppendLine("                    li_pos = li_pos % (li_len + 4);");
        //    sb.AppendLine("                    if (li_pos == 0) li_pos = 1;");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 1] = \"1\";");
        //    sb.AppendLine("                    ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i, 1);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                li_pos = 9;");
        //    sb.AppendLine("                for (li_i = 1; li_i <= li_len; li_i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (ls_pass[li_i - 1, 1] == \"1\")");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        //null ");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    else");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        ls_pass[li_i - 1, 0] = f_mid(ls_ret, li_pos, 1);");
        //    sb.AppendLine("                        li_pos++;");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    ls_tmp = ls_tmp + ls_pass[li_i - 1, 0];");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                return ls_tmp;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return as_pass;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 生成指定数据库的DBUser的配置信息（必须是使用温一医DBUser结构的）");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"ai_DBIndex\">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>");
        //    sb.AppendLine("        /// <param name=\"ab_IsForceUpdated\">是否强制重新获取信息</param>");
        //    sb.AppendLine("        private static void GetDBUserData(int ai_DBIndex, Boolean ab_IsForceUpdated)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            lock (_dbuser)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (GetDBUserCount(ai_DBIndex) > 0 && ab_IsForceUpdated == false) //有数据而且不要求强制更新");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    return;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                else");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    RemoveDBUser(ai_DBIndex);");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                string ls_constr, ls_ds, ls_dbuser, ls_pwd;");
        //    sb.AppendLine("                NameValueCollection app = System.Configuration.ConfigurationManager.AppSettings;");
        //    sb.AppendLine("                //取预连接信息");
        //    sb.AppendLine("                ls_ds = app[\"dbservername\" + ai_DBIndex.ToString()];");
        //    sb.AppendLine("                ls_dbuser = app[\"predbuser\"];");
        //    sb.AppendLine("                ls_pwd = app[\"predbpwd\"];");
        //    sb.AppendLine("                ls_constr = GenConnectString(ls_ds, ls_dbuser, ls_pwd);");
        //    sb.AppendLine("                //预连接数据库获取数据库用户信息");
        //    sb.AppendLine("                using (OracleConnection con = new OracleConnection(ls_constr))");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    OracleCommand cmd = new OracleCommand(\"select sjkyhm,sjkmm from vi_sjkyh\", con);");
        //    sb.AppendLine("                    con.Open();");
        //    sb.AppendLine("                    OracleDataAdapter iAdapter = new OracleDataAdapter();");
        //    sb.AppendLine("                    OracleDataReader odr = cmd.ExecuteReader();");
        //    sb.AppendLine("                    DataTable ldt = new DataTable();");
        //    sb.AppendLine("                    ldt.Columns.Add(\"name\");");
        //    sb.AppendLine("                    ldt.Columns.Add(\"password\");");
        //    sb.AppendLine("                    ldt.PrimaryKey = new DataColumn[] { ldt.Columns[0] };");
        //    sb.AppendLine("                    while (odr.Read())");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        DataRow ldr = ldt.NewRow();");
        //    sb.AppendLine("                        ldr[0] = f_passwd2(odr.GetString(0), 2).ToLower().Trim();");
        //    sb.AppendLine("                        ldr[1] = f_passwd2(odr.GetString(1), 2);");
        //    sb.AppendLine("                        ldt.Rows.Add(ldr);");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("                    odr.Close();");
        //    sb.AppendLine("                    foreach (DataRowView ldrv in ldt.DefaultView)");
        //    sb.AppendLine("                    {");
        //    sb.AppendLine("                        ml_dbuser luser = new ml_dbuser();");
        //    sb.AppendLine("                        luser.DBIndex = ai_DBIndex;");
        //    sb.AppendLine("                        luser.DataBaseServerName = ls_ds;");
        //    sb.AppendLine("                        luser.Name = ldrv[0].ToString();");
        //    sb.AppendLine("                        luser.Password = ldrv[1].ToString();");
        //    sb.AppendLine("                        luser.Alias = app[luser.Name];");
        //    sb.AppendLine("                        if (string.IsNullOrEmpty(luser.Alias))");
        //    sb.AppendLine("                            luser.ConnectString = GenConnectString(ls_ds, luser.Name, luser.Password);");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            DataRow ldr_row = ldt.Rows.Find(luser.Alias.ToLower());");
        //    sb.AppendLine("                            if (ldr_row != null)");
        //    sb.AppendLine("                                luser.Password = ldr_row[1].ToString();");
        //    sb.AppendLine("                            luser.ConnectString = GenConnectString(ls_ds, luser.Alias, luser.Password);");
        //    sb.AppendLine("");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        _dbuser.Add(new KeyValuePair<int, string>(ai_DBIndex, luser.Name), luser.ConnectString);");
        //    sb.AppendLine("                    }");
        //    sb.AppendLine("");
        //    sb.AppendLine("                    if (con.State == ConnectionState.Open) con.Close();");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 设置数据库用户及连接字符串于静态变量DbConnection中");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns>true/false</returns>");
        //    sb.AppendLine("        public static bool SetDBUser()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                GetDBUserData(0, false);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return false;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            return true;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 返回Oracle连接");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"as_dbuser\">数据库连接用户名</param>");
        //    sb.AppendLine("        /// <returns>OracleConnection/null</returns>");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("        #region 连接、断开数据库、获取数据库连接");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 不带参数的实例化本类后，需执行本函数成功后，才能执行SetReader和SetDataSet");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vUser\">数据库用户名</param>");
        //    sb.AppendLine("        /// <returns>true成功，false异常</returns>");
        //    sb.AppendLine("        public void Connect(String vUser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            Connect(0, vUser);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public void Connect(int vDBIndex, string vUser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iConnection = CDataBase.GetConnection(vDBIndex, vUser);");
        //    sb.AppendLine("            iConnection.Open();");
        //    sb.AppendLine("            iCommand.Connection = iConnection;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 断开iConnecton的连接");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        /// ");
        //    sb.AppendLine("        [System.Diagnostics.DebuggerNonUserCodeAttribute()]");
        //    sb.AppendLine("        public void DisConnect()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (iTrans != null)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (iTrans.Connection != null)");
        //    sb.AppendLine("                    iTrans.Rollback();");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            if (iConnection != null) iConnection.Close();");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            _SqlNRows = 0;");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 默认连接第一个配置");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"as_dbuser\"></param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public static OracleConnection GetConnection(string as_dbuser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            return GetConnection(0, as_dbuser);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 连接指定配置的数据库");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"ai_DBIndex\"></param>");
        //    sb.AppendLine("        /// <param name=\"as_dbuser\"></param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public static OracleConnection GetConnection(int ai_DBIndex, string as_dbuser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (GetDBUserCount(ai_DBIndex) <= 0)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                GetDBUserData(ai_DBIndex, false);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? \"\" : as_dbuser.ToLower());");
        //    sb.AppendLine("            if (_dbuser.ContainsKey(ls_keyvalue))");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                OracleConnection con = new OracleConnection(_dbuser[ls_keyvalue]);");
        //    sb.AppendLine("                return con;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                throw new CustomException(CustomExceptionType.Serious, \"你使用的数据库用户\" + as_dbuser + \"不存在\");");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public static KeyValuePair<KeyValuePair<int, string>, string> GetDBUser(int ai_DBIndex, string as_dbuser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (GetDBUserCount(ai_DBIndex) <= 0)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                GetDBUserData(ai_DBIndex, false);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? \"\" : as_dbuser.ToLower());");
        //    sb.AppendLine("            if (_dbuser.ContainsKey(ls_keyvalue))");
        //    sb.AppendLine("                return new KeyValuePair<KeyValuePair<int, string>, string>(ls_keyvalue, _dbuser[ls_keyvalue]);");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                throw new CustomException(CustomExceptionType.Serious, \"你使用的数据库用户\" + as_dbuser + \"不存在\");");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 返回DataTable或DataReader");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 生成OracleDataReader类型的iReader");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vSelectSql\">要执行的sql语句</param>");
        //    sb.AppendLine("        /// <returns>OracleDataReader/null</returns>");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public OracleDataReader SetReader(String vSelectSql)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = vSelectSql;");
        //    sb.AppendLine("            _iReader = iCommand.ExecuteReader();");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            _SqlNRows = -1; //不确定几条记录");
        //    sb.AppendLine("            return _iReader;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public DataTable SetDataTable(string vSql)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = vSql;");
        //    sb.AppendLine("            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
        //    sb.AppendLine("            _iAdapter.SelectCommand = iCommand;");
        //    sb.AppendLine("            DataTable ldt = new DataTable();");
        //    sb.AppendLine("            _SqlNRows = _iAdapter.Fill(ldt);");
        //    sb.AppendLine("            _iDataTable = ldt;");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            return _iDataTable;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public DataTable SetDataTable(string vSql, bool ForUpdate)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = vSql;");
        //    sb.AppendLine("            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
        //    sb.AppendLine("            if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();");
        //    sb.AppendLine("            _iAdapter.SelectCommand = iCommand;");
        //    sb.AppendLine("            DataTable ldt = new DataTable();");
        //    sb.AppendLine("            _SqlNRows = _iAdapter.Fill(ldt);");
        //    sb.AppendLine("            _iDataTable = ldt;");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            return _iDataTable;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public DataTable SetDataTable(string vSql, int startRecord, int maxRecords)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = vSql;");
        //    sb.AppendLine("            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
        //    sb.AppendLine("            _iAdapter.SelectCommand = iCommand;");
        //    sb.AppendLine("            DataTable ldt = new DataTable();");
        //    sb.AppendLine("            _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);");
        //    sb.AppendLine("            _iDataTable = ldt;");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            return _iDataTable;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        public DataTable SetDataTable(string vSql, int startRecord, int maxRecords, bool ForUpdate)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = vSql;");
        //    sb.AppendLine("            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();");
        //    sb.AppendLine("            if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();");
        //    sb.AppendLine("            _iAdapter.SelectCommand = iCommand;");
        //    sb.AppendLine("            DataTable ldt = new DataTable();");
        //    sb.AppendLine("            _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);");
        //    sb.AppendLine("            _iDataTable = ldt;");
        //    sb.AppendLine("            _SqlCode = 0;");
        //    sb.AppendLine("            return _iDataTable;");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 自动把iDataTable中改动，插入的数据同步到数据库");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns>同步的记录数</returns>");
        //    sb.AppendLine("        public int UpdateDataTable()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (_iDataTable == null || _DataTableSelectCommand == null) return 0;");
        //    sb.AppendLine("            return UpdateDataTable(_iDataTable);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public int UpdateDataTable(DataTable aDataTable)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (_iDataTable == null || _DataTableSelectCommand == null) return 0;");
        //    sb.AppendLine("            _iAdapter.SelectCommand = _DataTableSelectCommand;");
        //    sb.AppendLine("            OracleCommandBuilder builder = new OracleCommandBuilder(_iAdapter);");
        //    sb.AppendLine("            return _iAdapter.Update(aDataTable);");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 执行sql语句或存储过程");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 执行sql语句");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vSQL\">SQL语句,</param>");
        //    sb.AppendLine("        /// <returns>select语句返回第一行第一例的值，其他返回null</returns>");
        //    sb.AppendLine("        public object ExeSQL(string vSQL)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            string ls_sql;");
        //    sb.AppendLine("            object lo_obj = null;");
        //    sb.AppendLine("            ls_sql = vSQL.Trim();");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                iCommand.CommandType = CommandType.Text;");
        //    sb.AppendLine("                switch (ls_sql.Substring(0, 6).ToUpper())");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    case \"SELECT\":");
        //    sb.AppendLine("                        iCommand.CommandText = ls_sql;");
        //    sb.AppendLine("                        lo_obj = iCommand.ExecuteScalar();");
        //    sb.AppendLine("                        if (lo_obj == null)");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            _SqlCode = 0;");
        //    sb.AppendLine("                            _SqlNRows = 0;");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            if (lo_obj == DBNull.Value) lo_obj = null;");
        //    sb.AppendLine("                            _SqlCode = 0;");
        //    sb.AppendLine("                            _SqlNRows = 1;");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    case \"UPDATE\":");
        //    sb.AppendLine("                        if (iTrans == null)");
        //    sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            if (iTrans.Connection == null)");
        //    sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        iCommand.CommandText = vSQL;");
        //    sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
        //    sb.AppendLine("                        _SqlCode = 0;");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    case \"INSERT\":");
        //    sb.AppendLine("                        if (iTrans == null)");
        //    sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            if (iTrans.Connection == null)");
        //    sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        iCommand.CommandText = vSQL;");
        //    sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
        //    sb.AppendLine("                        _SqlCode = 0;");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    case \"DELETE\":");
        //    sb.AppendLine("                        if (iTrans == null)");
        //    sb.AppendLine("                            iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        else");
        //    sb.AppendLine("                        {");
        //    sb.AppendLine("                            if (iTrans.Connection == null)");
        //    sb.AppendLine("                                iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                        }");
        //    sb.AppendLine("                        iCommand.CommandText = vSQL;");
        //    sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
        //    sb.AppendLine("                        _SqlCode = 0;");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                    default:");
        //    sb.AppendLine("                        iCommand.CommandText = vSQL;");
        //    sb.AppendLine("                        _SqlNRows = iCommand.ExecuteNonQuery();");
        //    sb.AppendLine("                        _SqlCode = 0;");
        //    sb.AppendLine("                        break;");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                return lo_obj;");
        //    sb.AppendLine("");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch (Exception e)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = -1;");
        //    sb.AppendLine("                _SqlNRows = 0;");
        //    sb.AppendLine("                _SqlErrorText = e.Message;");
        //    sb.AppendLine("                throw e;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        public void ExecProcedure(string vProcedureName)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (iTrans == null)");
        //    sb.AppendLine("                    iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                else");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (iTrans.Connection == null)");
        //    sb.AppendLine("                        iTrans = iConnection.BeginTransaction();");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                iCommand.CommandType = CommandType.StoredProcedure;");
        //    sb.AppendLine("                iCommand.CommandText = vProcedureName;");
        //    sb.AppendLine("                _SqlNRows = iCommand.ExecuteNonQuery();");
        //    sb.AppendLine("                _SqlCode = 0;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch (Exception e)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = -1;");
        //    sb.AppendLine("                _SqlNRows = 0;");
        //    sb.AppendLine("                _SqlErrorText = e.Message;");
        //    sb.AppendLine("                throw e;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("        #region 事务处理");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 提交事务");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns>返回true成功；返回false失败</returns>");
        //    sb.AppendLine("        public void Commit()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (iTrans != null)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (iTrans.Connection != null)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    iTrans.Commit();");
        //    sb.AppendLine("                    _SqlCode = 0;");
        //    sb.AppendLine("                    _SqlNRows = -1;");
        //    sb.AppendLine("");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else//select 结束事物提交");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (iConnection != null && iConnection.State == ConnectionState.Open)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    ExeSQL(\"commit\");");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 回滚事务");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns>返回true成功；返回false失败</returns>");
        //    sb.AppendLine("        public void Rollback()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (iTrans != null)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                if (iTrans.Connection != null)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    iTrans.Rollback();");
        //    sb.AppendLine("                    _SqlCode = 0;");
        //    sb.AppendLine("                    _SqlNRows = -1;");
        //    sb.AppendLine("");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("        #region 数据连接后的特殊服务，如获取时间、拼音五笔和序列值");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取数据库时间，失败则以应用服务器的时间代替");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public DateTime GetDBDateTime()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return (DateTime)ExeSQL(\"select sysdate from dual\");");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return DateTime.Now;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取拼音五笔");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"yourstring\"></param>");
        //    sb.AppendLine("        /// <param name=\"strpy\"></param>");
        //    sb.AppendLine("        /// <param name=\"strwb\"></param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public void f_GetPyWb(string yourstring, out string strpy, out string strwb)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            strpy = string.Empty;");
        //    sb.AppendLine("            strwb = string.Empty;");
        //    sb.AppendLine("            if (string.IsNullOrEmpty(yourstring))");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            string strchar = string.Empty;");
        //    sb.AppendLine("            for (int i = 0; i < yourstring.Length; i++)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("");
        //    sb.AppendLine("                strchar = yourstring.Substring(i, 1);");
        //    sb.AppendLine("                SetReader(\"SELECT py,wb FROM xtgl_pywb WHERE xtgl_pywb.zf = '\" + strchar + \"'\");");
        //    sb.AppendLine("                if (_iReader.HasRows)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    _iReader.Read();");
        //    sb.AppendLine("                    strpy = String.Concat(strpy, _iReader[\"py\"].ToString());");
        //    sb.AppendLine("                    strwb = String.Concat(strwb, _iReader[\"wb\"].ToString());");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                _iReader.Close();");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 获取指定序列的NextValue");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"vSequenceName\">序列名</param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public Int64 GetNextValue(string vSequenceName)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = \"select \" + vSequenceName.Trim() + \".nextval from dual\";");
        //    sb.AppendLine("            object lo_obj = iCommand.ExecuteScalar();");
        //    sb.AppendLine("            if (lo_obj == null)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = 0;");
        //    sb.AppendLine("                _SqlNRows = 0;");
        //    sb.AppendLine("                return -1;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = 0;");
        //    sb.AppendLine("                _SqlNRows = 1;");
        //    sb.AppendLine("                return Convert.ToInt64(lo_obj);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// ");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"as_tablename\"></param>");
        //    sb.AppendLine("        /// <param name=\"as_colname\"></param>");
        //    sb.AppendLine("        /// <returns></returns>");
        //    sb.AppendLine("        public long GetNextValue(string as_tablename, string as_colname)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            iCommand.CommandText = string.Format(\"select max({0}) from {1}\", as_tablename, as_colname);");
        //    sb.AppendLine("            object lo_obj = iCommand.ExecuteScalar();");
        //    sb.AppendLine("            if (lo_obj == null || lo_obj == DBNull.Value)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = 0;");
        //    sb.AppendLine("                _SqlNRows = 1;");
        //    sb.AppendLine("                return 1;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            else");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                _SqlCode = 0;");
        //    sb.AppendLine("                _SqlNRows = 1;");
        //    sb.AppendLine("                return (Convert.ToInt64(lo_obj) + 1);");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        #region 静态函数 一个事务多条Sql语句");
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 事务操作(不能用于Blob类型)");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"sql\">sql语句(不加;)字符串数组(定长)</param>");
        //    sb.AppendLine("        /// <returns>true/false</returns>");
        //    sb.AppendLine("        public static bool TransOperate(string[] as_sql, string as_dbuser)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            int li_cnt = as_sql.Length;");
        //    sb.AppendLine("            if (li_cnt <= 0)");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                return false;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            OracleConnection con = GetConnection(as_dbuser);");
        //    sb.AppendLine("            con.Open();");
        //    sb.AppendLine("            OracleTransaction trans = con.BeginTransaction();");
        //    sb.AppendLine("            OracleCommand cmd = new OracleCommand();");
        //    sb.AppendLine("            cmd.Connection = con;");
        //    sb.AppendLine("            try");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                for (int i = 0; i < li_cnt; i++)");
        //    sb.AppendLine("                {");
        //    sb.AppendLine("                    if (as_sql[i] == \"\" || as_sql[i] == null) continue;");
        //    sb.AppendLine("                    cmd.CommandText = as_sql[i];");
        //    sb.AppendLine("                    cmd.ExecuteNonQuery();");
        //    sb.AppendLine("                }");
        //    sb.AppendLine("                trans.Commit();");
        //    sb.AppendLine("                return true;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            catch");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                trans.Rollback();");
        //    sb.AppendLine("                return false;");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            finally");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                con.Close();");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine("");
        //    sb.AppendLine("        internal void Connect()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            throw new NotImplementedException();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        internal OracleDataReader SetReader()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            throw new NotImplementedException();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        internal void Equals()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            throw new NotImplementedException();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        internal void ExeSQL()");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            throw new NotImplementedException();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("");
        //    sb.AppendLine("        internal class ml_dbuser");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            private int _dbindex;");
        //    sb.AppendLine("            private string _dbalias;");
        //    sb.AppendLine("            private string _name;");
        //    sb.AppendLine("            private string _alias;");
        //    sb.AppendLine("            private string _password;");
        //    sb.AppendLine("            private string _constr;");
        //    sb.AppendLine("            //属于web.config中配置的第几个数据库");
        //    sb.AppendLine("            public int DBIndex");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _dbindex; }");
        //    sb.AppendLine("                set { _dbindex = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            //系统内使用数据库名");
        //    sb.AppendLine("            public string DataBaseServerName");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _dbalias; }");
        //    sb.AppendLine("                set { _dbalias = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            //系统内使用DB用户名");
        //    sb.AppendLine("            public string Name");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _name; }");
        //    sb.AppendLine("                set { _name = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            //实际环境中数据库对应的DB用户名");
        //    sb.AppendLine("            public string Alias");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _alias; }");
        //    sb.AppendLine("                set { _alias = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            //DB用户的密码");
        //    sb.AppendLine("            public string Password");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _password; }");
        //    sb.AppendLine("                set { _password = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("            //已经配置就绪的连接串");
        //    sb.AppendLine("            public string ConnectString");
        //    sb.AppendLine("            {");
        //    sb.AppendLine("                get { return _constr; }");
        //    sb.AppendLine("                set { _constr = value; }");
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("    }");



        //    sb.AppendLine("    #endregion").AppendLine();
        //    return sb.ToString();
        //}
    }

}


/*
  static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader stream = new StreamReader(@"C:\Users\tongling\Desktop\ConsoleApplication1\ConsoleApplication1\Class1.cs"))
            {
                string dh="\\";
                dh+="\"";
                var str = stream.ReadLine();
                bool bo = true;
                while (bo)
                {
                    str=str.Contains("\"")?str.Replace("\"",dh):str;
                    sb.AppendLine(string.Format("sb.AppendLine(\"{0}\");", str));
                    
                    bo = !stream.EndOfStream;
                    str = stream.ReadLine();
                }
            }
            string result = sb.ToString();
            string test = new Class2().strss();
            int asdfasd = 0;
            
        }
 */


//using Oracle.DataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//internal class VariableInfo
//{
//    /// <summary>
//    /// 应用程序级变量(配置文件和Application中变量的集合)
//    /// </summary>
//    public class ApplicationVar
//    {
//        private static string _applname;
//        private static string _appldm;
//        private static string _znqxglmkdm;//组内权限管理模块代码
//        private static string _dwdm;
//        private static string _dwmc;
//        private static string _ywdwmc;  //英文单位名称
//        private static string _servicephone;  //服务电话
//        private static string _HaveGlobalAccessControl;
//        private static long _ApplTotalLoginUserCount;
//        private static long _OnLineUserCount;
//        private static string _sbyxbs;
//        private static string _sbyljgdm;//社保医疗机构代码
//        private static string _nbyljgdm;//农保医疗机构代码
//        private static string _nbqzjdz;//农保前置机网络地址：IP+端口号
//        private static int? _xtggid;//系统公告信息ID号
//        private static string _oaxxlb;//oa系统短信的消息类别
//        private static System.Object _LockObj1 = new object();
//        /// <summary>
//        /// 应用程序名称
//        /// </summary>
//        public static string ApplName
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_applname))
//                    _applname = System.Configuration.ConfigurationManager.AppSettings["applname"];
//                return _applname;
//            }
//            set
//            {
//                _applname = value;
//            }
//        }
//        /// <summary>
//        /// oa系统短信的消息类别
//        /// </summary>
//        public static string OAXXLB
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_oaxxlb))
//                    _oaxxlb = System.Configuration.ConfigurationManager.AppSettings["oaxxlb"];
//                return _oaxxlb;
//            }
//            set
//            {
//                _oaxxlb = value;
//            }
//        }
//        /// <summary>
//        /// 应用程序代码
//        /// </summary>
//        public static string ApplDm
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_appldm))
//                    _appldm = System.Configuration.ConfigurationManager.AppSettings["appldm"];
//                return _appldm;
//            }
//            set
//            {
//                _appldm = value;
//            }
//        }
//        /// <summary>
//        /// 组内权限管理模块代码
//        /// </summary>
//        public static string ZNQXGLMKDM
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_znqxglmkdm))
//                    _znqxglmkdm = System.Configuration.ConfigurationManager.AppSettings["znqxglmkdm"];
//                return _znqxglmkdm;
//            }
//            set
//            {
//                _znqxglmkdm = value;
//            }
//        }
//        /// <summary>
//        /// 系统公告ID
//        /// </summary>
//        public static int? XTGGID
//        {
//            get
//            {
//                if (!_xtggid.HasValue)
//                    _xtggid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["xtggid"]);
//                return _xtggid;
//            }
//            set
//            {
//                _xtggid = value;
//            }
//        }
//        /// <summary>
//        /// 当前登录用户人数（即当前在线人数）
//        /// *注意* 使用 OnLineUserCount++会导致ApplTotalLoginUserCount自动加一
//        /// </summary>
//        public static long OnLineUserCount
//        {
//            get
//            {
//                lock (_LockObj1)
//                {
//                    if (_OnLineUserCount < 0)
//                        _OnLineUserCount = 0;
//                    return _OnLineUserCount;
//                }
//            }
//            set
//            {
//                lock (_LockObj1)
//                {
//                    if (_OnLineUserCount == value - 1)
//                    {
//                        _ApplTotalLoginUserCount++;
//                    }
//                    _OnLineUserCount = value;
//                }
//            }
//        }
//        /// <summary>
//        /// 单位代码
//        /// </summary>
//        public static string dwdm
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_dwdm))
//                    _dwdm = System.Configuration.ConfigurationManager.AppSettings["dwdm"];
//                if (string.IsNullOrEmpty(_dwdm)) _dwdm = "01";
//                return _dwdm;
//            }
//            set
//            {
//                _dwdm = value;
//            }
//        }
//        /// <summary>
//        /// 单位名称
//        /// </summary>
//        public static string dwmc
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_dwmc))
//                    _dwmc = System.Configuration.ConfigurationManager.AppSettings["dwmc"];
//                if (string.IsNullOrEmpty(_dwmc)) _dwmc = "温州医院";
//                return _dwmc;
//            }
//            set
//            {
//                _dwmc = value;
//            }
//        }
//        /// <summary>
//        /// 英文单位名称
//        /// </summary>
//        public static string ywdwmc
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_ywdwmc))
//                    _ywdwmc = System.Configuration.ConfigurationManager.AppSettings["ywdwmc"];
//                if (string.IsNullOrEmpty(_ywdwmc)) _ywdwmc = "WenZhou Hospital";
//                return _ywdwmc;
//            }
//            set
//            {
//                _ywdwmc = value;
//            }
//        }
//        /// <summary>
//        /// 服务电话(错误页中用到)
//        /// </summary>
//        public static string servicephone
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_servicephone))
//                    _servicephone = System.Configuration.ConfigurationManager.AppSettings["servicephone"];
//                if (string.IsNullOrEmpty(_servicephone)) _servicephone = "没有登记服务电话";
//                return _servicephone;
//            }
//            set
//            {
//                _servicephone = value;
//            }
//        }
//        /// <summary>
//        /// 全局页面访问控制模式
//        /// "0" 不控制
//        /// "1" 已经登记的页面按权限访问，没有登记则不控制访问
//        /// "2" 已经登记的页面按权限访问，没有登记则禁止访问
//        /// </summary>
//        public static string GlobalAccessControl
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_HaveGlobalAccessControl))
//                    _HaveGlobalAccessControl = System.Configuration.ConfigurationManager.AppSettings["GlobalAccessControl"];
//                return _HaveGlobalAccessControl;
//            }
//            set
//            {
//                _HaveGlobalAccessControl = value;
//            }
//        }


//        /// <summary>
//        /// 农保医疗机构代码
//        /// </summary>
//        public static string NBYLJGDM
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_nbyljgdm))
//                {
//                    lock (_LockObj1)
//                    {

//                        _nbyljgdm = "1001";
//                    }
//                }
//                return _nbyljgdm;
//            }
//        }
//        /// <summary>
//        /// 农保前置机IP地址及端口号
//        /// </summary>
//        public static string NBQZJDZ
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(_nbqzjdz))
//                {
//                    lock (_LockObj1)
//                    {

//                        _nbqzjdz = "172.16.12.92:9999";
//                    }
//                }
//                return _nbqzjdz;
//            }
//        }
//    }


//}
///// <summary>
///// 自定义异常类
///// </summary>
//internal class CustomException : ApplicationException
//{
//    private string _ipAddress;  //客户端ip地址
//    private string _czz;        //操作者
//    private Int64 _idczz;       //操作者ID    
//    private string _url;        //出错页面
//    private string _userAgent;  //客户段浏览器代理信息
//    private CustomExceptionType _exceptionType;
//    private bool _loged = false;
//    private string _hostname;
//    protected void Init()
//    {
//        try
//        {


//            _exceptionType = CustomExceptionType.UnKnowException;
//        }
//        catch (Exception ex)
//        {
//            System.Diagnostics.Debug.Write(ex.Message);
//        }
//    }

//    #region 构造函数
//    public CustomException(CustomExceptionType exceptionType, string message, Exception innerException)
//        : base(message, innerException)
//    {
//        Init();
//        _exceptionType = exceptionType;
//    }



//    public CustomException(string message, Exception innerException)
//        : base(message, innerException)
//    {
//        Init();
//    }

//    public CustomException(CustomExceptionType exceptionType, string message)
//        : base(message)
//    {
//        Init();
//        _exceptionType = exceptionType;
//    }

//    public CustomException(string message)
//        : base(message)
//    {
//        Init();
//    }
//    #endregion

//    #region 属性

//    /// <summary>
//    /// 获取包括InnerException的所有异常信息
//    /// </summary>
//    public virtual string MessageAll
//    {
//        get
//        {
//            string ls_msg = base.Message;

//            if (InnerException != null)
//            {
//                CustomException blex = InnerException as CustomException;
//                if (blex != null)
//                {
//                    if (string.IsNullOrEmpty(ls_msg))
//                        ls_msg = blex.MessageAll;
//                    else
//                        ls_msg = ls_msg + "," + blex.MessageAll;
//                }
//                else
//                {
//                    if (string.IsNullOrEmpty(ls_msg))
//                        ls_msg = InnerException.Message;
//                    else
//                        ls_msg = ls_msg + ",错误原因：" + InnerException.Message;
//                }
//            }

//            return ls_msg;
//        }
//    }


//    /// <summary>
//    /// 客户端IP地址
//    /// </summary>
//    public string IPAddress
//    {
//        get
//        {
//            return _ipAddress;
//        }
//    }

//    /// <summary>
//    /// 操作者
//    /// </summary>
//    public string Czz
//    {
//        get
//        {
//            return _czz;
//        }
//    }


//    /// <summary>
//    /// 操作者ID
//    /// </summary>
//    public Int64 IDCzz
//    {
//        get
//        {
//            return _idczz;
//        }
//    }

//    /// <summary>
//    /// 出错页面
//    /// </summary>
//    public string URL
//    {
//        get
//        {
//            return _url;
//        }
//    }

//    /// <summary>
//    /// 客户段浏览器代理信息
//    /// </summary>
//    public string UserAgent
//    {
//        get
//        {
//            return _userAgent;
//        }
//    }
//    public string HostName
//    {
//        get
//        {
//            return _hostname;
//        }
//    }

//    public string YYDM
//    {
//        get
//        {
//            return VariableInfo.ApplicationVar.ApplDm;
//        }
//    }
//    /// <summary>
//    /// 异常类型
//    /// </summary>
//    public CustomExceptionType ExceptionType
//    {
//        get
//        {
//            return _exceptionType;
//        }
//    }
//    #endregion

//}
///// <summary>
///// 异常类型
///// </summary>
//internal enum CustomExceptionType
//{



//    //------------101-200为一般等级的异常类型--------//

//    /// <summary>
//    /// 验证异常
//    /// </summary>
//    Validate = 101,

//    //----------------------------------------------//


//    //------------201-300为严重等级的异常类型--------//

//    /// <summary>
//    /// 严重的异常
//    /// </summary>
//    Serious = 201,

//    /// <summary>
//    /// 数据库访问异常
//    /// </summary>
//    DataAccess = 202,

//    /// <summary>
//    /// 获取数据库数据异常
//    /// </summary>
//    Select = 203,

//    /// <summary>
//    /// 插入数据库数据异常
//    /// </summary>
//    Insert = 204,

//    /// <summary>
//    /// 更新数据库数据异常
//    /// </summary>
//    Update = 205,

//    /// <summary>
//    /// 删除数据库数据异常
//    /// </summary>
//    Delete = 206,

//    /// <summary>
//    /// 更新并发异常
//    /// </summary>
//    UpdateConcurrency = 207,

//    /// <summary>
//    /// 删除并发异常
//    /// </summary>
//    DeleteConcurrency = 208,


//    //------------------------------------
//    /// <summary>
//    /// 未知异常
//    /// </summary>
//    UnKnowException = 999

//}
//internal partial class CDataBase : IDisposable
//{

//    public void ParametersClear()
//    {
//        this.Parameters.Clear();
//    }

//    public void ParametersAdd(string key, object value)
//    {
//        this.Parameters.Add(key, value);
//    }

//    public IList<T> GetDataItems<T>(string sql) where T : class, new()
//    {

//        //object tempType = null;
//        //string isNull = "isNull";
//        try
//        {
//            this.iCommand.CommandText = sql;
//            this._iReader = this.iCommand.ExecuteReader();
//            if (!this._iReader.HasRows)
//            {
//                this._iReader.Close();
//                return new List<T>();
//            }
//            Type typeFromHandle = typeof(T);
//            var inner =
//                from i in Enumerable.Range(1, this._iReader.FieldCount)
//                select new
//                {
//                    Name = this._iReader.GetName(i - 1),
//                    Index = i - 1
//                };
//            var enumerable = typeFromHandle.GetProperties().Join(inner, x => x.Name, x => x.Name, (x, y) => new { y.Index, x });
//            List<T> list = new List<T>();
//            while (this._iReader.Read())
//            {
//                T t = Activator.CreateInstance<T>();
//                foreach (var current in enumerable)
//                {
//                    //tempType = current;
//                    //isNull = "isNull";
//                    //isNull = this._iReader[current.Index].ToString();

//                    if (this._iReader[current.Index].GetType() != typeof(DBNull))
//                    {
//                        try
//                        {
//                            if (current.x.PropertyType.IsGenericType && current.x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
//                            {
//                                current.x.SetValue(t, new NullableConverter(current.x.PropertyType).ConvertFromString(this._iReader[current.Index].ToString()), null);
//                            }
//                            else
//                                current.x.SetValue(t, Convert.ChangeType(this._iReader[current.Index], current.x.PropertyType), null);

//                        }
//                        catch (Exception exe)
//                        {
//                            throw exe;
//                            //Lenovo.Tool.Log4NetHelper.Error(exe);
//                        }
//                    }
//                }
//                list.Add(t);
//            }
//            this._iReader.Close();
//            return list;

//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//    }


//    #region 类成员定义
//    //实例化后成员：Oracle连接
//    private OracleConnection iConnection;    //Connect执行成功后：Oracle连接
//    private OracleCommand iCommand;          //实例化后成员：Oracle命令
//    private OracleCommand _DataTableSelectCommand;//SetDataTable后的可用成员：Oracle命令
//    private OracleDataAdapter _iAdapter;      //SetDateSet：OracleAdapter
//    private OracleDataReader _iReader;        //SetReader执行成功后：OracleReader
//    private DataTable _iDataTable;
//    private int _SqlNRows = -1;                 //ExeSQL执行后影响到的行数 -1表示未执行sql语句或不确定几条记录
//    private int _SqlCode = -1;                 //ExeSQL执行成功还是失败，－1失败 0成功
//    public string _SqlErrorText;

//    private OracleTransaction iTrans;       //Connect执行成功后：事务处理对象  bm zsm mm constr
//    //private static Dictionary<string, string> DbConnection = new Dictionary<string, string>();
//    //private static Dictionary<string, string> DbConnStr = new Dictionary<string, string>();
//    /// <summary>
//    /// 数据库用户集合，《 <数据库号，用户名>,连接串》
//    /// </summary>
//    private static Dictionary<KeyValuePair<int, string>, string> _dbuser = new Dictionary<KeyValuePair<int, string>, string>();
//    private bool disposed = false;
//    #endregion
//    #region 公有属性
//    public OracleDataAdapter iAdapter
//    {
//        get
//        {
//            return _iAdapter;
//        }
//    }
//    public OracleDataReader iReader
//    {
//        get
//        {
//            return _iReader;
//        }
//    }
//    public DataTable iDataTable
//    {
//        get
//        {
//            return _iDataTable;//db.iDataTable[0][0].;
//        }
//    }
//    public int SqlNRows
//    {
//        get
//        {
//            return _SqlNRows;
//        }
//    }
//    public int SqlCode
//    {
//        get
//        {
//            return _SqlCode;
//        }
//    }
//    public string SqlErrorText
//    {
//        get
//        {
//            return _SqlErrorText;
//        }
//    }
//    /// 只读属性 OracleParameterCollection
//    /// </summary>
//    public OracleParameterCollection Parameters
//    {
//        get
//        {
//            return iCommand.Parameters;
//        }

//    }

//    /// <summary>
//    /// 返回datatable
//    /// </summary>


//    #endregion
//    #region 构造函数和析构函数及资源的释放管理
//    //.............开始实例化后的方法定义.....................
//    /// <summary>
//    /// 实例化iCommand,iAdapter,iDataSet三个成员
//    /// </summary>
//    public CDataBase()
//    {
//        iCommand = new OracleCommand();
//        iCommand.BindByName = true;
//        Connect(0, ConfigurationManager.AppSettings["DefaultUser"]);
//    }
//    /// <summary>
//    /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数
//    /// </summary>
//    /// <param name="vUser">数据库用户名</param>
//    public CDataBase(string vUser)
//    {
//        iCommand = new OracleCommand();
//        iCommand.BindByName = true;
//        Connect(0, vUser);

//    }
//    /// <summary>
//    /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数
//    /// </summary>
//    /// <param name="vUser">数据库用户名</param>
//    public CDataBase(int ai_DBIndex, string vUser)
//    {
//        iCommand = new OracleCommand();
//        iCommand.BindByName = true;
//        Connect(ai_DBIndex, vUser);

//    }
//    /// <summary>
//    /// 释放托管与非托管资源
//    /// </summary>
//    /// <param name="disposing"></param>
//    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
//    protected virtual void Dispose(bool disposing)
//    {
//        if (!this.disposed)
//        {
//            //释放非托管资源
//            DisConnect();

//            //释放托管资源
//            if (disposing)
//            {
//                iConnection.Dispose();
//                iConnection = null;

//                if (iTrans != null)
//                {
//                    iTrans.Dispose();
//                    iTrans = null;
//                }

//                if (_iAdapter != null)
//                {
//                    _iAdapter.Dispose();
//                    _iAdapter = null;
//                }


//                if (_iReader != null)
//                {
//                    _iReader.Dispose();
//                    _iReader = null;
//                }

//                if (iCommand != null)
//                {
//                    iCommand.Dispose();
//                    iCommand = null;
//                }

//                if (_iDataTable != null)
//                {
//                    _iDataTable.Dispose();
//                    _iDataTable = null;
//                }

//            }

//        }
//        disposed = true;
//    }


//    public void Dispose()
//    {
//        Dispose(true);
//        GC.SuppressFinalize(this);
//    }

//    ~CDataBase()
//    {
//        Dispose(false);
//    }
//    #endregion

//    #region 服务器初始化用
//    /// <summary>
//    /// 获取指定数据库的DBUser个数
//    /// </summary>
//    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
//    /// <returns></returns>
//    private static int GetDBUserCount(int ai_DBIndex)
//    {
//        int count = 0;
//        foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)
//        {
//            if (ls_keyvalue.Key.Key == ai_DBIndex)
//                count++;
//        }
//        return count;
//    }
//    /// <summary>
//    /// 删除指定数据库的所有DBUser
//    /// </summary>
//    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
//    private static void RemoveDBUser(int ai_DBIndex)
//    {
//        foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)
//        {
//            if (ls_keyvalue.Key.Key == ai_DBIndex)
//                _dbuser.Remove(ls_keyvalue.Key);
//        }
//    }

//    private static string GenConnectString(string as_ds, string as_dbuser, string as_password)
//    {
//        string ls_constr;
//        ls_constr = "Data Source=" + as_ds + ";User ID=" + as_dbuser + ";Password=" + as_password +
//                    ";Pooling=false" +             //true，则请求从连接池返回，没连接池则自动创建,默认值为true
//            ";Enlist=true";           　　//
//        return "Data Source=" + as_ds + ";User ID=" + as_dbuser + ";Password=" + as_password + ";Pooling=true; Persist Security Info=True;";
//    }
//    /// <summary>
//    /// 将字符转换为ＡＳＣ码
//    /// </summary>
//    /// <param name="asciiCode">字符</param>
//    /// <returns>对应的ＡＳＣ码</returns>
//    private static int Asc(string character)
//    {
//        if (character.Length == 1)
//        {
//            byte[] bytes = System.Text.Encoding.Default.GetBytes(character);
//            int intAsciiCode = (int)bytes[0];
//            return (intAsciiCode);
//        }
//        else
//        {
//            throw new Exception("字符的长度不对");
//        }

//    }
//    /// <summary>
//    /// 返回字符串的长度（包括汉字），汉字长度为2
//    /// </summary>
//    /// <param name="yourstring">源字符串</param>
//    /// <returns>字符串</returns>
//    private static int f_length(string yourstring)
//    {
//        if (string.IsNullOrEmpty(yourstring)) return 0;
//        int len = yourstring.Length;
//        byte[] sarr = System.Text.Encoding.Default.GetBytes(yourstring);
//        return sarr.Length;
//    }
//    /// <summary>
//    /// 从左边开始取len长个几个字符串
//    /// </summary>
//    /// <param name="yourstring">源字符串</param>
//    /// <param name="len">指定长度</param>
//    /// <returns>字符串</returns>
//    private static string f_left(string yourstring, int ai_len)
//    {
//        if (ai_len <= 0) return string.Empty;
//        if (string.IsNullOrEmpty(yourstring)) return string.Empty;
//        int length = f_length(yourstring);
//        if (length <= ai_len)
//            return yourstring;
//        else
//        {
//            int tmp = 0;
//            int len = 0;
//            int okLen = 0;
//            int li_asc;
//            string ls_return = string.Empty;
//            for (int i = 0; i < length; i++)
//            {
//                //获取asc码
//                li_asc = Asc(yourstring.Substring(i, 1));
//                if (li_asc > 127)
//                    tmp += 2;
//                else
//                    len += 1;
//                okLen += 1;
//                if (tmp + len == ai_len)
//                {
//                    ls_return = yourstring.Substring(0, okLen);
//                    break;
//                }
//                else if (tmp + len > ai_len)
//                {
//                    ls_return = yourstring.Substring(0, okLen - 1);
//                    break;
//                }
//            }
//            return ls_return;
//        }
//    }
//    /// <summary>
//    /// 从指定文字开始取len长的字符串
//    /// </summary>
//    /// <param name="yourstring">源字符串</param>
//    /// <param name="start">开始的位置</param>
//    /// <param name="len">指定长度</param>
//    /// <returns>字符串</returns>
//    public static string f_mid(string yourstring, int start, int len)
//    {
//        if (len <= 0 || start < 0) return string.Empty;
//        if (string.IsNullOrEmpty(yourstring)) return string.Empty;
//        if (yourstring.Length < start) return string.Empty;
//        if (yourstring.Length <= start + len - 1)
//            return yourstring.Substring(start - 1);
//        else
//            return yourstring.Substring(start - 1, len);
//    }
//    /// <summary>
//    /// 按固定数、随机数加密或解密
//    /// </summary>
//    /// <param name="as_pass"></param>
//    /// <param name="ai_mod">ai_mod = 0 固定数加密,ai_mod = 1 随机数加密,ai_mod = 2 解密</param>
//    /// <returns>加／解密后的字符串</returns>
//    private static string f_passwd2(string as_pass, int ai_mod)
//    {
//        if (as_pass.Length > 23)
//            return "-";
//        int li_i, li_len, li_pos;
//        string ls_cpu = "", ls_tmp = "", ls_ret = "";
//        string[,] ls_pass = new string[14, 2];
//        if (ai_mod == 0 || ai_mod == 1)
//        {
//            if (string.IsNullOrEmpty(as_pass)) return "";
//            as_pass = f_left(as_pass, 10);
//            if (ai_mod == 1)
//            {
//                ls_cpu = DateTime.Now.ToString("mmss");
//            }
//            else
//            {
//                ls_cpu = f_left(System.Convert.ToString(System.Convert.ToDouble(f_length(as_pass)) / 0.000412), 4);     //不能改变
//            }
//            li_len = f_length(as_pass);
//            ls_ret = as_pass + ls_cpu;
//            for (li_i = 1; li_i <= 4; li_i++)
//            {
//                li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));
//                li_pos = li_pos % (li_len + 4);
//                if (li_pos == 0) li_pos = 1;
//                ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);
//                ls_pass[li_pos - 1, 1] = "1";
//                li_pos = (9 - li_pos) % (li_len + 4);
//                if (li_pos == 0) li_pos = 1;
//                ls_pass[li_pos - 1, 1] = "1";
//                ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);
//            }
//            for (li_i = 1; li_i <= li_len + 4; li_i++)
//            {
//                if (ls_pass[li_i - 1, 1] == "1") continue;
//                ls_tmp = ls_tmp + f_mid(ls_ret, li_i, 1);
//            }
//            ls_ret = System.Convert.ToString(li_len - 1) + ls_cpu + ls_tmp;
//            return ls_ret;
//        }
//        else if (ai_mod == 2)
//        {
//            if (string.IsNullOrEmpty(as_pass)) return "";
//            li_len = System.Convert.ToInt32(f_mid(as_pass, 1, 1)) + 1;
//            ls_cpu = f_mid(as_pass, 2, 4);
//            ls_ret = f_mid(as_pass, 6, f_length(as_pass));
//            for (li_i = 1; li_i <= 4; li_i++)
//            {
//                li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));
//                li_pos = li_pos % (li_len + 4);
//                if (li_pos == 0) li_pos = 1;
//                ls_pass[li_pos - 1, 1] = "1";
//                ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i - 1, 1);
//                li_pos = (9 - li_pos) % (li_len + 4);
//                li_pos = li_pos % (li_len + 4);
//                if (li_pos == 0) li_pos = 1;
//                ls_pass[li_pos - 1, 1] = "1";
//                ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i, 1);
//            }
//            li_pos = 9;
//            for (li_i = 1; li_i <= li_len; li_i++)
//            {
//                if (ls_pass[li_i - 1, 1] == "1")
//                {
//                    //null 
//                }
//                else
//                {
//                    ls_pass[li_i - 1, 0] = f_mid(ls_ret, li_pos, 1);
//                    li_pos++;
//                }
//                ls_tmp = ls_tmp + ls_pass[li_i - 1, 0];
//            }
//            return ls_tmp;
//        }
//        else
//        {
//            return as_pass;
//        }
//    }

//    /// <summary>
//    /// 生成指定数据库的DBUser的配置信息（必须是使用温一医DBUser结构的）
//    /// </summary>
//    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
//    /// <param name="ab_IsForceUpdated">是否强制重新获取信息</param>
//    private static void GetDBUserData(int ai_DBIndex, Boolean ab_IsForceUpdated)
//    {
//        lock (_dbuser)
//        {
//            if (GetDBUserCount(ai_DBIndex) > 0 && ab_IsForceUpdated == false) //有数据而且不要求强制更新
//            {
//                return;
//            }
//            else
//            {
//                RemoveDBUser(ai_DBIndex);
//            }
//            string ls_constr, ls_ds, ls_dbuser, ls_pwd;
//            NameValueCollection app = System.Configuration.ConfigurationManager.AppSettings;
//            //取预连接信息
//            ls_ds = app["dbservername" + ai_DBIndex.ToString()];
//            ls_dbuser = app["predbuser"];
//            ls_pwd = app["predbpwd"];
//            ls_constr = GenConnectString(ls_ds, ls_dbuser, ls_pwd);
//            //预连接数据库获取数据库用户信息
//            using (OracleConnection con = new OracleConnection(ls_constr))
//            {

//                OracleCommand cmd = new OracleCommand("select sjkyhm,sjkmm from vi_sjkyh", con);
//                con.Open();
//                OracleDataAdapter iAdapter = new OracleDataAdapter();
//                OracleDataReader odr = cmd.ExecuteReader();
//                DataTable ldt = new DataTable();
//                ldt.Columns.Add("name");
//                ldt.Columns.Add("password");
//                ldt.PrimaryKey = new DataColumn[] { ldt.Columns[0] };
//                while (odr.Read())
//                {
//                    DataRow ldr = ldt.NewRow();
//                    ldr[0] = f_passwd2(odr.GetString(0), 2).ToLower().Trim();
//                    ldr[1] = f_passwd2(odr.GetString(1), 2);
//                    ldt.Rows.Add(ldr);
//                }
//                odr.Close();
//                foreach (DataRowView ldrv in ldt.DefaultView)
//                {
//                    ml_dbuser luser = new ml_dbuser();
//                    luser.DBIndex = ai_DBIndex;
//                    luser.DataBaseServerName = ls_ds;
//                    luser.Name = ldrv[0].ToString();
//                    luser.Password = ldrv[1].ToString();
//                    luser.Alias = app[luser.Name];
//                    if (string.IsNullOrEmpty(luser.Alias))
//                        luser.ConnectString = GenConnectString(ls_ds, luser.Name, luser.Password);
//                    else
//                    {
//                        DataRow ldr_row = ldt.Rows.Find(luser.Alias.ToLower());
//                        if (ldr_row != null)
//                            luser.Password = ldr_row[1].ToString();
//                        luser.ConnectString = GenConnectString(ls_ds, luser.Alias, luser.Password);

//                    }
//                    _dbuser.Add(new KeyValuePair<int, string>(ai_DBIndex, luser.Name), luser.ConnectString);
//                }

//                if (con.State == ConnectionState.Open) con.Close();
//            }
//        }
//    }
//    /// <summary>
//    /// 设置数据库用户及连接字符串于静态变量DbConnection中
//    /// </summary>
//    /// <returns>true/false</returns>
//    public static bool SetDBUser()
//    {
//        try
//        {
//            GetDBUserData(0, false);
//        }
//        catch
//        {
//            return false;
//        }
//        return true;
//    }
//    /// <summary>
//    /// 返回Oracle连接
//    /// </summary>
//    /// <param name="as_dbuser">数据库连接用户名</param>
//    /// <returns>OracleConnection/null</returns>
//    #endregion
//    #region 连接、断开数据库、获取数据库连接
//    /// <summary>
//    /// 不带参数的实例化本类后，需执行本函数成功后，才能执行SetReader和SetDataSet
//    /// </summary>
//    /// <param name="vUser">数据库用户名</param>
//    /// <returns>true成功，false异常</returns>
//    public void Connect(String vUser)
//    {
//        Connect(0, vUser);
//    }
//    public void Connect(int vDBIndex, string vUser)
//    {
//        iConnection = CDataBase.GetConnection(vDBIndex, vUser);
//        iConnection.Open();
//        iCommand.Connection = iConnection;
//    }

//    /// <summary>
//    /// 断开iConnecton的连接
//    /// </summary>
//    /// <returns></returns>
//    /// 
//    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
//    public void DisConnect()
//    {
//        if (iTrans != null)
//        {
//            if (iTrans.Connection != null)
//                iTrans.Rollback();
//        }
//        if (iConnection != null) iConnection.Close();


//        _SqlCode = 0;
//        _SqlNRows = 0;

//    }
//    /// <summary>
//    /// 默认连接第一个配置
//    /// </summary>
//    /// <param name="as_dbuser"></param>
//    /// <returns></returns>
//    public static OracleConnection GetConnection(string as_dbuser)
//    {
//        return GetConnection(0, as_dbuser);
//    }

//    /// <summary>
//    /// 连接指定配置的数据库
//    /// </summary>
//    /// <param name="ai_DBIndex"></param>
//    /// <param name="as_dbuser"></param>
//    /// <returns></returns>
//    public static OracleConnection GetConnection(int ai_DBIndex, string as_dbuser)
//    {
//        if (GetDBUserCount(ai_DBIndex) <= 0)
//        {
//            GetDBUserData(ai_DBIndex, false);
//        }
//        KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? "" : as_dbuser.ToLower());
//        if (_dbuser.ContainsKey(ls_keyvalue))
//        {
//            OracleConnection con = new OracleConnection(_dbuser[ls_keyvalue]);
//            return con;
//        }
//        else
//        {
//            throw new CustomException(CustomExceptionType.Serious, "你使用的数据库用户" + as_dbuser + "不存在");
//        }
//    }
//    public static KeyValuePair<KeyValuePair<int, string>, string> GetDBUser(int ai_DBIndex, string as_dbuser)
//    {
//        if (GetDBUserCount(ai_DBIndex) <= 0)
//        {
//            GetDBUserData(ai_DBIndex, false);
//        }
//        KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? "" : as_dbuser.ToLower());
//        if (_dbuser.ContainsKey(ls_keyvalue))
//            return new KeyValuePair<KeyValuePair<int, string>, string>(ls_keyvalue, _dbuser[ls_keyvalue]);
//        else
//        {
//            throw new CustomException(CustomExceptionType.Serious, "你使用的数据库用户" + as_dbuser + "不存在");
//        }
//    }
//    #endregion

//    #region 返回DataTable或DataReader
//    /// <summary>
//    /// 生成OracleDataReader类型的iReader
//    /// </summary>
//    /// <param name="vSelectSql">要执行的sql语句</param>
//    /// <returns>OracleDataReader/null</returns>

//    public OracleDataReader SetReader(String vSelectSql)
//    {
//        iCommand.CommandText = vSelectSql;
//        _iReader = iCommand.ExecuteReader();
//        _SqlCode = 0;
//        _SqlNRows = -1; //不确定几条记录
//        return _iReader;
//    }


//    public DataTable SetDataTable(string vSql)
//    {
//        iCommand.CommandText = vSql;
//        if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
//        _iAdapter.SelectCommand = iCommand;
//        DataTable ldt = new DataTable();
//        _SqlNRows = _iAdapter.Fill(ldt);
//        _iDataTable = ldt;
//        _SqlCode = 0;
//        return _iDataTable;
//    }
//    public DataTable SetDataTable(string vSql, bool ForUpdate)
//    {
//        iCommand.CommandText = vSql;
//        if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
//        if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();
//        _iAdapter.SelectCommand = iCommand;
//        DataTable ldt = new DataTable();
//        _SqlNRows = _iAdapter.Fill(ldt);
//        _iDataTable = ldt;
//        _SqlCode = 0;
//        return _iDataTable;
//    }
//    public DataTable SetDataTable(string vSql, int startRecord, int maxRecords)
//    {
//        iCommand.CommandText = vSql;
//        if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
//        _iAdapter.SelectCommand = iCommand;
//        DataTable ldt = new DataTable();
//        _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);
//        _iDataTable = ldt;
//        _SqlCode = 0;
//        return _iDataTable;
//    }

//    public DataTable SetDataTable(string vSql, int startRecord, int maxRecords, bool ForUpdate)
//    {
//        iCommand.CommandText = vSql;
//        if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
//        if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();
//        _iAdapter.SelectCommand = iCommand;
//        DataTable ldt = new DataTable();
//        _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);
//        _iDataTable = ldt;
//        _SqlCode = 0;
//        return _iDataTable;
//    }
//    /// <summary>
//    /// 自动把iDataTable中改动，插入的数据同步到数据库
//    /// </summary>
//    /// <returns>同步的记录数</returns>
//    public int UpdateDataTable()
//    {
//        if (_iDataTable == null || _DataTableSelectCommand == null) return 0;
//        return UpdateDataTable(_iDataTable);
//    }
//    public int UpdateDataTable(DataTable aDataTable)
//    {
//        if (_iDataTable == null || _DataTableSelectCommand == null) return 0;
//        _iAdapter.SelectCommand = _DataTableSelectCommand;
//        OracleCommandBuilder builder = new OracleCommandBuilder(_iAdapter);
//        return _iAdapter.Update(aDataTable);
//    }
//    #endregion

//    #region 执行sql语句或存储过程
//    /// <summary>
//    /// 执行sql语句
//    /// </summary>
//    /// <param name="vSQL">SQL语句,</param>
//    /// <returns>select语句返回第一行第一例的值，其他返回null</returns>
//    public object ExeSQL(string vSQL)
//    {
//        string ls_sql;
//        object lo_obj = null;
//        ls_sql = vSQL.Trim();
//        try
//        {
//            iCommand.CommandType = CommandType.Text;
//            switch (ls_sql.Substring(0, 6).ToUpper())
//            {
//                case "SELECT":
//                    iCommand.CommandText = ls_sql;
//                    lo_obj = iCommand.ExecuteScalar();
//                    if (lo_obj == null)
//                    {
//                        _SqlCode = 0;
//                        _SqlNRows = 0;
//                    }
//                    else
//                    {
//                        if (lo_obj == DBNull.Value) lo_obj = null;
//                        _SqlCode = 0;
//                        _SqlNRows = 1;
//                    }
//                    break;
//                case "UPDATE":
//                    if (iTrans == null)
//                        iTrans = iConnection.BeginTransaction();
//                    else
//                    {
//                        if (iTrans.Connection == null)
//                            iTrans = iConnection.BeginTransaction();
//                    }
//                    iCommand.CommandText = vSQL;
//                    _SqlNRows = iCommand.ExecuteNonQuery();
//                    _SqlCode = 0;
//                    break;
//                case "INSERT":
//                    if (iTrans == null)
//                        iTrans = iConnection.BeginTransaction();
//                    else
//                    {
//                        if (iTrans.Connection == null)
//                            iTrans = iConnection.BeginTransaction();
//                    }
//                    iCommand.CommandText = vSQL;
//                    _SqlNRows = iCommand.ExecuteNonQuery();
//                    _SqlCode = 0;
//                    break;
//                case "DELETE":
//                    if (iTrans == null)
//                        iTrans = iConnection.BeginTransaction();
//                    else
//                    {
//                        if (iTrans.Connection == null)
//                            iTrans = iConnection.BeginTransaction();
//                    }
//                    iCommand.CommandText = vSQL;
//                    _SqlNRows = iCommand.ExecuteNonQuery();
//                    _SqlCode = 0;
//                    break;
//                default:
//                    iCommand.CommandText = vSQL;
//                    _SqlNRows = iCommand.ExecuteNonQuery();
//                    _SqlCode = 0;
//                    break;
//            }
//            return lo_obj;

//        }
//        catch (Exception e)
//        {
//            _SqlCode = -1;
//            _SqlNRows = 0;
//            _SqlErrorText = e.Message;
//            throw e;
//        }

//    }
//    public void ExecProcedure(string vProcedureName)
//    {
//        try
//        {
//            if (iTrans == null)
//                iTrans = iConnection.BeginTransaction();
//            else
//            {
//                if (iTrans.Connection == null)
//                    iTrans = iConnection.BeginTransaction();
//            }
//            iCommand.CommandType = CommandType.StoredProcedure;
//            iCommand.CommandText = vProcedureName;
//            _SqlNRows = iCommand.ExecuteNonQuery();
//            _SqlCode = 0;
//        }
//        catch (Exception e)
//        {
//            _SqlCode = -1;
//            _SqlNRows = 0;
//            _SqlErrorText = e.Message;
//            throw e;
//        }
//    }

//    #endregion
//    #region 事务处理
//    /// <summary>
//    /// 提交事务
//    /// </summary>
//    /// <returns>返回true成功；返回false失败</returns>
//    public void Commit()
//    {
//        if (iTrans != null)
//        {
//            if (iTrans.Connection != null)
//            {
//                iTrans.Commit();
//                _SqlCode = 0;
//                _SqlNRows = -1;

//            }
//        }
//        else//select 结束事物提交
//        {
//            if (iConnection != null && iConnection.State == ConnectionState.Open)
//            {
//                ExeSQL("commit");
//            }
//        }


//    }
//    /// <summary>
//    /// 回滚事务
//    /// </summary>
//    /// <returns>返回true成功；返回false失败</returns>
//    public void Rollback()
//    {
//        if (iTrans != null)
//        {
//            if (iTrans.Connection != null)
//            {
//                iTrans.Rollback();
//                _SqlCode = 0;
//                _SqlNRows = -1;

//            }
//        }
//    }
//    #endregion
//    #region 数据连接后的特殊服务，如获取时间、拼音五笔和序列值
//    /// <summary>
//    /// 获取数据库时间，失败则以应用服务器的时间代替
//    /// </summary>
//    /// <returns></returns>
//    public DateTime GetDBDateTime()
//    {
//        try
//        {
//            return (DateTime)ExeSQL("select sysdate from dual");
//        }
//        catch
//        {
//            return DateTime.Now;
//        }

//    }
//    /// <summary>
//    /// 获取拼音五笔
//    /// </summary>
//    /// <param name="yourstring"></param>
//    /// <param name="strpy"></param>
//    /// <param name="strwb"></param>
//    /// <returns></returns>
//    public void f_GetPyWb(string yourstring, out string strpy, out string strwb)
//    {
//        strpy = string.Empty;
//        strwb = string.Empty;
//        if (string.IsNullOrEmpty(yourstring))
//        {
//            return;
//        }
//        string strchar = string.Empty;
//        for (int i = 0; i < yourstring.Length; i++)
//        {

//            strchar = yourstring.Substring(i, 1);
//            SetReader("SELECT py,wb FROM xtgl_pywb WHERE xtgl_pywb.zf = '" + strchar + "'");
//            if (_iReader.HasRows)
//            {
//                _iReader.Read();
//                strpy = String.Concat(strpy, _iReader["py"].ToString());
//                strwb = String.Concat(strwb, _iReader["wb"].ToString());
//            }
//            _iReader.Close();
//        }

//    }
//    /// <summary>
//    /// 获取指定序列的NextValue
//    /// </summary>
//    /// <param name="vSequenceName">序列名</param>
//    /// <returns></returns>
//    public Int64 GetNextValue(string vSequenceName)
//    {
//        iCommand.CommandText = "select " + vSequenceName.Trim() + ".nextval from dual";
//        object lo_obj = iCommand.ExecuteScalar();
//        if (lo_obj == null)
//        {
//            _SqlCode = 0;
//            _SqlNRows = 0;
//            return -1;
//        }
//        else
//        {
//            _SqlCode = 0;
//            _SqlNRows = 1;
//            return Convert.ToInt64(lo_obj);
//        }
//    }
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="as_tablename"></param>
//    /// <param name="as_colname"></param>
//    /// <returns></returns>
//    public long GetNextValue(string as_tablename, string as_colname)
//    {
//        iCommand.CommandText = string.Format("select max({0}) from {1}", as_tablename, as_colname);
//        object lo_obj = iCommand.ExecuteScalar();
//        if (lo_obj == null || lo_obj == DBNull.Value)
//        {
//            _SqlCode = 0;
//            _SqlNRows = 1;
//            return 1;
//        }
//        else
//        {
//            _SqlCode = 0;
//            _SqlNRows = 1;
//            return (Convert.ToInt64(lo_obj) + 1);
//        }
//    }
//    #endregion

//    #region 静态函数 一个事务多条Sql语句
//    /// <summary>
//    /// 事务操作(不能用于Blob类型)
//    /// </summary>
//    /// <param name="sql">sql语句(不加;)字符串数组(定长)</param>
//    /// <returns>true/false</returns>
//    public static bool TransOperate(string[] as_sql, string as_dbuser)
//    {
//        int li_cnt = as_sql.Length;
//        if (li_cnt <= 0)
//        {
//            return false;
//        }
//        OracleConnection con = GetConnection(as_dbuser);
//        con.Open();
//        OracleTransaction trans = con.BeginTransaction();
//        OracleCommand cmd = new OracleCommand();
//        cmd.Connection = con;
//        try
//        {
//            for (int i = 0; i < li_cnt; i++)
//            {
//                if (as_sql[i] == "" || as_sql[i] == null) continue;
//                cmd.CommandText = as_sql[i];
//                cmd.ExecuteNonQuery();
//            }
//            trans.Commit();
//            return true;
//        }
//        catch
//        {
//            trans.Rollback();
//            return false;
//        }
//        finally
//        {
//            con.Close();
//        }
//    }
//    #endregion

//    internal void Connect()
//    {
//        throw new NotImplementedException();
//    }

//    internal OracleDataReader SetReader()
//    {
//        throw new NotImplementedException();
//    }

//    internal void Equals()
//    {
//        throw new NotImplementedException();
//    }

//    internal void ExeSQL()
//    {
//        throw new NotImplementedException();
//    }

//    internal class ml_dbuser
//    {
//        private int _dbindex;
//        private string _dbalias;
//        private string _name;
//        private string _alias;
//        private string _password;
//        private string _constr;
//        //属于web.config中配置的第几个数据库
//        public int DBIndex
//        {
//            get { return _dbindex; }
//            set { _dbindex = value; }
//        }
//        //系统内使用数据库名
//        public string DataBaseServerName
//        {
//            get { return _dbalias; }
//            set { _dbalias = value; }
//        }
//        //系统内使用DB用户名
//        public string Name
//        {
//            get { return _name; }
//            set { _name = value; }
//        }
//        //实际环境中数据库对应的DB用户名
//        public string Alias
//        {
//            get { return _alias; }
//            set { _alias = value; }
//        }
//        //DB用户的密码
//        public string Password
//        {
//            get { return _password; }
//            set { _password = value; }
//        }
//        //已经配置就绪的连接串
//        public string ConnectString
//        {
//            get { return _constr; }
//            set { _constr = value; }
//        }
//    }
//}

