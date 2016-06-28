using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TLZZU.CodeBuild.Attribute;

namespace TLZZU.CodeBuild.DemoModel
{

    [DBTable("yl_yhgt_yhgtjl", "", "医患沟通记录")]
    [ViewSelect("GetCountByBRBH", "select count(*) from yl_yhgt_yhgtjl where brbh=:brbh  order by jlsj", "获取医患沟通记录数（病人用）")]
    [ViewSelect("GetJLByBRBH", "select Brbh,Jlid,Jlsj,Bt,Nr,ysyhid from yl_yhgt_yhgtjl where brbh=:brbh  order by jlsj", "获取医患沟通记录（病人用）")]
    [ViewPaging("GetJLByBRBHPaging", "Brbh,Jlid,Jlsj,Bt,Nr,ysyhid", "jlsj", "brbh=:brbh", "获取医患沟通记录（病人用）(分页从0开始)")]
    [ViewSelect("GetCountByYSYHID", "select count(*) from yl_yhgt_yhgtjl where YSYHID=:YSYHID  order by jlsj", "获取医患沟通记录数（医生用）")]
    [ViewSelect("GetJLByYSYHID", "select Brbh,Jlid,Jlsj,Bt,Nr,ysyhid from yl_yhgt_yhgtjl where YSYHID=:YSYHID  order by jlsj", "获取医患沟通记录（医生用）")]
    [ViewSelect("GetJLByBRBHAndYSYHID", "select Brbh,Jlid,Jlsj,Bt,Nr,ysyhid from yl_yhgt_yhgtjl where brbh=:brbh and ysyhid=:ysyhid order by jlsj desc", "获取医患沟通记录根据病人编号和医生用户id（病人用）")]
    [ViewSelect("GetJLByBRBHAndJLID", "select Brbh,Jlid,Jlsj,Bt,Nr,ysyhid from yl_yhgt_yhgtjl where brbh=:brbh and jlid=:jlid order by jlsj", "获取医患沟通记录根据病人编号和记录id（病人用）")]
    [ViewSelect("GetMaxJLID", "select max(jlid)+1 JLID from yl_yhgt_yhgtjl where brbh=:brbh", "获取添加沟通记录的jlid", false)]
    [TableAdd("AddGTJL", "添加沟通记录")]
    public class m_yl_yhgt_yhgtjl
    {
        public string BRBH { get; set; }
        public long JLID { get; set; }
        public DateTime JLSJ { get; set; }
        public string BT { get; set; }
        public string NR { get; set; }
        public long YSYHID { get; set; }
        [FieldNoDB]
        public int SFHF { get; set; }
        [FieldNoDB]
        public string URL { get; set; }
        [FieldNoDB]
        public string KSMC { get; set; }
        [FieldNoDB]
        public string YSXM { get; set; }

    }
    


    //[ViewSelect("GetUserByYHIDError", "select* from xtgl_yhxx where yhid=:yhid ", "根据用户id获取用户信息")]
    //[ViewSelect("GetUserByYHIDError2", "selec * from xtgl_yhxx where yhid=:yhid ", "根据用户id获取用户信息")]
    //[TableDelete("DeleteError", "yhxm=:yhxm age=23 and yhid=:yhid ", "删除")]

    [DBTable("xtgl_yhxx", "xtgl3", "用户信息")]
    [ViewSelect("GetUserByYHID", "select * from xtgl_yhxx where yhid=:yhid ", "根据用户id获取用户信息")]
    [NoReleaseViewSelect("GetUserByYHID", "select * from xtgl_yhxx where yhid=:yhid ", "根据用户id获取用户信息")]
    [TableAdd]
    [NoReleaseTableAdd]
    [TableDelete("Delete", "yhxm=:yhxm and age=23 and yhid=:yhid ", "删除")]
    [NoReleaseTableDelete("Delete", "yhxm=:yhxm and age=23 and yhid=:yhid ", "删除")]
    [TableUpdate("update", "yhid,yhxm", "name='tongl' and yhid=:yhid", "更新操作")]
    [NoReleaseTableUpdate("update", "yhid,yhxm", "name='tongl' and yhid=:yhid", "更新操作")]
    [Test]
    [ViewPaging("FirstPageing","yhid,yhxb","yhxm","1=1 and yhid=:yhid","分页查看")]
    public class m_xtgl_yhxx
    {
        [FieldSeq("test_seq")]
        public long YHID { get; set; }

        public string YHXM { get; set; }

        [FieldNoDB]
        public string yhxb { get; set; }
    }
}
