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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace NETSPARKER.NetCoreMvc.Controllers
{
    public class JsonHelperController : BaseController
    {


        public IActionResult RegisterUser([FromBody]registerUserModel input)
        {
            JsonResultModel<UserModel> resultModel = new JsonResultModel<UserModel>();
        

            try
            {
                UserModel oInput = new UserModel();
                oInput.Email = input.email;
                oInput.SaltString = Cryptography.RandomString(16);
                oInput.PasswordHash = Cryptography.Encrypt(input.pass, oInput.SaltString);
                oInput.IDCompany = 1;
                oInput.UserType = 1;
                oInput.IsActive = "E";

                HttpResponseMessage responseMessage = NetsparkerAPI.client.PostAsJsonAsync($"api/DownTime/CreateUser/", oInput).Result;
                resultModel = responseMessage.Content.ReadAsAsync<JsonResultModel<UserModel>>().Result;
                if (resultModel.Success == 0)
                {
                    HttpContext.Session.SetString("NETSPARKERCurrentUser", JsonConvert.SerializeObject(resultModel.Data));
                }
            }
            catch (Exception exp)
            {
                resultModel.Success = -1;
                resultModel.Message = exp.Message;
            }
            
         
        
            return Json(resultModel);
        }

        public IActionResult LoginUser(string email, string pass)
        {
            JsonResultModel<UserModel> resultModel = new JsonResultModel<UserModel>();


            HttpResponseMessage responseMessage = NetsparkerAPI.client.GetAsync($"api/DownTime/LoginUser/?email=" + email + "&pass=" + pass).Result;
            resultModel = responseMessage.Content.ReadAsAsync<JsonResultModel<UserModel>>().Result;
            if (resultModel.Success == 0)
            {
                HttpContext.Session.SetString("NETSPARKERCurrentUser", JsonConvert.SerializeObject(resultModel.Data));
            }
            return Json(resultModel);
        }

        public IActionResult DeleteProduct(int id) {

            JsonResultModel<int> oModel = new JsonResultModel<int>();
            HttpResponseMessage responseMessage = NetsparkerAPI.client.GetAsync($"api/DownTime/DeleteProduct/?id=" + id.ToString()).Result;
            oModel = responseMessage.Content.ReadAsAsync<JsonResultModel<int>>().Result;

            return Json(oModel);
        }
    }
}