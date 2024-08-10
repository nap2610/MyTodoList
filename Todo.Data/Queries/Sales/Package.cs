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
        public static string GetAllPackageInfo => @"
            SELECT
            transport_id,
            transport_name,
            shipping_charges,
            status,
            problem_type,
            cod,
            weight,
            other_fee,
            payment_method,
            delivery_service,
            description,
            postal_code,
            hs_code,
            ob.order_id,
            ob.shop_id,
            emp1.user_auto_id,
            emp1.name,
            emp1.phone,
            emp2.user_auto_id,
            emp2.name,
            emp2.phone,
            adr1.address_auto_id,
            adr1.province,
            adr1.city,
            adr1.ward,
            adr1.street,
            adr2.address_auto_id,
            adr2.ward,
            adr2.street
            FROM Transport_Bill as tp
            inner join Order_Bill ob on tp.order_id = ob.order_id
            inner join Employee as emp1 on ob.customer_id = emp1.user_auto_id 
            inner join Employee as emp2 on ob.shop_id = emp2.user_auto_id 
            inner join Address as adr1 on adr1.address_auto_id = emp1.user_auto_id
            inner join Address as adr2 on adr2.address_auto_id = emp2.user_auto_id
        ";


    }
}
