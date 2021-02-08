using Gateway.DataModels;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CheckoutService : IDataService<Checkout>
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

        public Task<Checkout> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Checkout>> GetAll(string parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<Checkout> Post(Checkout entity)
        {
            return await _httpService.Post<Checkout>($"{baseUri}api/v1/checkout", entity);
        }

        public Task<Checkout> Put(Checkout entity)
        {
            throw new NotImplementedException();
        }
    }
}
