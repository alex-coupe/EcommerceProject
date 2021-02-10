﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);

        Task<T> Post<T>(string uri, object value);

        Task<T> PostForm<T>(string uri, IFormFile file, IFormCollection form);

        Task<T> Put<T>(string uri, object value);

        Task Delete(string uri);
    }
}
