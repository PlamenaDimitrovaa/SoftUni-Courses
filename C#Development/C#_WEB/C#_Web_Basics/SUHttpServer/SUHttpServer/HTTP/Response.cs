﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUHttpServer.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; set; }
        public HeaderCollection Headers { get; set; } = new HeaderCollection();
        public string Body { get; set; }
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers.Add("Server", "SoftUni Server");
            Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }
    }
}
