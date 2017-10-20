using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{

    [RoutePrefix("rest/Client")]
    public class ClientService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllResponse All()
        {
            try
            {
                var response = new AllResponse();
                var bc = new ClientBusiness();
                response.ResultClient = bc.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
