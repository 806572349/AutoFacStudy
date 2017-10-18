using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWinConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Install-Package Microsoft.Owin.SelfHost -Pre
            //控制台托管OWIN
            using (WebApp.Start<Startup1>("http://localhost:5000")) {
                Console.WriteLine("enter");
                Console.ReadLine();
            }
        }
    }
}
