using Gateway.DataModels;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class InventoryService : IDataService<Inventory>
    {
        private IHttpService _httpService;
        private string baseUri = "http://inventory_service:5005";

        public InventoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<Inventory> Get(string slug)
        {
            return await _httpService.Get<Inventory>($"{baseUri}api/v1/inventory/{slug}");
        }

        public Task<IEnumerable<Inventory>> GetAll(string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> Post(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> PostFile(IFormFile file, string altText)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> Put(Inventory entity)
        {
            throw new NotImplementedException();
        }
    }
}
