using ConnectDataBase;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Facebook;
using System.Configuration;
using System.Net;

namespace QuanLyBanHang.Controllers
{
    public class LoginController : CommandBaseController
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Facebook
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
                var fb = new FacebookClient();
                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = ConfigurationManager.AppSettings["FbAppId"],
                    client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    code = code
                });
                var accessToken = result.access_token;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    //Get the info
                    fb.AccessToken = accessToken;
                    dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email,picture.width(480).height(480)");
                    
                    string email = me.email;
                    string userName = me.email;
                    string firstName = me.first_name;
                    string middleName = me.middle_name;
                    string lastName = me.last_name;

                    WebClient webClient = new WebClient();
                    string urlPicture = me.picture.data.url;

                    this.Session["Token"] = accessToken;
                    this.Session["Email"] = email;
                    this.Session["Name"] = firstName + " " + middleName + " " + lastName;
                    this.Session["Photo"] = urlPicture;
                    this.Session["LastLogin"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            }
                return Redirect("/");
}

        [HttpPost]
        public ActionResult CheckLogin(LoginExecuteSearchAction CommandAction)
        {
            try
            {
                var result = CommandAction.Execute();
                if (result.Count() == 1)
                {
                    this.Session["Email"] = CommandAction.Username;
                    this.Session["EmployeeName"] = result[0].EmployeeName;
                    this.Session["LastLogin"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    this.Session["Photo"] = "/img/demo/avatar/avatar1.jpg";
                
                    this.Session.Timeout = 10;
                    using (var cmd = new LoginUpdateRepository())
                    {
                        result[0].LastLogin = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        result[0].Token = this.Session.SessionID;
                        cmd.Item = result[0];
                        var res = cmd.Execute();
                        return JsonExpando(Success(res));

                    }
                }
                return JsonExpando(Success(false,"Tên tài khoản hoặc mật khẩu không đúng!"));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false, ex.Message));
            }
        }
        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                this.Session.Clear();
                this.Session.Abandon();
                return JsonExpando(Success(true));
            }
            catch (Exception ex)
            {
                return JsonExpando(Success(false,ex.Message));

            }
        }
    }
}