using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data.Queries.Sales
{
    public class Package
    {
        // Get Transport InnerJoin with Order User Address
        public static string GetAllPackageInfo => "SelectShippingWithOrder";

        public static string GetOrderByUserId => "";
    }
}
