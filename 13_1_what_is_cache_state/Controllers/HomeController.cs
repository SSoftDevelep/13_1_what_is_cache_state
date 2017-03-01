using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_1_what_is_cache_state.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //HttpContext.Cache["ad"] = "Brad Pitt";
            //HttpContext.Cache.Remove("ad"); //silme islemi

            HttpContext.Cache.Add("ad", "Brad Pitt", null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 10),System.Web.Caching.CacheItemPriority.Normal,CacheItemExpired);  //ölüm tarihi yok(NoAbsoulteExpiration) ve son erisimden 10 sn sonra temizlencek.
            //HttpContext.Cache.Add("ad", "Brad Pitt", null,new DateTime(2017,3,1,15,43,0), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal,CacheItemExpired); //belirtilen tarihte ölcek.

           
            return View();
        }


        private void CacheItemExpired(string key,object value,System.Web.Caching.CacheItemRemovedReason reason)
        {
            //Mail de atilabilir ..
            System.IO.File.WriteAllText(Server.MapPath("~/cache-expired-note.txt"), $"{key} cache item and {value.ToString()} cache item value are expired. Reason : {reason.ToString()}");
        }


        public ActionResult Index2()
        {
            return View();
        }


        public ActionResult Index3()
        {
            HttpContext.Cache.Remove("ad");
            return View();
        }
    }
}