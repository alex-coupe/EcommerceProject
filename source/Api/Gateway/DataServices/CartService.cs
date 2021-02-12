using Gateway.DataTransfer.CartService;
using Gateway.Interfaces;
using System.Threading.Tasks;

namespace Gateway.DataServices
{
    public class CartService : ICartService
    {
        private string baseUri = "http://cart_service:5003/";
        private IHttpService _httpService;
        public CartService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        

        public async Task<CartTransferObject> Get(string slug)
        {
            return await _httpService.Get<CartTransferObject>($"{baseUri}api/cartservice/v1/getcart?cartId={slug}");
        }

        public async Task<CartTransferObject> Post(CartTransferObject entity)
        {
            return await _httpService.Post<CartTransferObject>($"{baseUri}api/cartservice/v1/updatecart", entity);
        }
              
       
    }
}
