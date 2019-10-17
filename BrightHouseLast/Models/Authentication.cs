using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;



namespace BrightHouseLast.Models
{
    public class Authentication
    {
        
        //2 step authentication that requires a one time password

        public class TestController : Controller
        {
            public object Session { get; private set; }
            public ActionResult Index()
            {

                return View();
            }


            public JsonResult SendOTP()
            {
                int otpValue = new Random().Next(100000, 999999);
                var status = "";
                try
                {
                    string recipient = IConfigurationManager.AppSettings["RecipientNumber"].ToString();
                    string APIKey = IConfigurationManager.AppSettings["APIKey"].ToString();

                    string message = "Your OTP Number is " + otpValue + " ( Sent By : Technotips-Ashish )";
                    String encodedMessage = HttpUtility.UrlEncode(message);

                    using (var webClient = new WebClient())
                    {
                        byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection(){

                                         {"apikey" , APIKey},
                                         {"numbers" , recipient},
                                         {"message" , encodedMessage},
                                         {"sender" , "TXTLCL"}});

                        string result = System.Text.Encoding.UTF8.GetString(response);

                        var jsonObject = JObject.Parse(result);

                        status = jsonObject["status"].ToString();

                        Session["CurrentOTP"] = otpValue;
                    }


                    return Json(status, JsonRequestBehavior.AllowGet);


                }
                catch (Exception)
                {

                    throw new NotImplementedException();

                }

            }

            public ActionResult EnterOTP()
            {
                return View();
            }

            [HttpPost]
            public JsonResult VerifyOTP(string otp)
            {
                bool result = false;

                string sessionOTP = Session["CurrentOTP"].ToString();

                if (otp == sessionOTP)
                {
                    result = true;

                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
           

           


        }
    }
}

