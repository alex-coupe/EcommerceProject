using Gateway.DataTransfer.CheckoutService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CheckoutService : IDataService<CheckoutTransferObject>
    {
        private IHttpService _httpService;
        private string baseUri = "http://checkout_service:5004/";

        public CheckoutService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<CheckoutTransferObject> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CheckoutTransferObject>> GetAll(string[] parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<CheckoutTransferObject> Post(CheckoutTransferObject entity)
        {
            return await _httpService.Post<CheckoutTransferObject>($"{baseUri}api/v1/checkout", entity);
        }

        public Task<CheckoutTransferObject> PostForm(IFormFile file, CheckoutTransferObject form)
        {
            throw new NotImplementedException();
        }

        public Task<CheckoutTransferObject> Put(CheckoutTransferObject entity)
        {
            throw new NotImplementedException();
        }
    }
}
