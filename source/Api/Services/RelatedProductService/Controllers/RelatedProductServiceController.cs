using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelatedProductService.Interfaces;
using RelatedProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatedProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedProductServiceController : ControllerBase
    {
        private IRelatedProductRepository _relatedProductRepository;
        public RelatedProductServiceController(IRelatedProductRepository relatedProductRepository)
        {
            _relatedProductRepository = relatedProductRepository;
        }

        [HttpGet]
        [Route("v1/GetRelatedProducts")]
        public async Task<ActionResult<IEnumerable<RelatedProduct>>> GetRelatedProducts(int productId)
        {
            var relatedProducts = await _relatedProductRepository.GetRelatedProducts(productId);
            return Ok(relatedProducts);
        }

        [HttpPost]
        [Route("v1/AddRelatedProduct")]
        public async Task<ActionResult<RelatedProduct>> PostRelatedProduct(RelatedProduct relatedProduct)
        {
            _relatedProductRepository.AddRelatedProduct(relatedProduct);
            await _relatedProductRepository.SaveChanges();

            return Created("AddRelatedProduct", relatedProduct);
        }

    }
}
