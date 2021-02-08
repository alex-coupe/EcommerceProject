using Gateway.DataModels.Components;
using Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class ReviewService : IDataService<Review>
    {
        private IHttpService _httpService;
        private string baseUri = "http://review_service:5007/";

        public ReviewService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task Delete(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Get(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Review>> GetAll(string parameter)
        {
            return await _httpService.Get<IEnumerable<Review>>($"{baseUri}api/v1/reviews/{parameter}");
        }

        public Task<Review> Post(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Put(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
