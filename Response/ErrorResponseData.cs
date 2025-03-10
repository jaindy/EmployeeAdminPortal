﻿using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace EmployeeAdminPortal.Response
{
    public class ErrorResponseData
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
