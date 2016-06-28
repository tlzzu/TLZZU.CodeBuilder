using System;

namespace TLZZU.CodeBuild.Attribute
{
    public interface IBaseCodeMaker
    {
        /// <summary>
        /// 根据特性 返回生成的代码，可用StringBuilder 来拼接
        /// </summary>
        /// <param name="tableAttribute">需要这张表的信息</param>
        /// <param name="p">类型</param>
        /// <returns>拼接好的Code代码</returns>
        string CreateCode(DBTableAttribute tableAttribute,Type p); 
    }
}