//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TLZZU.CodeBuild.DemoDAL
//{
//    /// <summary>
//    /// 该文件为扩展方法。
//    /// </summary>
//    public partial class dl_xtgl_yhxx
//    {
//        /// <summary>
//        /// 可循环调用以NoRelease开头标签生成的方法
//        /// </summary>
//        public void Test1() {
//            using (CDataBase cdb = new CDataBase("xtgl3")) {
//                var user = this.GetUserByYHID(123456).FirstOrDefault();
//                user.yhxb = "张三";
//                //some code...
//                this.update(user.YHID, user.YHXM, user.YHID);
//                //do some code...
//                this.Delete(user.YHXM, user.YHID);
//                //cdb对象也可以让其他以nr_开头的dal类使用，节省oracle连接开销
//            }
        
//        }
//    }
//}
