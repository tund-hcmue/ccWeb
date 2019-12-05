using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using ConnectDataBase;
using Newtonsoft.Json;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class CustomerController : CommandBaseController
    {
        // GET: Customer
        public ActionResult CustomerList(CustomerListAcion CommandAction, bool isPopup = false)
        {
            this.ViewBag.isPopup = isPopup;
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        //
        public void ExportExcel(CustomerListAcion CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Title";
            ws.Cells["B1"].Value = "Title";

            ws.Cells["A2"].Value = "Table";
            ws.Cells["B2"].Value = "Customer";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMM yyyy} at {0:H: mm tt};", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã";
            ws.Cells["B6"].Value = "Tên khách hàng";
            ws.Cells["C6"].Value = "Email";
            ws.Cells["D6"].Value = "Số điện thoại";

            int rowStart = 7;
            foreach (var item in this.ViewBag.Result)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.CustomerId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.CustomerName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Phone;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        //
        public ActionResult CustomerInput(CustomerInputAction CommandAction)
        {
            this.ViewBag.Result = new List<dynamic>();
            if (CommandAction.CustomerId != null)
            {
                this.ViewBag.Result = CommandAction.Execute();
                this.ViewBag.EditFlag = "M";
            }
            return View();
        }
        [HttpPost]
        public ActionResult CustomerExecuteSave(CustomerExecuteSaveAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));

            }
            catch (Exception ex)
            {

                return JsonExpando(Success(false,ex.Message));
            }

        }
        [HttpPost]
        public ActionResult CustomerExecuteDeleteById(CustomerExecuteDeleteByIdAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false,ex.Message));
            }
            
        }
    }
}