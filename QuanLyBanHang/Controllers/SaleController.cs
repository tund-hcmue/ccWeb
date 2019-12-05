using ConnectDataBase;
using OfficeOpenXml;
using Domain;
using Newtonsoft.Json;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class SaleController : CommandBaseController
    {
        private object rowstart;

        // GET: Sale
        public ActionResult SaleList(SaleListAction CommandAction)
        {
            var result = CommandAction.Execute();
            foreach (var item in result)
            {
                if(item.Status != 1)
                {
                    item.StatusShow = "Chưa xử lý";
                }
                else
                {
                    item.StatusShow = "Đã hoàn thành";
                }
                item.SaleDate = Convert.ToDateTime(item.SaleDate).ToString("yyyy-MM-dd");
            }
            this.ViewBag.Result = result;
            return View();
        }
        //
        public void ExportExcel(SaleListAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Title";
            ws.Cells["B1"].Value = "Title";

            ws.Cells["A2"].Value = "Table";
            ws.Cells["B2"].Value = "Sale";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMM yyyy} at {0:H: mm tt};", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã";
            ws.Cells["B6"].Value = "Ngày";
            ws.Cells["C6"].Value = "Khách hàng";
            ws.Cells["D6"].Value = "Nhân viên bán hàng";
            ws.Cells["E6"].Value = "Số lượng";
            ws.Cells["F6"].Value = "Tổng tiền";
            ws.Cells["G6"].Value = "Trạng thái";
            //ws.Cells["H6"].Value = "Ghi chú";

            int rowStart = 7;
            foreach (var item in this.ViewBag.Result)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.SaleId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = Convert.ToDateTime(item.SaleDate).ToString("dd/MM/yyyy hh:mm:ss");
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.CustomerName;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.EmployeeName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = Convert.ToInt32(item.Qty).ToString("#,##0");
                ws.Cells[string.Format("F{0}", rowStart)].Value = Convert.ToInt32(item.Total).ToString("#,##0");
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.StatusShow;
                //ws.Cells[string.Format("H{0}", rowStart)].Value = item.Note;
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
        public ActionResult SaleView(SaleViewAction CommandAction)
        {
            var result = CommandAction.Execute();
            this.ViewBag.Result = result;
            this.ViewBag.ResultJson = JsonExpando(Success(result));
            return View();
        }

        public ActionResult SaleInput(SaleGetByIdAction CommandAction)
        {
            
            this.ViewBag.Result = new List<dynamic>();
            if(CommandAction.EditFlag == "M")
            {
                this.ViewBag.Result = CommandAction.Execute();
                this.ViewBag.EditFlag = "M";
            }
            return View();
        }

        public ActionResult SaleChart(SaleListAction CommandAction)
        {
            this.ViewBag.Result = JsonExpando(CommandAction.Execute());
            return View();
        }


        public ActionResult ApiSaleItemGetById(SaleViewAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }
        [HttpPost]
        public ActionResult SaleItemExecuteSave(SaleItemExecuteSaveAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult SaleItemExecuteDeleteById(SaleItemExecuteDeleteByIdAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }
        [HttpPost]
        public ActionResult SaleExecuteSave(SaleExecuteSaveAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult SaleExecuteDeleteById(SaleExecuteDeleteByIdAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult SaleChangeStatus(SaleChangeStatusAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }
    }
}