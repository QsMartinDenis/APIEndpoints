using APIendpoints.Entities;
using APIendpoints.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace APIendpoints.Endpoints.Brands
{
    public class UpdateEndpoint : EndpointBaseAsync
        .WithRequest<Brand>
        .WithActionResult
    {
        private readonly IBrandRepository _repository;

        public UpdateEndpoint(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("brands/edit")]
        public override async Task<ActionResult> HandleAsync([FromBody] Brand request, CancellationToken cancellationToken = default)
        {
            var brand = await _repository.FindByIdAsync(request.Id);

            if (brand == null)
            {
                return NotFound();
            }
            
            brand.BrandName = request.BrandName;

            var result = await _repository.UpdateAsync(brand);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
