using TLZZU.CodeBuild.Oracle.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Oracle
{
    public interface IBaseMaker
    {
        string Do(TableAttribute tableAttribute, Type p); 
    }
}
