using ISoftSmart.Inteface.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISoftSmart.Model.RB;
using ISoftSmart.Dapper.Helper;
using System.Data;
using System.Data.SqlClient;

namespace ISoftSmart.Inteface.Implements
{
    public class RedBagExtends : IRedBag
    {
        public RedBagExtends()
        { }
        public RBCreateBag GetBag(RBCreateBag bag)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@BagStatus",bag.BagStatus)
            };
            var result = Dapper.Helper.SQLHelper.QueryDataSet("select * from CreateBag where BagStatus=@BagStatus", sp, CommandType.Text);
            return result.JsonDeserialize<RBCreateBag>();
        }
    }
}
