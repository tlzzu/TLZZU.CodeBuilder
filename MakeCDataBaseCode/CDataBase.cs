//using Oracle.DataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Text;

//#region 数据库操作类
///// <summary>
///// 数据库操作类
///// </summary>
//internal class OracleHelper
//{
//    private static object objlock = new object();
//    private static string ConnString
//    {
//        get
//        {
//            return System.Configuration.ConfigurationSettings.AppSettings["oracleConn"];
//        }
//    }
//    /// <summary>
//    /// 获取数据库连接实体
//    /// </summary>
//    public static System.Data.OracleClient.OracleConnection Instant
//    {
//        get
//        {
//            if (System.Web.HttpContext.Current.Items["_oracleConn"] == null)
//            {
//                lock (objlock)
//                {
//                    if (System.Web.HttpContext.Current.Items["_oracleConn"] == null)
//                    {
//                        var temp = new System.Data.OracleClient.OracleConnection(ConnString);
//                        System.Web.HttpContext.Current.Items["_oracleConn"] = temp;
//                    }
//                }
//            }
//            var instant = System.Web.HttpContext.Current.Items["_oracleConn"] as System.Data.OracleClient.OracleConnection;
//            if (instant.State != System.Data.ConnectionState.Open)
//                instant.Open();
//            return instant;
//        }
//    }
//    /// <summary>
//    /// 放回序列
//    /// </summary>
//    /// <param name="vSequenceName"></param>
//    /// <returns></returns>
//    public static long GetNextValue(string vSequenceName)
//    {
//        var command = Instant.CreateCommand();
//        command.CommandText = string.Format("select {0}.nextval from dual",vSequenceName);
//        object lo_obj = command.ExecuteScalar();
//        return lo_obj == null ? -1 : Convert.ToInt64(lo_obj);
//    }

//    public static IList<T> GetDataItems<T>(OracleCommand command) where T : class, new()
//    {
//        var result = new List<T>();
//        var reader = command.ExecuteReader();
//        try
//        {
//            if (!reader.HasRows)
//            {
//                reader.Close();
//                return result;
//            }
//            Type typeFromHandle = typeof(T);
//            var inner = from i in Enumerable.Range(1, reader.FieldCount)
//                        select new
//                        {
//                            Name = reader.GetName(i - 1),
//                            Index = i - 1
//                        };
//            var enumerable = typeFromHandle.GetProperties().Join(inner, x => x.Name, x => x.Name, (x, y) => new { y.Index, x });
//            while (reader.Read())
//            {
//                T t = Activator.CreateInstance<T>();
//                foreach (var current in enumerable)
//                {
//                    if (reader[current.Index].GetType() != typeof(DBNull))
//                    {
//                        if (current.x.PropertyType.IsGenericType && current.x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
//                        {
//                            current.x.SetValue(t, new NullableConverter(current.x.PropertyType).ConvertFromString(reader[current.Index].ToString()), null);
//                        }
//                        else
//                            current.x.SetValue(t, Convert.ChangeType(reader[current.Index], current.x.PropertyType), null);
//                    }
//                }
//                result.Add(t);
//            }
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//        }
//        finally
//        {
//            reader.Close();
//        }
//        return result;
//    }
//}
//#endregion




