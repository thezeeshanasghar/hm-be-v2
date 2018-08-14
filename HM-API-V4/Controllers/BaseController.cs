﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HM_API_V4.Controllers
{
    public class BaseController : ApiController
    {
        public static string GetMessageFromExceptionObject(Exception ex)
        {
            String message = ex.Message;
            message += (ex.InnerException != null) ? ("<br />" + ex.InnerException.Message) : "";
            if(ex.InnerException!=null)
                message += (ex.InnerException.InnerException != null) ? ("<br />" + ex.InnerException.InnerException.Message) : "";
            return message;
        }
    }
}