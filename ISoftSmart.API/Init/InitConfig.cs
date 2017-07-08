using ISoftSmart.Core.IoC;
using ISoftSmart.Inteface.Implements;
using ISoftSmart.Inteface.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISoftSmart.API.Init
{
    public static class InitConfig
    {
        public static void InitIoC()
        {
            IoCFactory.Instance.CurrentContainer.RegisterType(typeof(ITestUsers), typeof(UserExtents));//注册接口
        }
      
    }
}