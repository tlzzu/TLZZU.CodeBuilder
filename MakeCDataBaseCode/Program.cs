using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCDataBaseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(GetFatherPath(GetFatherPath(System.Environment.CurrentDirectory)), "CDataBase.cs");
            var resultPath = Path.Combine(GetFatherPath(GetFatherPath(System.Environment.CurrentDirectory)), "ResultCDataBase.cs");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("class Demo").
               AppendLine("{").
               AppendLine("    public static string GetDB()").
               AppendLine("    {").
               AppendLine("        System.Text.StringBuilder sb = new System.Text.StringBuilder();");
            using (StreamReader stream = new StreamReader(path))
            {
                string dh = "\\";
                dh += "\"";
                var str = stream.ReadLine();
                bool bo = true;
                while (bo)
                {
                    str = str.Contains("\"") ? str.Replace("\"", dh) : str;
                    sb.AppendLine(string.Format("        sb.AppendLine(\"{0}\");", str));

                    bo = !stream.EndOfStream;
                    str = stream.ReadLine();
                }
            }
            sb.AppendLine("        return sb.ToString();");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            //string result = sb.ToString();
            using (StreamWriter writer = new StreamWriter(resultPath)) {
                writer.Write(sb.ToString());
            }
            Console.WriteLine("---------生成结束------------");
            Console.ReadKey();
        }

        public static string GetFatherPath(string path)
        {
            return path.Substring(0, path.LastIndexOf("\\"));
        }
    }
}
