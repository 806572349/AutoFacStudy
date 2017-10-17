using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperStudy
{
    public class RemarkAttribut : Attribute
    {
        
        private string _msg;
        public RemarkAttribut(string msg)
        {
            this._msg = msg;
        }

        public string msg { get { return _msg; } set { _msg = value; } }


    }



}
