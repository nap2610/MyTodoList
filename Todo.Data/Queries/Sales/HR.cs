using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data.Queries.Sales
{
    public class HR
    {
		public static string getAllCustomerWithOrder = @"select 
	                        u.id,
	                        first_name,
	                        phone_number,
	                        o.id,
                            customer_street,
	                        order_name,
	                        amount,
	                        payment_method,
	                        creation_time,
	                        shop_id,
	                        shop_first_name,
	                        shop_phone_number,
	                        shop_street
                        from [User] as u
                        join [Order] as o on u.id = o.customer_id        
                        where u.role_id = 4";

    }
}
