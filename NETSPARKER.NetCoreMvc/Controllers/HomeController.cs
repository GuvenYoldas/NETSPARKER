using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.API.Models;
using NETSPARKER.NetCoreMvc.Models;
using NETSPARKER.NetCoreMvc.Helpers;
using NETSPARKER.Common.Helpers;



namespace NETSPARKER.NetCoreMvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger
                              )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (CurrentUser == null)
            {
                return RedirectToAction(nameof(Login));
            }
         
            HttpResponseMessage responseMessage = NetsparkerAPI.client.GetAsync($"api/DownTime/GetProductList/").Result;
            var resultModel = responseMessage.Content.ReadAsAsync<JsonResultModel<List<ProductModel>>>().Result;

            List<ProductModel> oModel = resultModel.Data ?? new List<ProductModel>();

            return View(oModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Create(string id)
        {
            int nId = 0;
            JsonResultModel<ProductModel> resultModel = new JsonResultModel<ProductModel>();
            ProductViewModel oModel = new ProductViewModel();

            Int32.TryParse(id, out nId);
            ViewBag.Title = nId == 0 ? "Create" : "Edit";

            if (nId > 0)
            {
                //burada ID yi de crpyt etmek gerekir. veya user ın compnyId si bu kaydın companyId si ile aynı mı vs bakmak gerekir. Yoksa herkes herkesin kaydını siler.
                // mülakat olduğu için es geçiyorum. projeye son gün başladım daha küçük birşey bekliyordum :)
                HttpResponseMessage responseMessage = NetsparkerAPI.client.GetAsync($"api/DownTime/GetProductById/?id=" + nId).Result;
                resultModel = responseMessage.Content.ReadAsAsync<JsonResultModel<ProductModel>>().Result;

                List<NotificationTypes> oTypesList = new List<NotificationTypes>();

                if (resultModel.Data != null && resultModel.Data.ID > 0)
                {
                    foreach (var item in resultModel.Data.ProductNotification)
                    {
                        oTypesList.Add((NotificationTypes)(item.IDNotificationType));
                    }


                    oModel.id = resultModel.Data.ID;
                    oModel.Name = resultModel.Data.Name;
                    oModel.Url = resultModel.Data.Url;
                    oModel.Interval = resultModel.Data.Interval;
                    
                }
                oModel.NotificationTypes = oTypesList;
            }

            return View(oModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id, Name,Url,Interval,NotificationTypes")] ProductViewModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JsonResultModel<ProductModel> resultModel = new JsonResultModel<ProductModel>();
                    ProductModel oInput = new ProductModel();

                    List<ProductNotificationModel> oProductNotificationModelList = new List<ProductNotificationModel>();
                    if (input.NotificationTypes != null && input.NotificationTypes.Count > 0)
                    {
                        foreach (NotificationTypes item in input.NotificationTypes)
                        {
                            oProductNotificationModelList.Add(new ProductNotificationModel
                            {
                                IDNotificationType = (int)item,
                                IDCompany = 1,
                                IDMonitoringInterval = input.Interval,
                                IsActive = "E"

                            });
                        }

                    }

                    if (input.id.HasValue && input.id.Value > 0)
                    {
                        oInput.ID = input.id.Value;
                        oInput.UpdatedBy = CurrentUser.ID.ToString();
                        oInput.UpdatedDateOffsetUtc = DateTime.Now;
                    }

                    oInput.Name = input.Name;
                    oInput.Url = input.Url;
                    oInput.ProductNotification = oProductNotificationModelList;
                    oInput.IDCompany = 1;
                    oInput.Interval = input.Interval;
                    oInput.IsActive = "E";
                    oInput.NextMonitorTime = CommonGeneral.GetNextIntervalMonitoringTime((IntervalMonitoring)input.Interval);
          
                    HttpResponseMessage responseMessage = NetsparkerAPI.client.PostAsJsonAsync($"api/DownTime/InsertProduct/", oInput).Result;
                    resultModel = responseMessage.Content.ReadAsAsync<JsonResultModel<ProductModel>>().Result;
                
                    return RedirectToAction(nameof(Index));
                }
                _logger.Log(LogLevel.Error, "deneme", "denendi");
                return View(input);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                return RedirectToAction(nameof(Error));
            }

        }


    }
}
