using ConnectDataBase;
using OfficeOpenXml;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class EmployeeController : CommandBaseController
    {
        // GET: Employee
        public ActionResult EmployeeList(EmployeeListAction CommandAction,bool isPopup = false)
        {
            this.ViewBag.isPopup = isPopup;
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        //
        public void ExportExcel(EmployeeListAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Title";
            ws.Cells["B1"].Value = "Title";

            ws.Cells["A2"].Value = "Table";
            ws.Cells["B2"].Value = "Employee";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMM yyyy} at {0:H: mm tt};", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã";
            ws.Cells["B6"].Value = "Tên nhân viên";
            ws.Cells["C6"].Value = "Số điện thoại";
            ws.Cells["D6"].Value = "Email";
            ws.Cells["E6"].Value = "Địa chỉ";

            int rowStart = 7;
            foreach (var item in this.ViewBag.Result)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.EmployeeId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.EmployeeName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Phone;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Address;
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
        public ActionResult EmployeeInput(EmployeeInputAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeExecuteSave(EmployeeExecuteSaveAction CommandAction)
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
        public ActionResult EmployeeExecuteDeleteById(EmployeeExecuteDeleteByIdAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute(),"Xóa thành công!"));

            }
            catch (Exception ex)
            {

                return JsonExpando(Success(false, ex.Message));

            }
        }
    }
}