#region 数据库访问
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class VariableInfo
{
    /// <summary>
    /// 应用程序级变量(配置文件和Application中变量的集合)
    /// </summary>
    public class ApplicationVar
    {
        private static string _applname;
        private static string _appldm;
        private static string _znqxglmkdm;//组内权限管理模块代码
        private static string _dwdm;
        private static string _dwmc;
        private static string _ywdwmc;  //英文单位名称
        private static string _servicephone;  //服务电话
        private static string _HaveGlobalAccessControl;
        private static long _ApplTotalLoginUserCount;
        private static long _OnLineUserCount;
        private static string _sbyxbs;
        private static string _sbyljgdm;//社保医疗机构代码
        private static string _nbyljgdm;//农保医疗机构代码
        private static string _nbqzjdz;//农保前置机网络地址：IP+端口号
        private static int? _xtggid;//系统公告信息ID号
        private static string _oaxxlb;//oa系统短信的消息类别
        private static System.Object _LockObj1 = new object();
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static string ApplName
        {
            get
            {
                if (string.IsNullOrEmpty(_applname))
                    _applname = System.Configuration.ConfigurationManager.AppSettings["applname"];
                return _applname;
            }
            set
            {
                _applname = value;
            }
        }
        /// <summary>
        /// oa系统短信的消息类别
        /// </summary>
        public static string OAXXLB
        {
            get
            {
                if (string.IsNullOrEmpty(_oaxxlb))
                    _oaxxlb = System.Configuration.ConfigurationManager.AppSettings["oaxxlb"];
                return _oaxxlb;
            }
            set
            {
                _oaxxlb = value;
            }
        }
        /// <summary>
        /// 应用程序代码
        /// </summary>
        public static string ApplDm
        {
            get
            {
                if (string.IsNullOrEmpty(_appldm))
                    _appldm = System.Configuration.ConfigurationManager.AppSettings["appldm"];
                return _appldm;
            }
            set
            {
                _appldm = value;
            }
        }
        /// <summary>
        /// 组内权限管理模块代码
        /// </summary>
        public static string ZNQXGLMKDM
        {
            get
            {
                if (string.IsNullOrEmpty(_znqxglmkdm))
                    _znqxglmkdm = System.Configuration.ConfigurationManager.AppSettings["znqxglmkdm"];
                return _znqxglmkdm;
            }
            set
            {
                _znqxglmkdm = value;
            }
        }
        /// <summary>
        /// 系统公告ID
        /// </summary>
        public static int? XTGGID
        {
            get
            {
                if (!_xtggid.HasValue)
                    _xtggid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["xtggid"]);
                return _xtggid;
            }
            set
            {
                _xtggid = value;
            }
        }
        /// <summary>
        /// 当前登录用户人数（即当前在线人数）
        /// *注意* 使用 OnLineUserCount++会导致ApplTotalLoginUserCount自动加一
        /// </summary>
        public static long OnLineUserCount
        {
            get
            {
                lock (_LockObj1)
                {
                    if (_OnLineUserCount < 0)
                        _OnLineUserCount = 0;
                    return _OnLineUserCount;
                }
            }
            set
            {
                lock (_LockObj1)
                {
                    if (_OnLineUserCount == value - 1)
                    {
                        _ApplTotalLoginUserCount++;
                    }
                    _OnLineUserCount = value;
                }
            }
        }
        /// <summary>
        /// 单位代码
        /// </summary>
        public static string dwdm
        {
            get
            {
                if (string.IsNullOrEmpty(_dwdm))
                    _dwdm = System.Configuration.ConfigurationManager.AppSettings["dwdm"];
                if (string.IsNullOrEmpty(_dwdm)) _dwdm = "01";
                return _dwdm;
            }
            set
            {
                _dwdm = value;
            }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public static string dwmc
        {
            get
            {
                if (string.IsNullOrEmpty(_dwmc))
                    _dwmc = System.Configuration.ConfigurationManager.AppSettings["dwmc"];
                if (string.IsNullOrEmpty(_dwmc)) _dwmc = "温州医院";
                return _dwmc;
            }
            set
            {
                _dwmc = value;
            }
        }
        /// <summary>
        /// 英文单位名称
        /// </summary>
        public static string ywdwmc
        {
            get
            {
                if (string.IsNullOrEmpty(_ywdwmc))
                    _ywdwmc = System.Configuration.ConfigurationManager.AppSettings["ywdwmc"];
                if (string.IsNullOrEmpty(_ywdwmc)) _ywdwmc = "WenZhou Hospital";
                return _ywdwmc;
            }
            set
            {
                _ywdwmc = value;
            }
        }
        /// <summary>
        /// 服务电话(错误页中用到)
        /// </summary>
        public static string servicephone
        {
            get
            {
                if (string.IsNullOrEmpty(_servicephone))
                    _servicephone = System.Configuration.ConfigurationManager.AppSettings["servicephone"];
                if (string.IsNullOrEmpty(_servicephone)) _servicephone = "没有登记服务电话";
                return _servicephone;
            }
            set
            {
                _servicephone = value;
            }
        }
        /// <summary>
        /// 全局页面访问控制模式
        /// "0" 不控制
        /// "1" 已经登记的页面按权限访问，没有登记则不控制访问
        /// "2" 已经登记的页面按权限访问，没有登记则禁止访问
        /// </summary>
        public static string GlobalAccessControl
        {
            get
            {
                if (string.IsNullOrEmpty(_HaveGlobalAccessControl))
                    _HaveGlobalAccessControl = System.Configuration.ConfigurationManager.AppSettings["GlobalAccessControl"];
                return _HaveGlobalAccessControl;
            }
            set
            {
                _HaveGlobalAccessControl = value;
            }
        }


        /// <summary>
        /// 农保医疗机构代码
        /// </summary>
        public static string NBYLJGDM
        {
            get
            {
                if (string.IsNullOrEmpty(_nbyljgdm))
                {
                    lock (_LockObj1)
                    {

                        _nbyljgdm = "1001";
                    }
                }
                return _nbyljgdm;
            }
        }
        /// <summary>
        /// 农保前置机IP地址及端口号
        /// </summary>
        public static string NBQZJDZ
        {
            get
            {
                if (string.IsNullOrEmpty(_nbqzjdz))
                {
                    lock (_LockObj1)
                    {

                        _nbqzjdz = "172.16.12.92:9999";
                    }
                }
                return _nbqzjdz;
            }
        }
    }


}
/// <summary>
/// 自定义异常类
/// </summary>
internal class CustomException : ApplicationException
{
    private string _ipAddress;  //客户端ip地址
    private string _czz;        //操作者
    private Int64 _idczz;       //操作者ID    
    private string _url;        //出错页面
    private string _userAgent;  //客户段浏览器代理信息
    private CustomExceptionType _exceptionType;
    private bool _loged = false;
    private string _hostname;
    protected void Init()
    {
        try
        {


            _exceptionType = CustomExceptionType.UnKnowException;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.Message);
        }
    }

    #region 构造函数
    public CustomException(CustomExceptionType exceptionType, string message, Exception innerException)
        : base(message, innerException)
    {
        Init();
        _exceptionType = exceptionType;
    }



    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
        Init();
    }

    public CustomException(CustomExceptionType exceptionType, string message)
        : base(message)
    {
        Init();
        _exceptionType = exceptionType;
    }

    public CustomException(string message)
        : base(message)
    {
        Init();
    }
    #endregion

    #region 属性

    /// <summary>
    /// 获取包括InnerException的所有异常信息
    /// </summary>
    public virtual string MessageAll
    {
        get
        {
            string ls_msg = base.Message;

            if (InnerException != null)
            {
                CustomException blex = InnerException as CustomException;
                if (blex != null)
                {
                    if (string.IsNullOrEmpty(ls_msg))
                        ls_msg = blex.MessageAll;
                    else
                        ls_msg = ls_msg + "," + blex.MessageAll;
                }
                else
                {
                    if (string.IsNullOrEmpty(ls_msg))
                        ls_msg = InnerException.Message;
                    else
                        ls_msg = ls_msg + ",错误原因：" + InnerException.Message;
                }
            }

            return ls_msg;
        }
    }


    /// <summary>
    /// 客户端IP地址
    /// </summary>
    public string IPAddress
    {
        get
        {
            return _ipAddress;
        }
    }

    /// <summary>
    /// 操作者
    /// </summary>
    public string Czz
    {
        get
        {
            return _czz;
        }
    }


    /// <summary>
    /// 操作者ID
    /// </summary>
    public Int64 IDCzz
    {
        get
        {
            return _idczz;
        }
    }

    /// <summary>
    /// 出错页面
    /// </summary>
    public string URL
    {
        get
        {
            return _url;
        }
    }

    /// <summary>
    /// 客户段浏览器代理信息
    /// </summary>
    public string UserAgent
    {
        get
        {
            return _userAgent;
        }
    }
    public string HostName
    {
        get
        {
            return _hostname;
        }
    }

    public string YYDM
    {
        get
        {
            return VariableInfo.ApplicationVar.ApplDm;
        }
    }
    /// <summary>
    /// 异常类型
    /// </summary>
    public CustomExceptionType ExceptionType
    {
        get
        {
            return _exceptionType;
        }
    }
    #endregion

}
/// <summary>
/// 异常类型
/// </summary>
internal enum CustomExceptionType
{



