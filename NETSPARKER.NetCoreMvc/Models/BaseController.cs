using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NETSPARKER.API.Models;

namespace NETSPARKER.NetCoreMvc.Models
{
    public class BaseController : Controller
    {
        public UserModel CurrentUser
        {
            get
            {
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("NETSPARKERCurrentUser")))
                {
                    return null;
                }
                return JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("NETSPARKERCurrentUser"));


            }
        }
    }
}