using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLZZU.CodeBuild.Oracle.Util
{
    internal class FieldTypeModel {
        public Type BaseType { get; set; }

        public bool IsNull { get; set; }

        public string TypeName { get; set; }

    }
    internal class FieldType
    {

        /// <summary>
        /// 如果是null返回true
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNull(Type type) {
            return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }
        public static FieldTypeModel Format(System.Reflection.PropertyInfo propertyInfo)
        {
            FieldTypeModel model = new FieldTypeModel();
            model.IsNull = IsNull(propertyInfo.PropertyType);
            model.BaseType = model.IsNull ? propertyInfo.PropertyType.GenericTypeArguments[0] : propertyInfo.PropertyType;
            model.TypeName = propertyInfo.Name;
            return model;
        }

        public static string ConvertTypeToString(Type type) {
            return type.FullName;
            //if (type.Equals(typeof(int))) {
            //    return "int";
            //}
            //else if (type.Equals(typeof(long))) {
            //    return "long";
            //}
            //else if (type.Equals(typeof(short))) {
            //    return "short";
            //}
            //else if (type.Equals(typeof(string))) {
            //    return "string";
            //}
            //else if (type.Equals(typeof(DateTime))) {
            //    return "DateTime";
            //}
            //else if (type.Equals(typeof(decimal))) {
            //    return "decimal";
            //}
            //else if (type.Equals(typeof(double))) {
            //    return "double";
            //}
            //else if (type.Equals(typeof(bool))) {
            //    return "bool";
            //}
            //else if (type.Equals(typeof(byte))) {
            //    return "byte";
            //}
            //else if (type.Equals(typeof(sbyte)))
            //{
            //    return "sbyte";
            //}
            //else if (type.Equals(typeof(char)))
            //{
            //    return "char";
            //}
            //else if (type.Equals(typeof(float)))
            //{
            //    return "float";
            //}
            //else if (type.Equals(typeof(uint)))
            //{
            //    return "uint";
            //}


            
        } 


    }
}
