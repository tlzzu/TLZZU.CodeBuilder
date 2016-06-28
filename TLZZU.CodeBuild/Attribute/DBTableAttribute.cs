using System;

namespace TLZZU.CodeBuild.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DBTableAttribute : System.Attribute
    {
         public string Description { get; private set; }
         public string TableName
         {
             get;
             private set;
             //get
             //{
             //    return string.IsNullOrWhiteSpace(this.TableName)?System.Configuration.ConfigurationSettings.AppSettings[""]:this.TableName;
             //}
             //private set { this.TableName = value; }
         }

         public string BelongToDBUser { get; private set; }

        public DBTableAttribute(string tableName, string belongToUser, string description)
        {
            this.TableName = tableName;
            this.BelongToDBUser = belongToUser;
            this.Description = description;
        }
    }
}