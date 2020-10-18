using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSPARKER.NetCoreMvc.Models
{
    public class registerUserModel
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string passConfirm { get; set; }
    }

    public class loginUser
    {
        public string email { get; set; }
        public string pass { get; set; }
    }
}
