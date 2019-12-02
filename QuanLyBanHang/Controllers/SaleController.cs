using ConnectDataBase;
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