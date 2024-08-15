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
            select 
                ship.id,
                ship_code,
                ship_name,
                product_type,
                status,
                problem_type,
                hs_code,
                delivery_service,
                description,
                number_of_print,
                cod,
                shipp_charges,
                weight,
                ship.other_fee,
                ord.id as order_id,
                order_code,
                order_name,
                amount,
                ord.other_fee,
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
        ";

        public static string GetOrderByUserId => @"
                         select
                            o.id,
                            s.id,
                            ship_code,
                            ship_name,
                            product_type,
                            status,
                            problem_type,
                            hs_code,
                            delivery_service,
                            description,
                            number_of_print,
                            cod,
                            shipp_charges,
                            weight,
                            s.other_fee,
                            order_code,
                            order_name,
                            amount,
                            o.other_fee,
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
                         from [Order] as o
                         join [Shipping] as s on o.id = s.order_id
                         where customer_id = @Id
                        ";
    }
}
