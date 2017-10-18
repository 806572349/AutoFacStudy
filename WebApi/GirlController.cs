using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinWebApi
{
   public  class GirlController: ApiController
    {
        //access http://localhost:3999/api/Test1  get method
        public IHttpActionResult GetTest(int id)
        {
            return Json(new { IsSuccess = true, Msg = "this is get method" });
        }
        public IHttpActionResult PostTest(dynamic queryData)
        {
            return Json(new { IsSuccess = true, Msg = "this is post method",Data=queryData });
        }
        public IHttpActionResult PutTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is put method" });
        }
        public IHttpActionResult DeleteTest()
        {
            return Json(new { IsSuccess = true, Msg = "this is delete method" });
        }
    }
}
