using ConnectDataBase;
using OfficeOpenXml;
using QuanLyBanHang.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class ProductController : CommandBaseController
    {
        // GET: Product
        public ActionResult ProductList(ProductListAction CommandAction,bool isPopup = false)
        {
            this.ViewBag.isPopup = isPopup;
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        //
        public void ExportExcel(ProductListAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Title";
            ws.Cells["B1"].Value = "Title";

            ws.Cells["A2"].Value = "Table";
            ws.Cells["B2"].Value = "Product";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMM yyyy} at {0:H: mm tt};", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã";
            ws.Cells["B6"].Value = "Tên nhà cung cấp";
            ws.Cells["C6"].Value = "Giá";
            ws.Cells["D6"].Value = "Barcode";

            int rowStart = 7;
            foreach (var item in this.ViewBag.Result)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ProductId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.ProductName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Price;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Barcode;
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
        public ActionResult PrintBarCode(ProductListAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        public ActionResult ProductInput(ProductInputAction CommandAction)
        {
            this.ViewBag.Result = new List<dynamic>();
            if(CommandAction.ProductId != null)
            {
                this.ViewBag.Result = CommandAction.Execute();
                this.ViewBag.EditFlag = "M";
            }
            using (var cmd = new ProductGroupSearchRepository())
            {
                this.ViewBag.Product = cmd.Exeucte();
            }
            return View();
        }
        [HttpPost]
        public ActionResult ProductExecuteDeleteById(ProductExecuteDeleteByIdAction CommandAction)
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
        public ActionResult ProductExecuteSave(ProductExecuteSaveAction CommandAction)
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
        public ActionResult ProductGroupList(ProductGroupListAction CommandAction,bool isPopup = false)
        {
            this.ViewBag.isPopup = isPopup;
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        public ActionResult ProductGroupInput(ProductGroupInputAction CommandAction)
        {
            this.ViewBag.Result = new List<dynamic>();
            if(CommandAction.ProductGroupId != null)
            {
                this.ViewBag.Result = CommandAction.Execute();
                this.ViewBag.EditFlag = "M";
            }
            return View();
        }

        [HttpPost]
        public ActionResult ProductGroupExecuteSave(ProductGroupExecuteSaveAction CommandAction)
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
        public ActionResult ProductGroupExecuteDeleteById(ProductGroupExecuteDeleteByIdAction CommandAction)
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
        public ActionResult ProductGetById(ProductGetByIdAction CommandAction)
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