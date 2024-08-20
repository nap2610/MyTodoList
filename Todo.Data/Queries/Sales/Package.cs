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

        /*
         ĐÂY LÀ QUERY CỦA SelectShippingWithOrder
         select 
			ship.id as ship_id,
			ship_code,
			ship_name,
			problem_type,
			status,
			hs_code,
			delivery_service,
			description,
			number_of_print,
			cod,
			shipp_charges,
			weight,
			ship.other_fee as ship_other_fee,
			ord.id as order_id,
			order_code,
			order_name,
			amount,
			ord.other_fee as order_other_fee,
			postal_code,
			payment_method,
			creation_time,
			customer_id,
			customer_first_name,
			customer_phone_number,
			customer_province,
			customer_city,
			customer_ward,
			customer_street,
			shop_id,
			shop_first_name,
			shop_street,
			shop_phone_number
		from [Shipping] as ship
		join [Order] as ord on ord.id = ship.order_id
         */






        public static string GetOrderByUserId => "";
    }
}