    //------------101-200为一般等级的异常类型--------//

    /// <summary>
    /// 验证异常
    /// </summary>
    Validate = 101,

    //----------------------------------------------//


    //------------201-300为严重等级的异常类型--------//

    /// <summary>
    /// 严重的异常
    /// </summary>
    Serious = 201,

    /// <summary>
    /// 数据库访问异常
    /// </summary>
    DataAccess = 202,

    /// <summary>
    /// 获取数据库数据异常
    /// </summary>
    Select = 203,

    /// <summary>
    /// 插入数据库数据异常
    /// </summary>
    Insert = 204,

    /// <summary>
    /// 更新数据库数据异常
    /// </summary>
    Update = 205,

    /// <summary>
    /// 删除数据库数据异常
    /// </summary>
    Delete = 206,

    /// <summary>
    /// 更新并发异常
    /// </summary>
    UpdateConcurrency = 207,

    /// <summary>
    /// 删除并发异常
    /// </summary>
    DeleteConcurrency = 208,


    //------------------------------------
    /// <summary>
    /// 未知异常
    /// </summary>
    UnKnowException = 999

}
internal partial class CDataBase : IDisposable
{

    public void ParametersClear()
    {
        this.Parameters.Clear();
    }

    public void ParametersAdd(string key, object value)
    {
        this.Parameters.Add(key, value);
    }

