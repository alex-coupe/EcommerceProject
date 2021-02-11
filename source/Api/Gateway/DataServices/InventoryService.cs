using Gateway.DataModels;
using Gateway.DataTransfer.InventoryService;
using Gateway.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class InventoryService : IDataService<InventoryTransferObject>
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

        public async Task<InventoryTransferObject> Get(string slug)
        {
            return await _httpService.Get<InventoryTransferObject>($"{baseUri}api/v1/inventory/{slug}");
        }

        public Task<IEnumerable<InventoryTransferObject>> GetAll(string[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryTransferObject> Post(InventoryTransferObject entity)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryTransferObject> PostForm(IFormFile file, InventoryTransferObject form)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryTransferObject> Put(InventoryTransferObject entity)
        {
            throw new NotImplementedException();
        }
    }
}
