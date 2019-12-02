using ConnectDataBase;
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