    public IList<T> GetDataItems<T>(string sql) where T : class, new()
    {
        try
        {
            this.iCommand.CommandText = sql;
            this._iReader = this.iCommand.ExecuteReader();
            if (!this._iReader.HasRows)
            {
                this._iReader.Close();
                return new List<T>();
            }
            Type typeFromHandle = typeof(T);
            var inner =
                from i in Enumerable.Range(1, this._iReader.FieldCount)
                select new
                {
                    Name = this._iReader.GetName(i - 1),
                    Index = i - 1
                };
            var enumerable = typeFromHandle.GetProperties().Join(inner, x => x.Name.ToUpper(), x => x.Name, (x, y) => new { y.Index, x });
            List<T> list = new List<T>();
            while (this._iReader.Read())
            {
                T t = Activator.CreateInstance<T>();
                foreach (var current in enumerable)
                {
                    //tempType = current;
                    //isNull = "isNull";
                    //isNull = this._iReader[current.Index].ToString();

                    if (this._iReader[current.Index].GetType() != typeof(DBNull))
                    {
                        try
                        {
                            if (current.x.PropertyType.IsGenericType && current.x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                current.x.SetValue(t, new NullableConverter(current.x.PropertyType).ConvertFromString(this._iReader[current.Index].ToString()), null);
                            }
                            else
                                current.x.SetValue(t, Convert.ChangeType(this._iReader[current.Index], current.x.PropertyType), null);

                        }
                        catch (Exception exe)
                        {
                            throw exe;
                            //Lenovo.Tool.Log4NetHelper.Error(exe);
                        }
                    }
                }
                list.Add(t);
            }
            this._iReader.Close();
            return list;

        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return GetDataItems<T>(sql);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #region 类成员定义
    //实例化后成员：Oracle连接
    private OracleConnection iConnection;    //Connect执行成功后：Oracle连接
    private OracleCommand iCommand;          //实例化后成员：Oracle命令
    private OracleCommand _DataTableSelectCommand;//SetDataTable后的可用成员：Oracle命令
    private OracleDataAdapter _iAdapter;      //SetDateSet：OracleAdapter
    private OracleDataReader _iReader;        //SetReader执行成功后：OracleReader
    private DataTable _iDataTable;
    private int _SqlNRows = -1;                 //ExeSQL执行后影响到的行数 -1表示未执行sql语句或不确定几条记录
    private int _SqlCode = -1;                 //ExeSQL执行成功还是失败，－1失败 0成功
    public string _SqlErrorText;

    private OracleTransaction iTrans;       //Connect执行成功后：事务处理对象  bm zsm mm constr
    //private static Dictionary<string, string> DbConnection = new Dictionary<string, string>();
    //private static Dictionary<string, string> DbConnStr = new Dictionary<string, string>();
    /// <summary>
    /// 数据库用户集合，《 <数据库号，用户名>,连接串》
    /// </summary>
    private static Dictionary<KeyValuePair<int, string>, string> _dbuser = new Dictionary<KeyValuePair<int, string>, string>();
    private bool disposed = false;
    #endregion
    #region 公有属性
    public OracleDataAdapter iAdapter
    {
        get
        {
            return _iAdapter;
        }
    }
    public OracleDataReader iReader
    {
        get
        {
            return _iReader;
        }
    }
    public DataTable iDataTable
    {
        get
        {
            return _iDataTable;//db.iDataTable[0][0].;
        }
    }
    public int SqlNRows
    {
        get
        {
            return _SqlNRows;
        }
    }
    public int SqlCode
    {
        get
        {
            return _SqlCode;
        }
    }
    public string SqlErrorText
    {
        get
        {
            return _SqlErrorText;
        }
    }
    /// 只读属性 OracleParameterCollection
    /// </summary>
    public OracleParameterCollection Parameters
    {
        get
        {
            return iCommand.Parameters;
        }

    }

    /// <summary>
    /// 返回datatable
    /// </summary>


    #endregion
    #region 构造函数和析构函数及资源的释放管理
    //.............开始实例化后的方法定义.....................
    /// <summary>
    /// 实例化iCommand,iAdapter,iDataSet三个成员
    /// </summary>
    public CDataBase()
    {
        iCommand = new OracleCommand();
        iCommand.BindByName = true;
        Connect(0, ConfigurationManager.AppSettings["DefaultUser"]);
    }
    /// <summary>
    /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数
    /// </summary>
    /// <param name="vUser">数据库用户名</param>
    public CDataBase(string vUser)
    {
        iCommand = new OracleCommand();
        iCommand.BindByName = true;
        Connect(0, vUser);

    }
    /// <summary>
    /// 实例化iCommand,iAdapter,iDataSet和iConnection三个成员,比起无参数的构造函数，相当与多执行了一个Connect函数
    /// </summary>
    /// <param name="vUser">数据库用户名</param>
    public CDataBase(int ai_DBIndex, string vUser)
    {
        iCommand = new OracleCommand();
        iCommand.BindByName = true;
        Connect(ai_DBIndex, vUser);

    }
    /// <summary>
    /// 释放托管与非托管资源
    /// </summary>
    /// <param name="disposing"></param>
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            //释放非托管资源
            DisConnect();

            //释放托管资源
            if (disposing)
            {
                iConnection.Dispose();
                iConnection = null;

                if (iTrans != null)
                {
                    iTrans.Dispose();
                    iTrans = null;
                }

                if (_iAdapter != null)
                {
                    _iAdapter.Dispose();
                    _iAdapter = null;
                }


                if (_iReader != null)
                {
                    _iReader.Dispose();
                    _iReader = null;
                }

                if (iCommand != null)
                {
                    iCommand.Dispose();
                    iCommand = null;
                }

                if (_iDataTable != null)
                {
                    _iDataTable.Dispose();
                    _iDataTable = null;
                }

            }

        }
        disposed = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~CDataBase()
    {
        Dispose(false);
    }
    #endregion

    #region 服务器初始化用
    /// <summary>
    /// 获取指定数据库的DBUser个数
    /// </summary>
    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
    /// <returns></returns>
    private static int GetDBUserCount(int ai_DBIndex)
    {
        int count = 0;
        foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)
        {
            if (ls_keyvalue.Key.Key == ai_DBIndex)
                count++;
        }
        return count;
    }
    /// <summary>
    /// 删除指定数据库的所有DBUser
    /// </summary>
    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
    private static void RemoveDBUser(int ai_DBIndex)
    {
        foreach (KeyValuePair<KeyValuePair<int, string>, string> ls_keyvalue in _dbuser)
        {
            if (ls_keyvalue.Key.Key == ai_DBIndex)
                _dbuser.Remove(ls_keyvalue.Key);
        }
    }

