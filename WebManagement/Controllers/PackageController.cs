﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Todo.Data.Sales;
using Todo.Domain.Sales;
using OfficeOpenXml;
using Todo.Data.SalesDto;
using System.Text;

namespace WebManagement.Controllers
{
    public class PackageController : Controller
    {
        enum Role
        {
            ADMIN = 1,
            STAFF = 2,
            SHOP = 3,
            CUSTOMER = 4,
        }

        IPackageManagement_Repository _packageRepository;
        public PackageController(IPackageManagement_Repository packageRepository) {
            _packageRepository = packageRepository;
        }

        public IActionResult Index()
        {   
         return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public async Task<ActionResult> TransportWithOrder_Read([DataSourceRequest] DataSourceRequest dsrequest)
        {

            var transportPack = await _packageRepository.GetAllPackage();

            // Check If Not Success -> return Error
            if (!transportPack.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { transportPack.message },
                });
            }
            
            return new JsonResult(transportPack.data.ToDataSourceResult(dsrequest));
        }

        public async Task<ActionResult> OrdersByUserId_Read(int id, [DataSourceRequest] DataSourceRequest dsrequest)
        {

            var orders = await _packageRepository.GetOrderByUserId(id);

            // Check If Not Success -> return Error
            if (!orders.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { orders.message },
                });
            }

            return new JsonResult(orders.data.ToDataSourceResult(dsrequest));
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            var file = Request.Form.Files[0];

            if (file != null && file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var userIdAndName = worksheet.Cells[row, 3].Text;
                            string[] userParts = new string[2];

                            if (!string.IsNullOrEmpty(userIdAndName) && userIdAndName.Contains(' '))
                            {
                                userParts = userIdAndName.Split([' '], 2);
                            }else
                            {
                                userParts[1] = "No name";
                            }
                            var user = new UserDto
                            {
                                user_code = userIdAndName,
                                first_name = userParts[1],
                                phone_number = worksheet.Cells[row, 15].Text,
                                role_id = (int)Role.CUSTOMER,
                            };

                            var addressIdAndWard = worksheet.Cells[row, 26].Text;
                            string[] addressParts = new string[2];
                            addressParts = addressIdAndWard.Split(['-'], 2);

                            var address = new AddressDto
                            {
                                address_code = addressParts[1],
                                province = worksheet.Cells[row, 24].Text,
                                city = worksheet.Cells[row, 25].Text,
                                ward = addressParts[0],
                                street = worksheet.Cells[row, 27].Text,
                                phone_number = worksheet.Cells[row, 15].Text,
                                postal_code = worksheet.Cells[row, 20].Text,
                            };

                            var order = new OrderDto
                            {
                                order_code = worksheet.Cells[row, 14].Text,
                                order_name = worksheet.Cells[row, 4].Text,
                                amount = float.TryParse(worksheet.Cells[row, 7].Text, out float Amount) ? Amount : 0,
                                customer_first_name = userParts[1],
                                customer_phone_number = worksheet.Cells[row, 15].Text,
                                customer_province = worksheet.Cells[row, 24].Text,
                                customer_city = worksheet.Cells[row, 25].Text,
                                customer_ward = addressParts[0],
                                customer_street = worksheet.Cells[row, 27].Text,
                                shop_first_name = worksheet.Cells[row, 30].Text,
                                shop_phone_number = worksheet.Cells[row, 31].Text,
                                shop_street = worksheet.Cells[row, 33].Text,
                                postal_code = worksheet.Cells[row, 20].Text,
                                payment_method = worksheet.Cells[row, 19].Text,
                                creation_time = DateTime.TryParse(worksheet.Cells[row, 28].Text, out DateTime CreationTime) ? CreationTime : new DateTime(),
                                shop_id = 1,
                            };

                            var transport = new ShippingDto
                            {
                                ship_code = worksheet.Cells[row, 1].Text,
                                ship_name = worksheet.Cells[row, 4].Text,
                                shipp_charges = float.TryParse(worksheet.Cells[row, 6].Text, out float ShippingCharges) ? ShippingCharges : 0,
                                cod = float.TryParse(worksheet.Cells[row, 7].Text, out float Cod) ? Cod : 0,
                                number_of_print = int.TryParse(worksheet.Cells[row, 10].Text, out int NumberOfPrint) ? NumberOfPrint : 0,
                                status = worksheet.Cells[row, 11].Text,
                                problem_type = worksheet.Cells[row, 13].Text,
                                weight = float.TryParse(worksheet.Cells[row, 17].Text, out float Weight) ? Weight : 0,
                                other_fee = float.TryParse(worksheet.Cells[row, 18].Text, out float OtherFee) ? OtherFee : 0,
                                hs_code = worksheet.Cells[row, 21].Text,
                                delivery_service = worksheet.Cells[row, 22].Text,
                                description = worksheet.Cells[row, 29].Text,
                            };

                            await _packageRepository.UploadExcel(user, address, order, transport);
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            return BadRequest("Invalid file");
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
