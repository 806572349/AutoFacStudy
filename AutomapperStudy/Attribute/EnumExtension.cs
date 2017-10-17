using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy
{
    public static class EnumExtension
    {
        public static string GetRemark(this Enum value) {
            string msg = string.Empty;
         Type type=value.GetType();
         FieldInfo fieldInfo=  type.GetField(value.ToString());
            try
            {
                object[] obj = fieldInfo.GetCustomAttributes(typeof(RemarkAttribut), false);
                RemarkAttribut re=(RemarkAttribut)obj.FirstOrDefault(a => a is RemarkAttribut);
                if (re == null)
                {
                    msg = fieldInfo.Name;
                }
                else {
                    msg = re.msg;
                }
                return msg;
            }
            catch (Exception)
            {

                throw;
            }
           



        }
    }
}