    private static string GenConnectString(string as_ds, string as_dbuser, string as_password)
    {
        string ls_constr;
        ls_constr = "Data Source=" + as_ds + ";User ID=" + as_dbuser + ";Password=" + as_password +
                    ";Pooling=false" +             //true，则请求从连接池返回，没连接池则自动创建,默认值为true
            ";Enlist=true";           　　//
        return "Data Source=" + as_ds + ";User ID=" + as_dbuser + ";Password=" + as_password + ";Pooling=true; Persist Security Info=True;";
    }
    /// <summary>
    /// 将字符转换为ＡＳＣ码
    /// </summary>
    /// <param name="asciiCode">字符</param>
    /// <returns>对应的ＡＳＣ码</returns>
    private static int Asc(string character)
    {
        if (character.Length == 1)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(character);
            int intAsciiCode = (int)bytes[0];
            return (intAsciiCode);
        }
        else
        {
            throw new Exception("字符的长度不对");
        }

    }
    /// <summary>
    /// 返回字符串的长度（包括汉字），汉字长度为2
    /// </summary>
    /// <param name="yourstring">源字符串</param>
    /// <returns>字符串</returns>
    private static int f_length(string yourstring)
    {
        if (string.IsNullOrEmpty(yourstring)) return 0;
        int len = yourstring.Length;
        byte[] sarr = System.Text.Encoding.Default.GetBytes(yourstring);
        return sarr.Length;
    }
    /// <summary>
    /// 从左边开始取len长个几个字符串
    /// </summary>
    /// <param name="yourstring">源字符串</param>
    /// <param name="len">指定长度</param>
    /// <returns>字符串</returns>
    private static string f_left(string yourstring, int ai_len)
    {
        if (ai_len <= 0) return string.Empty;
        if (string.IsNullOrEmpty(yourstring)) return string.Empty;
        int length = f_length(yourstring);
        if (length <= ai_len)
            return yourstring;
        else
        {
            int tmp = 0;
            int len = 0;
            int okLen = 0;
            int li_asc;
            string ls_return = string.Empty;
            for (int i = 0; i < length; i++)
            {
                //获取asc码
                li_asc = Asc(yourstring.Substring(i, 1));
                if (li_asc > 127)
                    tmp += 2;
                else
                    len += 1;
                okLen += 1;
                if (tmp + len == ai_len)
                {
                    ls_return = yourstring.Substring(0, okLen);
                    break;
                }
                else if (tmp + len > ai_len)
                {
                    ls_return = yourstring.Substring(0, okLen - 1);
                    break;
                }
            }
            return ls_return;
        }
    }
    /// <summary>
    /// 从指定文字开始取len长的字符串
    /// </summary>
    /// <param name="yourstring">源字符串</param>
    /// <param name="start">开始的位置</param>
    /// <param name="len">指定长度</param>
    /// <returns>字符串</returns>
    public static string f_mid(string yourstring, int start, int len)
    {
        if (len <= 0 || start < 0) return string.Empty;
        if (string.IsNullOrEmpty(yourstring)) return string.Empty;
        if (yourstring.Length < start) return string.Empty;
        if (yourstring.Length <= start + len - 1)
            return yourstring.Substring(start - 1);
        else
            return yourstring.Substring(start - 1, len);
    }
    /// <summary>
    /// 按固定数、随机数加密或解密
    /// </summary>
    /// <param name="as_pass"></param>
    /// <param name="ai_mod">ai_mod = 0 固定数加密,ai_mod = 1 随机数加密,ai_mod = 2 解密</param>
    /// <returns>加／解密后的字符串</returns>
    private static string f_passwd2(string as_pass, int ai_mod)
    {
        if (as_pass.Length > 23)
            return "-";
        int li_i, li_len, li_pos;
        string ls_cpu = "", ls_tmp = "", ls_ret = "";
        string[,] ls_pass = new string[14, 2];
        if (ai_mod == 0 || ai_mod == 1)
        {
            if (string.IsNullOrEmpty(as_pass)) return "";
            as_pass = f_left(as_pass, 10);
            if (ai_mod == 1)
            {
                ls_cpu = DateTime.Now.ToString("mmss");
            }
            else
            {
                ls_cpu = f_left(System.Convert.ToString(System.Convert.ToDouble(f_length(as_pass)) / 0.000412), 4);     //不能改变
            }
            li_len = f_length(as_pass);
            ls_ret = as_pass + ls_cpu;
            for (li_i = 1; li_i <= 4; li_i++)
            {
                li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));
                li_pos = li_pos % (li_len + 4);
                if (li_pos == 0) li_pos = 1;
                ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);
                ls_pass[li_pos - 1, 1] = "1";
                li_pos = (9 - li_pos) % (li_len + 4);
                if (li_pos == 0) li_pos = 1;
                ls_pass[li_pos - 1, 1] = "1";
                ls_tmp = ls_tmp + f_mid(ls_ret, li_pos, 1);
            }
            for (li_i = 1; li_i <= li_len + 4; li_i++)
            {
                if (ls_pass[li_i - 1, 1] == "1") continue;
                ls_tmp = ls_tmp + f_mid(ls_ret, li_i, 1);
            }
            ls_ret = System.Convert.ToString(li_len - 1) + ls_cpu + ls_tmp;
            return ls_ret;
        }
        else if (ai_mod == 2)
        {
            if (string.IsNullOrEmpty(as_pass)) return "";
            li_len = System.Convert.ToInt32(f_mid(as_pass, 1, 1)) + 1;
            ls_cpu = f_mid(as_pass, 2, 4);
            ls_ret = f_mid(as_pass, 6, f_length(as_pass));
            for (li_i = 1; li_i <= 4; li_i++)
            {
                li_pos = System.Convert.ToInt32(f_mid(ls_cpu, li_i, 1));
                li_pos = li_pos % (li_len + 4);
                if (li_pos == 0) li_pos = 1;
                ls_pass[li_pos - 1, 1] = "1";
                ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i - 1, 1);
                li_pos = (9 - li_pos) % (li_len + 4);
                li_pos = li_pos % (li_len + 4);
                if (li_pos == 0) li_pos = 1;
                ls_pass[li_pos - 1, 1] = "1";
                ls_pass[li_pos - 1, 0] = f_mid(ls_ret, 2 * li_i, 1);
            }
            li_pos = 9;
            for (li_i = 1; li_i <= li_len; li_i++)
            {
                if (ls_pass[li_i - 1, 1] == "1")
                {
                    //null 
                }
                else
                {
                    ls_pass[li_i - 1, 0] = f_mid(ls_ret, li_pos, 1);
                    li_pos++;
                }
                ls_tmp = ls_tmp + ls_pass[li_i - 1, 0];
            }
            return ls_tmp;
        }
        else
        {
            return as_pass;
        }
    }

    /// <summary>
    /// 生成指定数据库的DBUser的配置信息（必须是使用温一医DBUser结构的）
    /// </summary>
    /// <param name="ai_DBIndex">数据库索引号(在Web.config中配置的第ai_DBIndex个数据库)</param>
    /// <param name="ab_IsForceUpdated">是否强制重新获取信息</param>
    private static void GetDBUserData(int ai_DBIndex, Boolean ab_IsForceUpdated)
    {
        lock (_dbuser)
        {
            if (GetDBUserCount(ai_DBIndex) > 0 && ab_IsForceUpdated == false) //有数据而且不要求强制更新
            {
                return;
            }
            else
            {
                RemoveDBUser(ai_DBIndex);
            }
            string ls_constr, ls_ds, ls_dbuser, ls_pwd;
            NameValueCollection app = System.Configuration.ConfigurationManager.AppSettings;
            //取预连接信息
            ls_ds = app["dbservername" + ai_DBIndex.ToString()];
            ls_dbuser = app["predbuser"];
            ls_pwd = app["predbpwd"];
            ls_constr = GenConnectString(ls_ds, ls_dbuser, ls_pwd);
            //预连接数据库获取数据库用户信息
            using (OracleConnection con = new OracleConnection(ls_constr))
            {

                OracleCommand cmd = new OracleCommand("select sjkyhm,sjkmm from vi_sjkyh", con);
                con.Open();
                OracleDataAdapter iAdapter = new OracleDataAdapter();
                OracleDataReader odr = cmd.ExecuteReader();
                DataTable ldt = new DataTable();
                ldt.Columns.Add("name");
                ldt.Columns.Add("password");
                ldt.PrimaryKey = new DataColumn[] { ldt.Columns[0] };
                while (odr.Read())
                {
                    DataRow ldr = ldt.NewRow();
                    ldr[0] = f_passwd2(odr.GetString(0), 2).ToLower().Trim();
                    ldr[1] = f_passwd2(odr.GetString(1), 2);
                    ldt.Rows.Add(ldr);
                }
                odr.Close();
                foreach (DataRowView ldrv in ldt.DefaultView)
                {
                    ml_dbuser luser = new ml_dbuser();
                    luser.DBIndex = ai_DBIndex;
                    luser.DataBaseServerName = ls_ds;
                    luser.Name = ldrv[0].ToString();
                    luser.Password = ldrv[1].ToString();
                    luser.Alias = app[luser.Name];
                    if (string.IsNullOrEmpty(luser.Alias))
                        luser.ConnectString = GenConnectString(ls_ds, luser.Name, luser.Password);
                    else
                    {
                        DataRow ldr_row = ldt.Rows.Find(luser.Alias.ToLower());
                        if (ldr_row != null)
                            luser.Password = ldr_row[1].ToString();
                        luser.ConnectString = GenConnectString(ls_ds, luser.Alias, luser.Password);

                    }
                    _dbuser.Add(new KeyValuePair<int, string>(ai_DBIndex, luser.Name), luser.ConnectString);
                }

                if (con.State == ConnectionState.Open) con.Close();
            }
        }
    }
    /// <summary>
    /// 设置数据库用户及连接字符串于静态变量DbConnection中
    /// </summary>
    /// <returns>true/false</returns>
    public static bool SetDBUser()
    {
        try
        {
            GetDBUserData(0, false);
        }
        catch
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// 返回Oracle连接
    /// </summary>
    /// <param name="as_dbuser">数据库连接用户名</param>
    /// <returns>OracleConnection/null</returns>
    #endregion
    #region 连接、断开数据库、获取数据库连接
    /// <summary>
    /// 不带参数的实例化本类后，需执行本函数成功后，才能执行SetReader和SetDataSet
    /// </summary>
    /// <param name="vUser">数据库用户名</param>
    /// <returns>true成功，false异常</returns>
    public void Connect(String vUser)
    {
        Connect(0, vUser);
    }
    public void Connect(int vDBIndex, string vUser)
    {
        iConnection = CDataBase.GetConnection(vDBIndex, vUser);
        iConnection.Open();
        iCommand.Connection = iConnection;
    }

    /// <summary>
    /// 断开iConnecton的连接
    /// </summary>
    /// <returns></returns>
    /// 
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public void DisConnect()
    {
        if (iTrans != null)
        {
            if (iTrans.Connection != null)
                iTrans.Rollback();
        }
        if (iConnection != null) iConnection.Close();


        _SqlCode = 0;
        _SqlNRows = 0;

    }
    /// <summary>
    /// 默认连接第一个配置
    /// </summary>
    /// <param name="as_dbuser"></param>
    /// <returns></returns>
    public static OracleConnection GetConnection(string as_dbuser)
    {
        return GetConnection(0, as_dbuser);
    }

    /// <summary>
    /// 连接指定配置的数据库
    /// </summary>
    /// <param name="ai_DBIndex"></param>
    /// <param name="as_dbuser"></param>
    /// <returns></returns>
    public static OracleConnection GetConnection(int ai_DBIndex, string as_dbuser)
    {
        if (GetDBUserCount(ai_DBIndex) <= 0)
        {
            GetDBUserData(ai_DBIndex, false);
        }
        KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? "" : as_dbuser.ToLower());
        if (_dbuser.ContainsKey(ls_keyvalue))
        {
            OracleConnection con = new OracleConnection(_dbuser[ls_keyvalue]);
            return con;
        }
        else
        {
            throw new CustomException(CustomExceptionType.Serious, "你使用的数据库用户" + as_dbuser + "不存在");
        }
    }
    public static KeyValuePair<KeyValuePair<int, string>, string> GetDBUser(int ai_DBIndex, string as_dbuser)
    {
        if (GetDBUserCount(ai_DBIndex) <= 0)
        {
            GetDBUserData(ai_DBIndex, false);
        }
        KeyValuePair<int, string> ls_keyvalue = new KeyValuePair<int, string>(ai_DBIndex, as_dbuser == null ? "" : as_dbuser.ToLower());
        if (_dbuser.ContainsKey(ls_keyvalue))
            return new KeyValuePair<KeyValuePair<int, string>, string>(ls_keyvalue, _dbuser[ls_keyvalue]);
        else
        {
            throw new CustomException(CustomExceptionType.Serious, "你使用的数据库用户" + as_dbuser + "不存在");
        }
    }
    #endregion

    #region 返回DataTable或DataReader
    /// <summary>
    /// 生成OracleDataReader类型的iReader
    /// </summary>
    /// <param name="vSelectSql">要执行的sql语句</param>
    /// <returns>OracleDataReader/null</returns>

    public OracleDataReader SetReader(String vSelectSql)
    {
        try
        {
            iCommand.CommandText = vSelectSql;
            _iReader = iCommand.ExecuteReader();
            _SqlCode = 0;
            _SqlNRows = -1; //不确定几条记录
            return _iReader;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return SetReader(vSelectSql);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataTable SetDataTable(string vSql)
    {
        try
        {
            iCommand.CommandText = vSql;
            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
            _iAdapter.SelectCommand = iCommand;
            DataTable ldt = new DataTable();
            _SqlNRows = _iAdapter.Fill(ldt);
            _iDataTable = ldt;
            _SqlCode = 0;
            return _iDataTable;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return SetDataTable(vSql);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataTable SetDataTable(string vSql, bool ForUpdate)
    {
        try
        {
            iCommand.CommandText = vSql;
            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
            if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();
            _iAdapter.SelectCommand = iCommand;
            DataTable ldt = new DataTable();
            _SqlNRows = _iAdapter.Fill(ldt);
            _iDataTable = ldt;
            _SqlCode = 0;
            return _iDataTable;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return SetDataTable(vSql, ForUpdate);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataTable SetDataTable(string vSql, int startRecord, int maxRecords)
    {
        try
        {
            iCommand.CommandText = vSql;
            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
            _iAdapter.SelectCommand = iCommand;
            DataTable ldt = new DataTable();
            _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);
            _iDataTable = ldt;
            _SqlCode = 0;
            return _iDataTable;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return SetDataTable( vSql,  startRecord,  maxRecords);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable SetDataTable(string vSql, int startRecord, int maxRecords, bool ForUpdate)
    {
        try
        {
            iCommand.CommandText = vSql;
            if (_iAdapter == null) _iAdapter = new OracleDataAdapter();
            if (ForUpdate) _DataTableSelectCommand = (OracleCommand)iCommand.Clone();
            _iAdapter.SelectCommand = iCommand;
            DataTable ldt = new DataTable();
            _SqlNRows = _iAdapter.Fill(startRecord, maxRecords, ldt);
            _iDataTable = ldt;
            _SqlCode = 0;
            return _iDataTable;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return SetDataTable( vSql,  startRecord,  maxRecords,  ForUpdate);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// 自动把iDataTable中改动，插入的数据同步到数据库
    /// </summary>
    /// <returns>同步的记录数</returns>
    public int UpdateDataTable()
    {
        if (_iDataTable == null || _DataTableSelectCommand == null) return 0;
        return UpdateDataTable(_iDataTable);
    }
    public int UpdateDataTable(DataTable aDataTable)
    {
        if (_iDataTable == null || _DataTableSelectCommand == null) return 0;
        _iAdapter.SelectCommand = _DataTableSelectCommand;
        OracleCommandBuilder builder = new OracleCommandBuilder(_iAdapter);
        return _iAdapter.Update(aDataTable);
    }
    #endregion

    #region 执行sql语句或存储过程
    /// <summary>
    /// 执行sql语句
    /// </summary>
    /// <param name="vSQL">SQL语句,</param>
    /// <returns>select语句返回第一行第一例的值，其他返回null</returns>
    public object ExeSQL(string vSQL)
    {
        string ls_sql;
        object lo_obj = null;
        ls_sql = vSQL.Trim();
        try
        {
            iCommand.CommandType = CommandType.Text;
            switch (ls_sql.Substring(0, 6).ToUpper())
            {
                case "SELECT":
                    iCommand.CommandText = ls_sql;
                    lo_obj = iCommand.ExecuteScalar();
                    if (lo_obj == null)
                    {
                        _SqlCode = 0;
                        _SqlNRows = 0;
                    }
                    else
                    {
                        if (lo_obj == DBNull.Value) lo_obj = null;
                        _SqlCode = 0;
                        _SqlNRows = 1;
                    }
                    break;
                case "UPDATE":
                    if (iTrans == null)
                        iTrans = iConnection.BeginTransaction();
                    else
                    {
                        if (iTrans.Connection == null)
                            iTrans = iConnection.BeginTransaction();
                    }
                    iCommand.CommandText = vSQL;
                    _SqlNRows = iCommand.ExecuteNonQuery();
                    _SqlCode = 0;
                    break;
                case "INSERT":
                    if (iTrans == null)
                        iTrans = iConnection.BeginTransaction();
                    else
                    {
                        if (iTrans.Connection == null)
                            iTrans = iConnection.BeginTransaction();
                    }
                    iCommand.CommandText = vSQL;
                    _SqlNRows = iCommand.ExecuteNonQuery();
                    _SqlCode = 0;
                    break;
                case "DELETE":
                    if (iTrans == null)
                        iTrans = iConnection.BeginTransaction();
                    else
                    {
                        if (iTrans.Connection == null)
                            iTrans = iConnection.BeginTransaction();
                    }
                    iCommand.CommandText = vSQL;
                    _SqlNRows = iCommand.ExecuteNonQuery();
                    _SqlCode = 0;
                    break;
                default:
                    iCommand.CommandText = vSQL;
                    _SqlNRows = iCommand.ExecuteNonQuery();
                    _SqlCode = 0;
                    break;
            }
            return lo_obj;

        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        return ExeSQL( vSQL);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception e)
        {
            _SqlCode = -1;
            _SqlNRows = 0;
            _SqlErrorText = e.Message;
            throw e;
        }

    }
    public void ExecProcedure(string vProcedureName)
    {
        try
        {
            if (iTrans == null)
                iTrans = iConnection.BeginTransaction();
            else
            {
                if (iTrans.Connection == null)
                    iTrans = iConnection.BeginTransaction();
            }
            iCommand.CommandType = CommandType.StoredProcedure;
            iCommand.CommandText = vProcedureName;
            _SqlNRows = iCommand.ExecuteNonQuery();
            _SqlCode = 0;
        }
        //catch (Oracle.DataAccess.Client.OracleException oracleException)
        //{
        //    if (oracleException.Number == 3113)
        //    {
        //        ExecProcedure(vProcedureName);
        //    }
        //    else
        //    {
        //        throw oracleException;
        //    }
        //}
        catch (Exception e)
        {
            _SqlCode = -1;
            _SqlNRows = 0;
            _SqlErrorText = e.Message;
            throw e;
        }
    }

    #endregion
    #region 事务处理
    /// <summary>
    /// 提交事务
    /// </summary>
    /// <returns>返回true成功；返回false失败</returns>
    public void Commit()
    {
        if (iTrans != null)
        {
            if (iTrans.Connection != null)
            {
                iTrans.Commit();
                _SqlCode = 0;
                _SqlNRows = -1;

            }
        }
        else//select 结束事物提交
        {
            if (iConnection != null && iConnection.State == ConnectionState.Open)
            {
                ExeSQL("commit");
            }
        }


    }
    /// <summary>
    /// 回滚事务
    /// </summary>
    /// <returns>返回true成功；返回false失败</returns>
    public void Rollback()
    {
        if (iTrans != null)
        {
            if (iTrans.Connection != null)
            {
                iTrans.Rollback();
                _SqlCode = 0;
                _SqlNRows = -1;

            }
        }
    }
    #endregion
    #region 数据连接后的特殊服务，如获取时间、拼音五笔和序列值
    /// <summary>
    /// 获取数据库时间，失败则以应用服务器的时间代替
    /// </summary>
    /// <returns></returns>
    public DateTime GetDBDateTime()
    {
        try
        {
            return (DateTime)ExeSQL("select sysdate from dual");
        }
        catch
        {
            return DateTime.Now;
        }

    }
    /// <summary>
    /// 获取拼音五笔
    /// </summary>
    /// <param name="yourstring"></param>
    /// <param name="strpy"></param>
    /// <param name="strwb"></param>
    /// <returns></returns>
    public void f_GetPyWb(string yourstring, out string strpy, out string strwb)
    {
        strpy = string.Empty;
        strwb = string.Empty;
        if (string.IsNullOrEmpty(yourstring))
        {
            return;
        }
        string strchar = string.Empty;
        for (int i = 0; i < yourstring.Length; i++)
        {

            strchar = yourstring.Substring(i, 1);
            SetReader("SELECT py,wb FROM xtgl_pywb WHERE xtgl_pywb.zf = '" + strchar + "'");
            if (_iReader.HasRows)
            {
                _iReader.Read();
                strpy = String.Concat(strpy, _iReader["py"].ToString());
                strwb = String.Concat(strwb, _iReader["wb"].ToString());
            }
            _iReader.Close();
        }

    }
    /// <summary>
    /// 获取指定序列的NextValue
    /// </summary>
    /// <param name="vSequenceName">序列名</param>
    /// <returns></returns>
    public Int64 GetNextValue(string vSequenceName)
    {
        iCommand.CommandText = "select " + vSequenceName.Trim() + ".nextval from dual";
        object lo_obj = iCommand.ExecuteScalar();
        if (lo_obj == null)
        {
            _SqlCode = 0;
            _SqlNRows = 0;
            return -1;
        }
        else
        {
            _SqlCode = 0;
            _SqlNRows = 1;
            return Convert.ToInt64(lo_obj);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="as_tablename"></param>
    /// <param name="as_colname"></param>
    /// <returns></returns>
    public long GetNextValue(string as_tablename, string as_colname)
    {
        iCommand.CommandText = string.Format("select max({0}) from {1}", as_tablename, as_colname);
        object lo_obj = iCommand.ExecuteScalar();
        if (lo_obj == null || lo_obj == DBNull.Value)
        {
            _SqlCode = 0;
            _SqlNRows = 1;
            return 1;
        }
        else
        {
            _SqlCode = 0;
            _SqlNRows = 1;
            return (Convert.ToInt64(lo_obj) + 1);
        }
    }
    #endregion

    #region 静态函数 一个事务多条Sql语句
    /// <summary>
    /// 事务操作(不能用于Blob类型)
    /// </summary>
    /// <param name="sql">sql语句(不加;)字符串数组(定长)</param>
    /// <returns>true/false</returns>
    public static bool TransOperate(string[] as_sql, string as_dbuser)
    {
        int li_cnt = as_sql.Length;
        if (li_cnt <= 0)
        {
            return false;
        }
        OracleConnection con = GetConnection(as_dbuser);
        con.Open();
        OracleTransaction trans = con.BeginTransaction();
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = con;
        try
        {
            for (int i = 0; i < li_cnt; i++)
            {
                if (as_sql[i] == "" || as_sql[i] == null) continue;
                cmd.CommandText = as_sql[i];
                cmd.ExecuteNonQuery();
            }
            trans.Commit();
            return true;
        }
        catch
        {
            trans.Rollback();
            return false;
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    internal void Connect()
    {
        throw new NotImplementedException();
    }

    internal OracleDataReader SetReader()
    {
        throw new NotImplementedException();
    }

    internal void Equals()
    {
        throw new NotImplementedException();
    }

    internal void ExeSQL()
    {
        throw new NotImplementedException();
    }

    internal class ml_dbuser
    {
        private int _dbindex;
        private string _dbalias;
        private string _name;
        private string _alias;
        private string _password;
        private string _constr;
        //属于web.config中配置的第几个数据库
        public int DBIndex
        {
            get { return _dbindex; }
            set { _dbindex = value; }
        }
        //系统内使用数据库名
        public string DataBaseServerName
        {
            get { return _dbalias; }
            set { _dbalias = value; }
        }
        //系统内使用DB用户名
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //实际环境中数据库对应的DB用户名
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }
        //DB用户的密码
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        //已经配置就绪的连接串
        public string ConnectString
        {
            get { return _constr; }
            set { _constr = value; }
        }
    }
}
#endregion