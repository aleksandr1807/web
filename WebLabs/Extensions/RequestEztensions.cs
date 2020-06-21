using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebLabs.Extensions
{
    public static class RequestEztensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request
                .Headers["x-requested-width"]
                .Equals("XMLHttpRequest");
        }
    }
}
