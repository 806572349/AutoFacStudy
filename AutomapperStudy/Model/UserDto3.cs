using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy
{
    public class UserDto3
    {
        public string Name2 { get; set; }
        public int Age { get; set; }
        
        public string NullText { get; set; }


    }

    public enum TypeEnum {
        [RemarkAttribut("成功")]
        成功=1,
        [RemarkAttribut("失败")]
        失败 =2
    }

   
}
