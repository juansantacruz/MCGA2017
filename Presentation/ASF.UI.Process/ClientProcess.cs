﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class ClientProcess : ProcessComponent
    {
        public List<Client> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Client/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultClient;
        }
    }
}