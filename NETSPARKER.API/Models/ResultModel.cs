using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSPARKER.API.Controllers
{
    public class ResultModel<T>
    {

        public T Data { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// -1: Catch Error
        /// 0: Başarılı
        /// 0>: özel hatalar
        /// </summary>
        /// deneme

        public int Success { get; set; }

    }
}
