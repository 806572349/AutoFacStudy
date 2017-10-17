using AutoFacStudy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Service
{
    public class StudyService : IStudy
    {
        public string getTest()
        {
            return "GET A OBJECT";
        }
    }
}
