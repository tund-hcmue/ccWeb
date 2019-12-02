using System;
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