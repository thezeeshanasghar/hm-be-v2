using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V4.Models
{
    public class Response<T>
    {
        public T ResponseData { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Response(bool status, string message, T data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }
    }
}