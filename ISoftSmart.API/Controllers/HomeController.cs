using ISoftSmart.API.App_Start;
using ISoftSmart.Core.IoC;
using ISoftSmart.Core.RedisClient;
using ISoftSmart.Inteface.Implements;
using ISoftSmart.Inteface.Inteface;
using ISoftSmart.Model;
using ISoftSmart.Model.AD;
using ISoftSmart.Model.AD.My;
using ISoftSmart.Model.RB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace ISoftSmart.API.Controllers
{
    [RoutePrefix("api/test")]
    public class HomeController : BaseController, IRequiresSessionState
    {
        private static object _locker = new object();
        [Route("t")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            #region IOC
            // ISoftSmart.Core.IoC.IoCFactory.Instance.CurrentContainer.RegisterType(typeof(ITestUsers), typeof(UserExtents));//注册接口
            //var rt = ISoftSmart.Core.IoC.IoCFactory.Instance.CurrentContainer.Resolve<ITestUsers>();//使用接口
            //var tt = rt.Test2();//执行SQL返回JSON
            #endregion
            #region Redis
            //var db = RedisManager.Instance.GetDatabase();
            ////var result2 =  (int)RedisManager.Instance.GetDatabase().StringGet("abc123zzl");
            ////StackExchangeRedisExtensions.Set(db, "t", "testtttt");//操作字符
            //var usr = new UserInfo()
            //{
            //    Age = 1,
            //    ID = "2",
            //    Name = "22222"
            //};
            //List<UserInfo> list = new List<UserInfo>();
            //list.Add(usr);//生成一个list
            //StackExchangeRedisExtensions.Set(db, "t", list);//设置值
            //var getDbVal = StackExchangeRedisExtensions.Get<List<UserInfo>>(db, "t");
            //var usr1 = new UserInfo()
            //{
            //    Age = 1,
            //    ID = "33332",
            //    Name = "2222333的2"
            //};
            //getDbVal.Add(usr1);
            //StackExchangeRedisExtensions.Set(db, "t", getDbVal);//设置值
            ////StackExchangeRedisExtensions.Append(db, "t", usr);
            //var getDbVal1 = StackExchangeRedisExtensions.Get(db, "t");
            //var getkey = StackExchangeRedisExtensions.HasKey(db, "t1");
            ////StackExchangeRedisExtensions.Remove(db, "t");

            #endregion
            #region Redis队列
            //RedisQueueManager.Push()
            #endregion
            
            var rt = IoCFactory.Instance.CurrentContainer.Resolve<IRedBag>();//注册对象
            var rt1 = IoCFactory.Instance.CurrentContainer.Resolve<ITestUsers>();//注册对象
            RBCreateBag bag = IoCFactory.Instance.CurrentContainer.Resolve<RBCreateBag>();//注册对象
            var bag1 = IoCFactory.Instance.CurrentContainer.Resolve<AdUser>();//注册对象
            bag = rt.GetBag(bag);
            bag=rt.GetBag(bag);
            
            if (bag!=null)
            {
                var db = RedisManager.Instance.GetDatabase();
                if (StackExchangeRedisExtensions.HasKey(db, CacheKey.BagKey))
                {
                    var bagcache = StackExchangeRedisExtensions.Get(db, CacheKey.BagKey);
                    
                }
                else
                {
                   StackExchangeRedisExtensions.Set(db, CacheKey.BagKey, bag);
                }
            }
            else
            {

            }
            return Ok(new APIResponse<string>
            {
                Code = "SUCCESS",
                ResponseMessage = "获取列表成功！",
                Result = "111111"
            });

        }
        [Route("openbag")]
        [HttpGet]
        public async Task<IHttpActionResult> OpenBag(RBCreateBag bag)
        {
            //var rt = ISoftSmart.Core.IoC.IoCFactory.Instance.CurrentContainer.Resolve<IRedBag>();//使用接口
            //bag.CreateTime = DateTime.Now;
            //var res = await Task.Run(() => rt.GetBag());
            //lock (_locker)
            //{

            //}


            //var tt = ;//执行SQL返回JSON

            return Ok(new APIResponse<string>
            {
                Code = "SUCCESS",
                ResponseMessage = "获取列表成功！",
                Result = ""
            });
        }
        [Serializable]
        public class UserInfo
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
